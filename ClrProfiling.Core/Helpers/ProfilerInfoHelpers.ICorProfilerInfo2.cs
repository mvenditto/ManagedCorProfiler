using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.System.Diagnostics.ClrProfiling;
using Windows.Win32.System.WinRT.Metadata;
using Windows.Win32.System.Com;
using Windows.Win32.Foundation;
using ClrProfiling.Core.Helpers;

using FunctionID = nuint;
using ModuleID = nuint;
using ClassID = nuint;
using ULONG32 = uint;
using mdToken = uint;
using mdTypeDef = uint;
using COR_PRF_FRAME_INFO = nuint;
using System.Diagnostics.CodeAnalysis;

namespace ClrProfiling.Helpers;

public static unsafe class ProfilerInfoHelpers
{
    private const int ShortLength = 32;
    private const int LongLength = 1024;
    private const int StrLength = 256;

    public static HRESULT GetFunctionIDName(ICorProfilerInfo2* profilerInfo, FunctionID funcId, out string funcName)
    {
        if (funcId == 0)
        {
            funcName = "Unknown_Native_Function";
            return HRESULT.S_OK;
        }

        ClassID classId = 0;
        ModuleID moduleId = 0;
        mdToken token = 0;
        ULONG32 nTypeArgs = 0;
        using var typeArgs = NativeBuffer<ClassID>.Alloc(ShortLength);
        COR_PRF_FRAME_INFO frameInfo = 0;

        funcName = "???";

        var hr = profilerInfo->GetFunctionInfo2(
            funcId,
            frameInfo,
            &classId,
            &moduleId,
            &token,
            ShortLength,
            &nTypeArgs,
            typeArgs
        );

        if (hr.Failed)
        {
            Console.WriteLine($"FAIL: GetFunctionInfo2 call failed with hr=0x{hr:x8}");
            funcName = "FuncNameLookupFailed";
            return hr;
        }

        // var ptr = (void*) nint.Zero;

        var iMetaDataImportIID = (Guid*)Unsafe.AsPointer(ref Unsafe.AsRef(in IMetaDataImport.IID_Guid));

        using var metadataImportPtr = new ComPtr<IMetaDataImport>();

        hr = profilerInfo->GetModuleMetaData(
            moduleId,
            (uint)CorOpenFlags.ofRead,
            iMetaDataImportIID,
            (IUnknown**)metadataImportPtr.GetAddressOf()); // (IUnknown**) &ptr

        if (hr.Failed)
        {
            Console.WriteLine($"FAIL: GetModuleMetaData call failed with hr=0x{hr:x8}");
            funcName = "FuncNameLookupFailed";
            return hr;
        }

        var metadataImport = metadataImportPtr.Get();

        using var buff = NativeBuffer<ushort>.Alloc(StrLength);

        var szName = new PWSTR((char*)buff.Pointer);

        hr = metadataImport->GetMethodProps(
            token,
            (ULONG32*)0,
            szName,
            StrLength,
            (ULONG32*)0,
            (ULONG32*)0,
            (byte**)0,
            (ULONG32*)0,
            (ULONG32*)0,
            (ULONG32*)0);

        if (hr.Failed)
        {
            Console.WriteLine($"FAIL: GetMethodProps call failed with hr=0x{hr:x8}");
            funcName = "FuncNameLookupFailed";
            return hr;
        }

        string name = MarshalHelpers.PtrToStringUtf16(buff) ?? "???";

        if (nTypeArgs > 0)
        {
            name += "<";
        }

        for (uint i = 0; i < nTypeArgs; i++)
        {
            GetClassIDName(profilerInfo, typeArgs[i], out var typeArgName);

            name += typeArgName;

            if (i + 1 != nTypeArgs)
            {
                name += ", ";
            }
        }

        if (nTypeArgs > 0)
        {
            name += ">";
        }

        funcName = name;

        return HRESULT.S_OK;
    }

