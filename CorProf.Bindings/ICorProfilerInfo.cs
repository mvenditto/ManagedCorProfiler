using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    [Guid("28B5557D-3F3F-48B4-90B2-5F9EEA2F6C48")]
    [NativeTypeName("struct ICorProfilerInfo : IUnknown")]
    public unsafe partial struct ICorProfilerInfo
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, Guid*, void**, int>)(lpVtbl[0]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, uint>)(lpVtbl[1]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, uint>)(lpVtbl[2]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int GetClassFromObject([NativeTypeName("ObjectID")] ulong objectId, [NativeTypeName("ClassID *")] ulong* pClassId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, ulong*, int>)(lpVtbl[3]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), objectId, pClassId);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int GetClassFromToken([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("mdTypeDef")] uint typeDef, [NativeTypeName("ClassID *")] ulong* pClassId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, uint, ulong*, int>)(lpVtbl[4]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), moduleId, typeDef, pClassId);
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int GetCodeInfo([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("LPCBYTE *")] byte** pStart, [NativeTypeName("ULONG *")] uint* pcSize)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, byte**, uint*, int>)(lpVtbl[5]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), functionId, pStart, pcSize);
        }

        [VtblIndex(6)]
        [return: NativeTypeName("HRESULT")]
        public int GetEventMask([NativeTypeName("DWORD *")] uint* pdwEvents)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, uint*, int>)(lpVtbl[6]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), pdwEvents);
        }

        [VtblIndex(7)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionFromIP([NativeTypeName("LPCBYTE")] byte* ip, [NativeTypeName("FunctionID *")] ulong* pFunctionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, byte*, ulong*, int>)(lpVtbl[7]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), ip, pFunctionId);
        }

        [VtblIndex(8)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionFromToken([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("mdToken")] uint token, [NativeTypeName("FunctionID *")] ulong* pFunctionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, uint, ulong*, int>)(lpVtbl[8]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), moduleId, token, pFunctionId);
        }

        [VtblIndex(9)]
        [return: NativeTypeName("HRESULT")]
        public int GetHandleFromThread([NativeTypeName("ThreadID")] ulong threadId, [NativeTypeName("HANDLE *")] void** phThread)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, void**, int>)(lpVtbl[9]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), threadId, phThread);
        }

        [VtblIndex(10)]
        [return: NativeTypeName("HRESULT")]
        public int GetObjectSize([NativeTypeName("ObjectID")] ulong objectId, [NativeTypeName("ULONG *")] uint* pcSize)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, uint*, int>)(lpVtbl[10]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), objectId, pcSize);
        }

        [VtblIndex(11)]
        [return: NativeTypeName("HRESULT")]
        public int IsArrayClass([NativeTypeName("ClassID")] ulong classId, CorElementType* pBaseElemType, [NativeTypeName("ClassID *")] ulong* pBaseClassId, [NativeTypeName("ULONG *")] uint* pcRank)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, CorElementType*, ulong*, uint*, int>)(lpVtbl[11]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), classId, pBaseElemType, pBaseClassId, pcRank);
        }

        [VtblIndex(12)]
        [return: NativeTypeName("HRESULT")]
        public int GetThreadInfo([NativeTypeName("ThreadID")] ulong threadId, [NativeTypeName("DWORD *")] uint* pdwWin32ThreadId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, uint*, int>)(lpVtbl[12]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), threadId, pdwWin32ThreadId);
        }

        [VtblIndex(13)]
        [return: NativeTypeName("HRESULT")]
        public int GetCurrentThreadID([NativeTypeName("ThreadID *")] ulong* pThreadId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong*, int>)(lpVtbl[13]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), pThreadId);
        }

        [VtblIndex(14)]
        [return: NativeTypeName("HRESULT")]
        public int GetClassIDInfo([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("ModuleID *")] ulong* pModuleId, [NativeTypeName("mdTypeDef *")] uint* pTypeDefToken)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, ulong*, uint*, int>)(lpVtbl[14]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), classId, pModuleId, pTypeDefToken);
        }

        [VtblIndex(15)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionInfo([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("ClassID *")] ulong* pClassId, [NativeTypeName("ModuleID *")] ulong* pModuleId, [NativeTypeName("mdToken *")] uint* pToken)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, ulong*, ulong*, uint*, int>)(lpVtbl[15]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), functionId, pClassId, pModuleId, pToken);
        }

        [VtblIndex(16)]
        [return: NativeTypeName("HRESULT")]
        public int SetEventMask([NativeTypeName("DWORD")] uint dwEvents)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, uint, int>)(lpVtbl[16]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), dwEvents);
        }

        [VtblIndex(17)]
        [return: NativeTypeName("HRESULT")]
        public int SetEnterLeaveFunctionHooks([NativeTypeName("FunctionEnter *")] delegate* unmanaged[Stdcall]<ulong, void> pFuncEnter, [NativeTypeName("FunctionLeave *")] delegate* unmanaged[Stdcall]<ulong, void> pFuncLeave, [NativeTypeName("FunctionTailcall *")] delegate* unmanaged[Stdcall]<ulong, void> pFuncTailcall)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, delegate* unmanaged[Stdcall]<ulong, void>, delegate* unmanaged[Stdcall]<ulong, void>, delegate* unmanaged[Stdcall]<ulong, void>, int>)(lpVtbl[17]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), pFuncEnter, pFuncLeave, pFuncTailcall);
        }

        [VtblIndex(18)]
        [return: NativeTypeName("HRESULT")]
        public int SetFunctionIDMapper([NativeTypeName("FunctionIDMapper *")] delegate* unmanaged[Stdcall]<ulong, int*, ulong> pFunc)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, delegate* unmanaged[Stdcall]<ulong, int*, ulong>, int>)(lpVtbl[18]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), pFunc);
        }

        [VtblIndex(19)]
        [return: NativeTypeName("HRESULT")]
        public int GetTokenAndMetaDataFromFunction([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("const IID &")] Guid* riid, IUnknown** ppImport, [NativeTypeName("mdToken *")] uint* pToken)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, Guid*, IUnknown**, uint*, int>)(lpVtbl[19]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), functionId, riid, ppImport, pToken);
        }

        [VtblIndex(20)]
        [return: NativeTypeName("HRESULT")]
        public int GetModuleInfo([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("LPCBYTE *")] byte** ppBaseLoadAddress, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pcchName, [NativeTypeName("WCHAR[]")] ushort* szName, [NativeTypeName("AssemblyID *")] ulong* pAssemblyId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, byte**, uint, uint*, ushort*, ulong*, int>)(lpVtbl[20]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), moduleId, ppBaseLoadAddress, cchName, pcchName, szName, pAssemblyId);
        }

        [VtblIndex(21)]
        [return: NativeTypeName("HRESULT")]
        public int GetModuleMetaData([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("DWORD")] uint dwOpenFlags, [NativeTypeName("const IID &")] Guid* riid, IUnknown** ppOut)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, uint, Guid*, IUnknown**, int>)(lpVtbl[21]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), moduleId, dwOpenFlags, riid, ppOut);
        }

        [VtblIndex(22)]
        [return: NativeTypeName("HRESULT")]
        public int GetILFunctionBody([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("mdMethodDef")] uint methodId, [NativeTypeName("LPCBYTE *")] byte** ppMethodHeader, [NativeTypeName("ULONG *")] uint* pcbMethodSize)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, uint, byte**, uint*, int>)(lpVtbl[22]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), moduleId, methodId, ppMethodHeader, pcbMethodSize);
        }

        [VtblIndex(23)]
        [return: NativeTypeName("HRESULT")]
        public int GetILFunctionBodyAllocator([NativeTypeName("ModuleID")] ulong moduleId, IMethodMalloc** ppMalloc)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, IMethodMalloc**, int>)(lpVtbl[23]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), moduleId, ppMalloc);
        }

        [VtblIndex(24)]
        [return: NativeTypeName("HRESULT")]
        public int SetILFunctionBody([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("mdMethodDef")] uint methodid, [NativeTypeName("LPCBYTE")] byte* pbNewILMethodHeader)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, uint, byte*, int>)(lpVtbl[24]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), moduleId, methodid, pbNewILMethodHeader);
        }

        [VtblIndex(25)]
        [return: NativeTypeName("HRESULT")]
        public int GetAppDomainInfo([NativeTypeName("AppDomainID")] ulong appDomainId, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pcchName, [NativeTypeName("WCHAR[]")] ushort* szName, [NativeTypeName("ProcessID *")] ulong* pProcessId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, uint, uint*, ushort*, ulong*, int>)(lpVtbl[25]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), appDomainId, cchName, pcchName, szName, pProcessId);
        }

        [VtblIndex(26)]
        [return: NativeTypeName("HRESULT")]
        public int GetAssemblyInfo([NativeTypeName("AssemblyID")] ulong assemblyId, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pcchName, [NativeTypeName("WCHAR[]")] ushort* szName, [NativeTypeName("AppDomainID *")] ulong* pAppDomainId, [NativeTypeName("ModuleID *")] ulong* pModuleId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, uint, uint*, ushort*, ulong*, ulong*, int>)(lpVtbl[26]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), assemblyId, cchName, pcchName, szName, pAppDomainId, pModuleId);
        }

        [VtblIndex(27)]
        [return: NativeTypeName("HRESULT")]
        public int SetFunctionReJIT([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, int>)(lpVtbl[27]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(28)]
        [return: NativeTypeName("HRESULT")]
        public int ForceGC()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, int>)(lpVtbl[28]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(29)]
        [return: NativeTypeName("HRESULT")]
        public int SetILInstrumentedCodeMap([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("BOOL")] int fStartJit, [NativeTypeName("ULONG")] uint cILMapEntries, [NativeTypeName("COR_IL_MAP[]")] COR_IL_MAP* rgILMapEntries)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, int, uint, COR_IL_MAP*, int>)(lpVtbl[29]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), functionId, fStartJit, cILMapEntries, rgILMapEntries);
        }

        [VtblIndex(30)]
        [return: NativeTypeName("HRESULT")]
        public int GetInprocInspectionInterface(IUnknown** ppicd)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, IUnknown**, int>)(lpVtbl[30]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), ppicd);
        }

        [VtblIndex(31)]
        [return: NativeTypeName("HRESULT")]
        public int GetInprocInspectionIThisThread(IUnknown** ppicd)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, IUnknown**, int>)(lpVtbl[31]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), ppicd);
        }

        [VtblIndex(32)]
        [return: NativeTypeName("HRESULT")]
        public int GetThreadContext([NativeTypeName("ThreadID")] ulong threadId, [NativeTypeName("ContextID *")] ulong* pContextId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, ulong*, int>)(lpVtbl[32]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), threadId, pContextId);
        }

        [VtblIndex(33)]
        [return: NativeTypeName("HRESULT")]
        public int BeginInprocDebugging([NativeTypeName("BOOL")] int fThisThreadOnly, [NativeTypeName("DWORD *")] uint* pdwProfilerContext)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, int, uint*, int>)(lpVtbl[33]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), fThisThreadOnly, pdwProfilerContext);
        }

        [VtblIndex(34)]
        [return: NativeTypeName("HRESULT")]
        public int EndInprocDebugging([NativeTypeName("DWORD")] uint dwProfilerContext)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, uint, int>)(lpVtbl[34]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), dwProfilerContext);
        }

        [VtblIndex(35)]
        [return: NativeTypeName("HRESULT")]
        public int GetILToNativeMapping([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("ULONG32")] uint cMap, [NativeTypeName("ULONG32 *")] uint* pcMap, [NativeTypeName("COR_DEBUG_IL_TO_NATIVE_MAP[]")] COR_DEBUG_IL_TO_NATIVE_MAP* map)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo*, ulong, uint, uint*, COR_DEBUG_IL_TO_NATIVE_MAP*, int>)(lpVtbl[35]))((ICorProfilerInfo*)Unsafe.AsPointer(ref this), functionId, cMap, pcMap, map);
        }
    }
}
