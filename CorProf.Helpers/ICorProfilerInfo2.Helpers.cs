﻿using CorProf.Bindings;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CorProf.Helpers
{
    public unsafe class ICorProfilerInfoHelpers2
    {
        private readonly ICorProfilerInfo2* _profInfo;

        private const int Shortlength = 32;

        private const int S_OK = 0;
        private const int E_FAIL = unchecked((int)0x80004005);

        // TODO: move to CorErr
        private const int CORPROF_E_CLASSID_IS_ARRAY = 0x1365;
        private const int CORPROF_E_CLASSID_IS_COMPOSITE = 0x1366;
        private const int CORPROF_E_DATAINCOMPLETE = 0x1351;

        public ICorProfilerInfoHelpers2(ICorProfilerInfo2* profilerInfo)
        {
            _profInfo = profilerInfo;
        }

        public int GetFunctionIDName(ulong funcId, out string funcName)
        {
            ulong classId = 0;
            ulong moduleId = 0;
            uint token = 0;
            ulong frameInfo = 0;
            uint nTypeArgs = 0;
            ulong* typeArgs = (ulong*)NativeMemory.Alloc(sizeof(ulong) * Shortlength);
            funcName = "???";

            var hr = _profInfo->GetFunctionInfo2(
                funcId,
                frameInfo,
                &classId,
                &moduleId,
                &token,
                0,
                &nTypeArgs,
                typeArgs
            );

            if (hr < 0)
            {
                Console.WriteLine($"Error GetFunctionInfo2 hr={hr}");
            }

            var iMetaDataImportIID = new Guid(0x7dac8207, 0xd3ae, 0x4c75, 0x9b, 0x67, 0x92, 0x80, 0x1a, 0x49, 0x7d, 0x44);

            var ptr = (IUnknown*)NativeMemory.Alloc((nuint)sizeof(nint));

            hr = _profInfo->GetModuleMetaData(
                moduleId,
                (uint)CorOpenFlags.ofRead,
                &iMetaDataImportIID,
                &ptr);

            if (hr < 0)
            {
                NativeMemory.Free(typeArgs);
                return hr;
            }

            var metadataImport = (IMetaDataImport*)ptr;

            var szName = (ushort*)NativeMemory.Alloc(sizeof(ushort) * 300);

            uint typeDefToken = 0;

            metadataImport->GetMethodProps(
                token, &typeDefToken, szName, 300, null, null, null, null, null, null);

            string name = Marshal.PtrToStringUni((nint)szName) ?? "???";

            NativeMemory.Free(szName);

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

            funcName = name;

            NativeMemory.Free(typeArgs);
            return S_OK;
        }

        public int GetClassIDName(ulong classId, out string className)
        {
            ulong moduleId;
            uint mdTypeDef;
            ulong parentClassID;
            uint nTypeArgs;
            ulong* typeArgs = (ulong*) NativeMemory.Alloc(sizeof(ulong) * Shortlength);
            className = string.Empty;

            if (classId == 0)
            {
                return E_FAIL;
            }

            int hr = _profInfo->GetClassIDInfo2(
                classId, 
                &moduleId, 
                &mdTypeDef,
                &parentClassID, 
                Shortlength, 
                &nTypeArgs, 
                typeArgs);

            if (hr < 0)
            {
                className = "GetClassIDNameFailed";
                NativeMemory.Free(typeArgs);
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

            var ptr = (CorProf.Bindings.IUnknown*)NativeMemory.Alloc((nuint)sizeof(nint));

            hr = _profInfo->GetModuleMetaData(
                moduleId,
                (uint)(CorOpenFlags.ofRead | CorOpenFlags.ofWrite),
                &iMetaDataImportIID,
                &ptr);

            if (hr < 0)
            {
                return hr;
            }

            var metadataImport = (IMetaDataImport*)ptr;

            var szName = (ushort*)NativeMemory.Alloc(sizeof(ushort) * 300);

            uint typeDefToken = 0;
            uint typeDefFlags = 0;

            hr = metadataImport->GetTypeDefProps(
                typeDefToken, 
                szName, 
                300, 
                null, 
                &typeDefFlags, 
                null);

            if (hr < 0)
            {
                NativeMemory.Free(szName);
                return hr;
            }

            string name = Marshal.PtrToStringUni((nint)szName) ?? "???";

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

            NativeMemory.Free(typeArgs);

            className = name;

            return S_OK;
        }
    }
}