    public static HRESULT GetFunctionFullyQualifiedName(ICorProfilerInfo2* profilerInfo, FunctionID funcId, out string funcName)
    {
        if (funcId == 0)
        {
            funcName = "Unknown_Native_Function";
            return HRESULT.S_OK;
        }

        ClassID classId = 0;
        ModuleID moduleId = 0;
        mdToken token = 0;
        ULONG32 nTypeArgs = 0;
        using var typeArgs = NativeBuffer<ClassID>.Alloc(ShortLength);
        COR_PRF_FRAME_INFO frameInfo = 0;

        funcName = "???";

        var hr = profilerInfo->GetFunctionInfo2(
            funcId,
            frameInfo,
            &classId,
            &moduleId,
            &token,
            ShortLength,
            &nTypeArgs,
            typeArgs
        );

        if (hr.Failed)
        {
            Console.WriteLine($"Error GetFunctionInfo2 hr={hr}");
            funcName = "FuncNameLookupFailed";
            return hr;
        }

        var pbBaseLoadAddr = (byte*)null;
        uint pcchName = 0;
        nuint assemblyId = 0;

        using var buff = NativeBuffer<ushort>.Alloc(256);
        var szName = new PWSTR((char*)buff.Pointer);

        hr = profilerInfo->GetModuleInfo(
            moduleId,
            &pbBaseLoadAddr,
            256U,
            &pcchName,
            szName,
            &assemblyId);

        if (hr.Failed)
        {
            Console.WriteLine($"HR: 0x{hr:x8}");
        }

        string modName = MarshalHelpers.PtrToStringUtf16(buff) ?? "";

        if (modName != "")
        {
            modName = Path.GetFileName(modName);
        }

        var iMetaDataImportIID = (Guid*)Unsafe.AsPointer(ref Unsafe.AsRef(in IMetaDataImport.IID_Guid));

        using var metadataImportPtr = new ComPtr<IMetaDataImport>();

        hr = profilerInfo->GetModuleMetaData(
            moduleId,
            (uint)CorOpenFlags.ofRead,
            iMetaDataImportIID,
            (IUnknown**)metadataImportPtr.GetAddressOf());

        if (hr.Failed)
        {
            return hr;
        }

        var metadataImport = metadataImportPtr.Get();

        // using var szName = NativeBuffer<ushort>.Alloc(300);

        uint typeDefToken = 0;

        metadataImport->GetMethodProps(
            token, &typeDefToken, szName, ShortLength, null, null, null, null, null, null);

        string name = MarshalHelpers.PtrToStringUtf16(buff) ?? "???";

        metadataImport->GetTypeDefProps(typeDefToken, szName, ShortLength, null, null, null);

        string clsName = MarshalHelpers.PtrToStringUtf16(buff) ?? "???";

        if (nTypeArgs > 0)
        {
            name += "<";
        }

        for (uint i = 0; i < nTypeArgs; i++)
        {
            GetClassIDName(profilerInfo, typeArgs[i], out var typeArgName);

            name += typeArgName;

            if (i + 1 != nTypeArgs)
            {
                name += ", ";
            }
        }

        if (nTypeArgs > 0)
        {
            name += ">";
        }

        funcName = modName + "!" + clsName + "::" + name;

        return HRESULT.S_OK;
    }

    public static int GetClassIDName(ICorProfilerInfo2* profilerInfo, nuint classId, out string className)
    {
        className = string.Empty;

        if (classId == 0)
        {
            return HRESULT.E_FAIL;
        }

        ModuleID moduleId = 0;
        mdTypeDef classToken;
        ClassID parentClassID;
        ULONG32 nTypeArgs;
        using var typeArgs = NativeBuffer<ClassID>.Alloc(ShortLength);
        
        var hr = profilerInfo->GetClassIDInfo2(
            classId,
            &moduleId,
            &classToken,
            &parentClassID,
            ShortLength,
            &nTypeArgs,
            typeArgs);

        if (hr == CorError.CORPROF_E_CLASSID_IS_ARRAY) // We have a ClassID of an array.
        {
            className = "ArrayClass";
            return hr;
        }
        else if (hr == CorError.CORPROF_E_CLASSID_IS_COMPOSITE) // We have a composite class
        {
            className = "CompositeClass";
            return hr;
        }
        else if (hr == CorError.CORPROF_E_DATAINCOMPLETE) // type-loading is not yet complete. Cannot do anything about it.
        {
            className = "DataIncomplete";
            return hr;
        }
        else if (hr.Failed)
        {
            Console.WriteLine($"FAIL: GetClassIDInfo returned {hr} for ClassID 0x{classId:x8}");
            className = "GetClassIDNameFailed";
            return hr;
        }

        var iMetaDataImportIID = (Guid*)Unsafe.AsPointer(ref Unsafe.AsRef(in IMetaDataImport.IID_Guid));

        using var metadataImportPtr = new ComPtr<IMetaDataImport>();

        hr = profilerInfo->GetModuleMetaData(
            moduleId,
            (uint)(CorOpenFlags.ofRead | CorOpenFlags.ofWrite),
            iMetaDataImportIID,
            (IUnknown**)metadataImportPtr.GetAddressOf()); // (IUnknown**) &ptr

        if (hr.Failed)
        {
            Console.WriteLine($"FAIL: GetModuleMetaData call failed with hr={hr}");
            className = "ClassIDLookupFailed";
            return hr;
        }

        var metadataImport = metadataImportPtr.Get();

        using var buff = NativeBuffer<ushort>.Alloc(LongLength);
        var szName = new PWSTR((char*)buff.Pointer);

        uint typeDefFlags = 0;

        hr = metadataImport->GetTypeDefProps(
            classToken,
            szName,
            LongLength,
            null,
            &typeDefFlags,
            null);

        if (hr.Failed)
        {
            Console.WriteLine($"FAIL: GetModuleMetaData call failed with hr={hr}");
            className = "ClassIDLookupFailed";
            return hr;
        }

        string name = szName.ToString();

        if (nTypeArgs > 0)
        {
            name += "<";
        }

        string typeArgClassName = string.Empty;

        for (uint i = 0; i < nTypeArgs; i++)
        {
            GetClassIDName(profilerInfo, typeArgs[i], out typeArgClassName);

            name += typeArgClassName;

            if (i + 1 != nTypeArgs)
            {
                name += ", ";
            }
        }

        if (nTypeArgs > 0)
        {
            name += ">";
        }

        className = name;

        return HRESULT.S_OK;
    }
}