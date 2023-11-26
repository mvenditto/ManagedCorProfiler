﻿using CorProf.Bindings;

namespace CorProf.Helpers
{
    public unsafe class ICorProfilerInfoHelpers2 : IDisposable
    {
        private readonly ICorProfilerInfo2* _profInfo;

        private const int ShortLength = 32;
        private const int LongLength = 1024;
        private const int StrLength = 256;

        private const int S_OK = 0;
        private const int E_FAIL = unchecked((int)0x80004005);

        // TODO: move to CorErr
        private const int CORPROF_E_CLASSID_IS_ARRAY = 0x1365;
        private const int CORPROF_E_CLASSID_IS_COMPOSITE = 0x1366;
        private const int CORPROF_E_DATAINCOMPLETE = 0x1351;

        public ICorProfilerInfoHelpers2(ICorProfilerInfo2* profilerInfo)
        {
            _profInfo = profilerInfo;
            profilerInfo->AddRef();
        }

        public int GetFunctionIDName(FunctionID funcId, out string funcName)
        {
            if (funcId == 0)
            {
                funcName = "Unknown_Native_Function";
                return 0;
            }

            ClassID classId = 0;
            ModuleID moduleId = 0;
            mdToken token = 0;
            ULONG32 nTypeArgs = 0;
            using var typeArgs = NativeBuffer<ClassID>.Alloc(ShortLength);
            COR_PRF_FRAME_INFO frameInfo = 0;

            funcName = "???";

            var hr = _profInfo->GetFunctionInfo2(
                funcId,
                frameInfo,
                &classId,
                &moduleId,
                &token,
                ShortLength,
                &nTypeArgs,
                typeArgs
            );

            if (hr < 0)
            {
                Console.WriteLine($"FAIL: GetFunctionInfo2 call failed with hr=0x{hr:x8}");
                funcName = "FuncNameLookupFailed";
                return hr;
            }

            var iMetaDataImportIID = new Guid(0x7dac8207, 0xd3ae, 0x4c75, 0x9b, 0x67, 0x92, 0x80, 0x1a, 0x49, 0x7d, 0x44);

            var ptr = NativeBuffer.Alloc((nuint)sizeof(nint));

            hr = _profInfo->GetModuleMetaData(
                moduleId,
                (uint)CorOpenFlags.ofRead,
                &iMetaDataImportIID,
                (IUnknown**)&ptr);

            if (hr < 0)
            {
                Console.WriteLine($"FAIL: GetModuleMetaData call failed with hr=0x{hr:x8}");
                funcName = "FuncNameLookupFailed";
                return hr;
            }

            var metadataImport = (IMetaDataImport*)ptr;

            using var szName = NativeBuffer<WCHAR>.Alloc(StrLength); //

            hr = metadataImport->GetMethodProps(
                token, 
                null, 
                szName, 
                StrLength, 
                null, // 0
                null, // 0
                null, 
                null, 
                null, 
                null);

            if (hr < 0)
            {
                Console.WriteLine($"FAIL: GetMethodProps call failed with hr=0x{hr:x8}");
                funcName = "FuncNameLookupFailed";
                return hr;
            }

            string name = MarshalHelpers.PtrToStringUtf16(szName) ?? "???";

            if (nTypeArgs > 0)
            {
                name += "<";
            }

            for (uint i = 0; i < nTypeArgs; i++)
            {
                // Console.WriteLine($"typeArgs[{i}]=0x{typeArgs[i]:x8}");

                GetClassIDName(typeArgs[i], out var typeArgName);

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

            return S_OK;
        }

        public int GetFunctionFullyQualifiedName(FunctionID funcId, out string funcName)
        {
            if (funcId == 0)
            {
                funcName = "Unknown_Native_Function";
                return 0;
            }

            ulong classId = 0;
            ulong moduleId = 0;
            uint token = 0;
            ulong frameInfo = 0;
            uint nTypeArgs = 0;
            using var typeArgs = NativeBuffer<ulong>.Alloc(ShortLength);
            funcName = "???";

            var hr = _profInfo->GetFunctionInfo2(
                funcId,
                frameInfo,
                &classId,
                &moduleId,
                &token,
                ShortLength,
                &nTypeArgs,
                typeArgs
            );

            if (hr < 0)
            {
                Console.WriteLine($"Error GetFunctionInfo2 hr={hr}");
                funcName = "FuncNameLookupFailed";
                return hr;
            }

            var pbBaseLoadAddr = (byte*)null;
            uint pcchName = 0;
            ulong assemblyId = 0;

            using var szName = NativeBuffer<ushort>.Alloc(256);

            hr = _profInfo->GetModuleInfo(
                moduleId,
                &pbBaseLoadAddr,
                256,
                &pcchName,
                szName,
                &assemblyId);

            if (hr < 0)
            {
                Console.WriteLine($"HR: 0x{hr:x8}");
            }

            string modName = MarshalHelpers.PtrToStringUtf16(szName) ?? "";

            if (modName != "")
            {
                modName = Path.GetFileName(modName);
            }

            var iMetaDataImportIID = new Guid(0x7dac8207, 0xd3ae, 0x4c75, 0x9b, 0x67, 0x92, 0x80, 0x1a, 0x49, 0x7d, 0x44);

            var ptr = NativeBuffer.Alloc((nuint)sizeof(nint));

            hr = _profInfo->GetModuleMetaData(
                moduleId,
                (uint)CorOpenFlags.ofRead,
                &iMetaDataImportIID,
                (IUnknown**)&ptr);

            if (hr < 0)
            {
                return hr;
            }

            var metadataImport = (IMetaDataImport*)ptr;

            // using var szName = NativeBuffer<ushort>.Alloc(300);

            uint typeDefToken = 0;

            metadataImport->GetMethodProps(
                token, &typeDefToken, szName, ShortLength, null, null, null, null, null, null);

            string name = MarshalHelpers.PtrToStringUtf16(szName) ?? "???";

            metadataImport->GetTypeDefProps(typeDefToken, szName, ShortLength, null, null, null);

            string clsName = MarshalHelpers.PtrToStringUtf16(szName) ?? "???";

            if (nTypeArgs > 0)
            {
                name += "<";
            }

            for (uint i = 0; i < nTypeArgs; i++)
            {
                GetClassIDName(typeArgs[i], out var typeArgName);

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

            return S_OK;
        }

        public int GetClassIDName(ulong classId, out string className)
        {
            ulong moduleId;
            uint mdTypeDef;
            ulong parentClassID;
            uint nTypeArgs;
            using var typeArgs = NativeBuffer<ulong>.Alloc(ShortLength);
            className = string.Empty;

            if (classId == 0)
            {
                return E_FAIL;
            }

            // Console.WriteLine($"GetClassIDInfo2 0x{classId:x8}");

            int hr = _profInfo->GetClassIDInfo2(
                classId, 
                &moduleId, 
                &mdTypeDef,
                &parentClassID, 
                typeArgs.Length, 
                &nTypeArgs, 
                typeArgs);

            if (hr < 0)
            {
                className = "GetClassIDNameFailed";
                return hr;
            }

            className = hr switch
            {
                CORPROF_E_CLASSID_IS_ARRAY => "ArrayClass",         // We have a ClassID of an array.
                CORPROF_E_CLASSID_IS_COMPOSITE => "CompositeClass", // We have a composite class
                CORPROF_E_DATAINCOMPLETE => "DataIncomplete",       // type-loading is not yet complete. Cannot do anything about it.
                _ => "GetClassIDNameUnespected"
            };

            var iMetaDataImportIID = new Guid(0x7dac8207, 0xd3ae, 0x4c75, 0x9b, 0x67, 0x92, 0x80, 0x1a, 0x49, 0x7d, 0x44);

            var ptr = NativeBuffer.Alloc((nuint)sizeof(nint));

            hr = _profInfo->GetModuleMetaData(
                moduleId,
                (uint)(CorOpenFlags.ofRead | CorOpenFlags.ofWrite),
                &iMetaDataImportIID,
                (IUnknown**)&ptr);

            if (hr < 0)
            {
                return hr;
            }

            var metadataImport = (IMetaDataImport*)ptr;

            using var szName = NativeBuffer<ushort>.Alloc(ShortLength);

            uint typeDefToken = 0;
            uint typeDefFlags = 0;

            hr = metadataImport->GetTypeDefProps(
                typeDefToken, 
                szName, 
                szName.Length, 
                null, 
                &typeDefFlags, 
                null);

            if (hr < 0)
            {
                return hr;
            }

            string name = MarshalHelpers.PtrToStringUtf16(szName) ?? "???";

            if (nTypeArgs > 0)
            {
                name += "<";
            }

            for (uint i = 0; i < nTypeArgs; i++)
            {
                GetClassIDName(typeArgs[i], out var typeArgName);

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

            className = name;

            return S_OK;
        }

        public void Dispose()
        {
            if (_profInfo != null)
            {
                _profInfo->Release();
            }
        }
    }
}