using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    [Guid("008170DB-F8CC-4796-9A51-DC8AA0B47012")]
    [NativeTypeName("struct ICorProfilerInfo9 : ICorProfilerInfo8")]
    public unsafe partial struct ICorProfilerInfo9
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, Guid*, void**, int>)(lpVtbl[0]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, uint>)(lpVtbl[1]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, uint>)(lpVtbl[2]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int GetClassFromObject([NativeTypeName("ObjectID")] ulong objectId, [NativeTypeName("ClassID *")] ulong* pClassId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ulong*, int>)(lpVtbl[3]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), objectId, pClassId);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int GetClassFromToken([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("mdTypeDef")] uint typeDef, [NativeTypeName("ClassID *")] ulong* pClassId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, ulong*, int>)(lpVtbl[4]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), moduleId, typeDef, pClassId);
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int GetCodeInfo([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("LPCBYTE *")] byte** pStart, [NativeTypeName("ULONG *")] uint* pcSize)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, byte**, uint*, int>)(lpVtbl[5]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), functionId, pStart, pcSize);
        }

        [VtblIndex(6)]
        [return: NativeTypeName("HRESULT")]
        public int GetEventMask([NativeTypeName("DWORD *")] uint* pdwEvents)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, uint*, int>)(lpVtbl[6]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), pdwEvents);
        }

        [VtblIndex(7)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionFromIP([NativeTypeName("LPCBYTE")] byte* ip, [NativeTypeName("FunctionID *")] ulong* pFunctionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, byte*, ulong*, int>)(lpVtbl[7]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), ip, pFunctionId);
        }

        [VtblIndex(8)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionFromToken([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("mdToken")] uint token, [NativeTypeName("FunctionID *")] ulong* pFunctionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, ulong*, int>)(lpVtbl[8]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), moduleId, token, pFunctionId);
        }

        [VtblIndex(9)]
        [return: NativeTypeName("HRESULT")]
        public int GetHandleFromThread([NativeTypeName("ThreadID")] ulong threadId, [NativeTypeName("HANDLE *")] void** phThread)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, void**, int>)(lpVtbl[9]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), threadId, phThread);
        }

        [VtblIndex(10)]
        [return: NativeTypeName("HRESULT")]
        public int GetObjectSize([NativeTypeName("ObjectID")] ulong objectId, [NativeTypeName("ULONG *")] uint* pcSize)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint*, int>)(lpVtbl[10]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), objectId, pcSize);
        }

        [VtblIndex(11)]
        [return: NativeTypeName("HRESULT")]
        public int IsArrayClass([NativeTypeName("ClassID")] ulong classId, CorElementType* pBaseElemType, [NativeTypeName("ClassID *")] ulong* pBaseClassId, [NativeTypeName("ULONG *")] uint* pcRank)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, CorElementType*, ulong*, uint*, int>)(lpVtbl[11]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), classId, pBaseElemType, pBaseClassId, pcRank);
        }

        [VtblIndex(12)]
        [return: NativeTypeName("HRESULT")]
        public int GetThreadInfo([NativeTypeName("ThreadID")] ulong threadId, [NativeTypeName("DWORD *")] uint* pdwWin32ThreadId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint*, int>)(lpVtbl[12]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), threadId, pdwWin32ThreadId);
        }

        [VtblIndex(13)]
        [return: NativeTypeName("HRESULT")]
        public int GetCurrentThreadID([NativeTypeName("ThreadID *")] ulong* pThreadId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong*, int>)(lpVtbl[13]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), pThreadId);
        }

        [VtblIndex(14)]
        [return: NativeTypeName("HRESULT")]
        public int GetClassIDInfo([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("ModuleID *")] ulong* pModuleId, [NativeTypeName("mdTypeDef *")] uint* pTypeDefToken)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ulong*, uint*, int>)(lpVtbl[14]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), classId, pModuleId, pTypeDefToken);
        }

        [VtblIndex(15)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionInfo([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("ClassID *")] ulong* pClassId, [NativeTypeName("ModuleID *")] ulong* pModuleId, [NativeTypeName("mdToken *")] uint* pToken)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ulong*, ulong*, uint*, int>)(lpVtbl[15]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), functionId, pClassId, pModuleId, pToken);
        }

        [VtblIndex(16)]
        [return: NativeTypeName("HRESULT")]
        public int SetEventMask([NativeTypeName("DWORD")] uint dwEvents)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, uint, int>)(lpVtbl[16]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), dwEvents);
        }

        [VtblIndex(17)]
        [return: NativeTypeName("HRESULT")]
        public int SetEnterLeaveFunctionHooks([NativeTypeName("FunctionEnter *")] delegate* unmanaged[Stdcall]<ulong, void> pFuncEnter, [NativeTypeName("FunctionLeave *")] delegate* unmanaged[Stdcall]<ulong, void> pFuncLeave, [NativeTypeName("FunctionTailcall *")] delegate* unmanaged[Stdcall]<ulong, void> pFuncTailcall)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, delegate* unmanaged[Stdcall]<ulong, void>, delegate* unmanaged[Stdcall]<ulong, void>, delegate* unmanaged[Stdcall]<ulong, void>, int>)(lpVtbl[17]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), pFuncEnter, pFuncLeave, pFuncTailcall);
        }

        [VtblIndex(18)]
        [return: NativeTypeName("HRESULT")]
        public int SetFunctionIDMapper([NativeTypeName("FunctionIDMapper *")] delegate* unmanaged[Stdcall]<ulong, int*, ulong> pFunc)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, delegate* unmanaged[Stdcall]<ulong, int*, ulong>, int>)(lpVtbl[18]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), pFunc);
        }

        [VtblIndex(19)]
        [return: NativeTypeName("HRESULT")]
        public int GetTokenAndMetaDataFromFunction([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("const IID &")] Guid* riid, IUnknown** ppImport, [NativeTypeName("mdToken *")] uint* pToken)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, Guid*, IUnknown**, uint*, int>)(lpVtbl[19]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), functionId, riid, ppImport, pToken);
        }

        [VtblIndex(20)]
        [return: NativeTypeName("HRESULT")]
        public int GetModuleInfo([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("LPCBYTE *")] byte** ppBaseLoadAddress, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pcchName, [NativeTypeName("WCHAR[]")] ushort* szName, [NativeTypeName("AssemblyID *")] ulong* pAssemblyId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, byte**, uint, uint*, ushort*, ulong*, int>)(lpVtbl[20]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), moduleId, ppBaseLoadAddress, cchName, pcchName, szName, pAssemblyId);
        }

        [VtblIndex(21)]
        [return: NativeTypeName("HRESULT")]
        public int GetModuleMetaData([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("DWORD")] uint dwOpenFlags, [NativeTypeName("const IID &")] Guid* riid, IUnknown** ppOut)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, Guid*, IUnknown**, int>)(lpVtbl[21]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), moduleId, dwOpenFlags, riid, ppOut);
        }

        [VtblIndex(22)]
        [return: NativeTypeName("HRESULT")]
        public int GetILFunctionBody([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("mdMethodDef")] uint methodId, [NativeTypeName("LPCBYTE *")] byte** ppMethodHeader, [NativeTypeName("ULONG *")] uint* pcbMethodSize)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, byte**, uint*, int>)(lpVtbl[22]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), moduleId, methodId, ppMethodHeader, pcbMethodSize);
        }

        [VtblIndex(23)]
        [return: NativeTypeName("HRESULT")]
        public int GetILFunctionBodyAllocator([NativeTypeName("ModuleID")] ulong moduleId, IMethodMalloc** ppMalloc)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, IMethodMalloc**, int>)(lpVtbl[23]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), moduleId, ppMalloc);
        }

        [VtblIndex(24)]
        [return: NativeTypeName("HRESULT")]
        public int SetILFunctionBody([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("mdMethodDef")] uint methodid, [NativeTypeName("LPCBYTE")] byte* pbNewILMethodHeader)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, byte*, int>)(lpVtbl[24]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), moduleId, methodid, pbNewILMethodHeader);
        }

        [VtblIndex(25)]
        [return: NativeTypeName("HRESULT")]
        public int GetAppDomainInfo([NativeTypeName("AppDomainID")] ulong appDomainId, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pcchName, [NativeTypeName("WCHAR[]")] ushort* szName, [NativeTypeName("ProcessID *")] ulong* pProcessId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, uint*, ushort*, ulong*, int>)(lpVtbl[25]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), appDomainId, cchName, pcchName, szName, pProcessId);
        }

        [VtblIndex(26)]
        [return: NativeTypeName("HRESULT")]
        public int GetAssemblyInfo([NativeTypeName("AssemblyID")] ulong assemblyId, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pcchName, [NativeTypeName("WCHAR[]")] ushort* szName, [NativeTypeName("AppDomainID *")] ulong* pAppDomainId, [NativeTypeName("ModuleID *")] ulong* pModuleId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, uint*, ushort*, ulong*, ulong*, int>)(lpVtbl[26]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), assemblyId, cchName, pcchName, szName, pAppDomainId, pModuleId);
        }

        [VtblIndex(27)]
        [return: NativeTypeName("HRESULT")]
        public int SetFunctionReJIT([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, int>)(lpVtbl[27]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(28)]
        [return: NativeTypeName("HRESULT")]
        public int ForceGC()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, int>)(lpVtbl[28]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(29)]
        [return: NativeTypeName("HRESULT")]
        public int SetILInstrumentedCodeMap([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("BOOL")] int fStartJit, [NativeTypeName("ULONG")] uint cILMapEntries, [NativeTypeName("COR_IL_MAP[]")] COR_IL_MAP* rgILMapEntries)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, int, uint, COR_IL_MAP*, int>)(lpVtbl[29]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), functionId, fStartJit, cILMapEntries, rgILMapEntries);
        }

        [VtblIndex(30)]
        [return: NativeTypeName("HRESULT")]
        public int GetInprocInspectionInterface(IUnknown** ppicd)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, IUnknown**, int>)(lpVtbl[30]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), ppicd);
        }

        [VtblIndex(31)]
        [return: NativeTypeName("HRESULT")]
        public int GetInprocInspectionIThisThread(IUnknown** ppicd)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, IUnknown**, int>)(lpVtbl[31]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), ppicd);
        }

        [VtblIndex(32)]
        [return: NativeTypeName("HRESULT")]
        public int GetThreadContext([NativeTypeName("ThreadID")] ulong threadId, [NativeTypeName("ContextID *")] ulong* pContextId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ulong*, int>)(lpVtbl[32]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), threadId, pContextId);
        }

        [VtblIndex(33)]
        [return: NativeTypeName("HRESULT")]
        public int BeginInprocDebugging([NativeTypeName("BOOL")] int fThisThreadOnly, [NativeTypeName("DWORD *")] uint* pdwProfilerContext)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, int, uint*, int>)(lpVtbl[33]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), fThisThreadOnly, pdwProfilerContext);
        }

        [VtblIndex(34)]
        [return: NativeTypeName("HRESULT")]
        public int EndInprocDebugging([NativeTypeName("DWORD")] uint dwProfilerContext)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, uint, int>)(lpVtbl[34]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), dwProfilerContext);
        }

        [VtblIndex(35)]
        [return: NativeTypeName("HRESULT")]
        public int GetILToNativeMapping([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("ULONG32")] uint cMap, [NativeTypeName("ULONG32 *")] uint* pcMap, [NativeTypeName("COR_DEBUG_IL_TO_NATIVE_MAP[]")] COR_DEBUG_IL_TO_NATIVE_MAP* map)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, uint*, COR_DEBUG_IL_TO_NATIVE_MAP*, int>)(lpVtbl[35]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), functionId, cMap, pcMap, map);
        }

        [VtblIndex(36)]
        [return: NativeTypeName("HRESULT")]
        public int DoStackSnapshot([NativeTypeName("ThreadID")] ulong thread, [NativeTypeName("StackSnapshotCallback *")] delegate* unmanaged[Stdcall]<ulong, ulong, ulong, uint, byte*, void*, int> callback, [NativeTypeName("ULONG32")] uint infoFlags, void* clientData, [NativeTypeName("BYTE[]")] byte* context, [NativeTypeName("ULONG32")] uint contextSize)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, delegate* unmanaged[Stdcall]<ulong, ulong, ulong, uint, byte*, void*, int>, uint, void*, byte*, uint, int>)(lpVtbl[36]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), thread, callback, infoFlags, clientData, context, contextSize);
        }

        [VtblIndex(37)]
        [return: NativeTypeName("HRESULT")]
        public int SetEnterLeaveFunctionHooks2([NativeTypeName("FunctionEnter2 *")] delegate* unmanaged[Stdcall]<ulong, ulong, ulong, COR_PRF_FUNCTION_ARGUMENT_INFO*, void> pFuncEnter, [NativeTypeName("FunctionLeave2 *")] delegate* unmanaged[Stdcall]<ulong, ulong, ulong, COR_PRF_FUNCTION_ARGUMENT_RANGE*, void> pFuncLeave, [NativeTypeName("FunctionTailcall2 *")] delegate* unmanaged[Stdcall]<ulong, ulong, ulong, void> pFuncTailcall)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, delegate* unmanaged[Stdcall]<ulong, ulong, ulong, COR_PRF_FUNCTION_ARGUMENT_INFO*, void>, delegate* unmanaged[Stdcall]<ulong, ulong, ulong, COR_PRF_FUNCTION_ARGUMENT_RANGE*, void>, delegate* unmanaged[Stdcall]<ulong, ulong, ulong, void>, int>)(lpVtbl[37]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), pFuncEnter, pFuncLeave, pFuncTailcall);
        }

        [VtblIndex(38)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionInfo2([NativeTypeName("FunctionID")] ulong funcId, [NativeTypeName("COR_PRF_FRAME_INFO")] ulong frameInfo, [NativeTypeName("ClassID *")] ulong* pClassId, [NativeTypeName("ModuleID *")] ulong* pModuleId, [NativeTypeName("mdToken *")] uint* pToken, [NativeTypeName("ULONG32")] uint cTypeArgs, [NativeTypeName("ULONG32 *")] uint* pcTypeArgs, [NativeTypeName("ClassID[]")] ulong* typeArgs)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ulong, ulong*, ulong*, uint*, uint, uint*, ulong*, int>)(lpVtbl[38]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), funcId, frameInfo, pClassId, pModuleId, pToken, cTypeArgs, pcTypeArgs, typeArgs);
        }

        [VtblIndex(39)]
        [return: NativeTypeName("HRESULT")]
        public int GetStringLayout([NativeTypeName("ULONG *")] uint* pBufferLengthOffset, [NativeTypeName("ULONG *")] uint* pStringLengthOffset, [NativeTypeName("ULONG *")] uint* pBufferOffset)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, uint*, uint*, uint*, int>)(lpVtbl[39]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), pBufferLengthOffset, pStringLengthOffset, pBufferOffset);
        }

        [VtblIndex(40)]
        [return: NativeTypeName("HRESULT")]
        public int GetClassLayout([NativeTypeName("ClassID")] ulong classID, [NativeTypeName("COR_FIELD_OFFSET[]")] COR_FIELD_OFFSET* rFieldOffset, [NativeTypeName("ULONG")] uint cFieldOffset, [NativeTypeName("ULONG *")] uint* pcFieldOffset, [NativeTypeName("ULONG *")] uint* pulClassSize)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, COR_FIELD_OFFSET*, uint, uint*, uint*, int>)(lpVtbl[40]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), classID, rFieldOffset, cFieldOffset, pcFieldOffset, pulClassSize);
        }

        [VtblIndex(41)]
        [return: NativeTypeName("HRESULT")]
        public int GetClassIDInfo2([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("ModuleID *")] ulong* pModuleId, [NativeTypeName("mdTypeDef *")] uint* pTypeDefToken, [NativeTypeName("ClassID *")] ulong* pParentClassId, [NativeTypeName("ULONG32")] uint cNumTypeArgs, [NativeTypeName("ULONG32 *")] uint* pcNumTypeArgs, [NativeTypeName("ClassID[]")] ulong* typeArgs)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ulong*, uint*, ulong*, uint, uint*, ulong*, int>)(lpVtbl[41]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), classId, pModuleId, pTypeDefToken, pParentClassId, cNumTypeArgs, pcNumTypeArgs, typeArgs);
        }

        [VtblIndex(42)]
        [return: NativeTypeName("HRESULT")]
        public int GetCodeInfo2([NativeTypeName("FunctionID")] ulong functionID, [NativeTypeName("ULONG32")] uint cCodeInfos, [NativeTypeName("ULONG32 *")] uint* pcCodeInfos, [NativeTypeName("COR_PRF_CODE_INFO[]")] COR_PRF_CODE_INFO* codeInfos)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, uint*, COR_PRF_CODE_INFO*, int>)(lpVtbl[42]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), functionID, cCodeInfos, pcCodeInfos, codeInfos);
        }

        [VtblIndex(43)]
        [return: NativeTypeName("HRESULT")]
        public int GetClassFromTokenAndTypeArgs([NativeTypeName("ModuleID")] ulong moduleID, [NativeTypeName("mdTypeDef")] uint typeDef, [NativeTypeName("ULONG32")] uint cTypeArgs, [NativeTypeName("ClassID[]")] ulong* typeArgs, [NativeTypeName("ClassID *")] ulong* pClassID)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, uint, ulong*, ulong*, int>)(lpVtbl[43]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), moduleID, typeDef, cTypeArgs, typeArgs, pClassID);
        }

        [VtblIndex(44)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionFromTokenAndTypeArgs([NativeTypeName("ModuleID")] ulong moduleID, [NativeTypeName("mdMethodDef")] uint funcDef, [NativeTypeName("ClassID")] ulong classId, [NativeTypeName("ULONG32")] uint cTypeArgs, [NativeTypeName("ClassID[]")] ulong* typeArgs, [NativeTypeName("FunctionID *")] ulong* pFunctionID)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, ulong, uint, ulong*, ulong*, int>)(lpVtbl[44]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), moduleID, funcDef, classId, cTypeArgs, typeArgs, pFunctionID);
        }

        [VtblIndex(45)]
        [return: NativeTypeName("HRESULT")]
        public int EnumModuleFrozenObjects([NativeTypeName("ModuleID")] ulong moduleID, ICorProfilerObjectEnum** ppEnum)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ICorProfilerObjectEnum**, int>)(lpVtbl[45]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), moduleID, ppEnum);
        }

        [VtblIndex(46)]
        [return: NativeTypeName("HRESULT")]
        public int GetArrayObjectInfo([NativeTypeName("ObjectID")] ulong objectId, [NativeTypeName("ULONG32")] uint cDimensions, [NativeTypeName("ULONG32[]")] uint* pDimensionSizes, [NativeTypeName("int[]")] int* pDimensionLowerBounds, byte** ppData)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, uint*, int*, byte**, int>)(lpVtbl[46]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), objectId, cDimensions, pDimensionSizes, pDimensionLowerBounds, ppData);
        }

        [VtblIndex(47)]
        [return: NativeTypeName("HRESULT")]
        public int GetBoxClassLayout([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("ULONG32 *")] uint* pBufferOffset)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint*, int>)(lpVtbl[47]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), classId, pBufferOffset);
        }

        [VtblIndex(48)]
        [return: NativeTypeName("HRESULT")]
        public int GetThreadAppDomain([NativeTypeName("ThreadID")] ulong threadId, [NativeTypeName("AppDomainID *")] ulong* pAppDomainId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ulong*, int>)(lpVtbl[48]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), threadId, pAppDomainId);
        }

        [VtblIndex(49)]
        [return: NativeTypeName("HRESULT")]
        public int GetRVAStaticAddress([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("mdFieldDef")] uint fieldToken, void** ppAddress)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, void**, int>)(lpVtbl[49]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), classId, fieldToken, ppAddress);
        }

        [VtblIndex(50)]
        [return: NativeTypeName("HRESULT")]
        public int GetAppDomainStaticAddress([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("mdFieldDef")] uint fieldToken, [NativeTypeName("AppDomainID")] ulong appDomainId, void** ppAddress)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, ulong, void**, int>)(lpVtbl[50]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), classId, fieldToken, appDomainId, ppAddress);
        }

        [VtblIndex(51)]
        [return: NativeTypeName("HRESULT")]
        public int GetThreadStaticAddress([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("mdFieldDef")] uint fieldToken, [NativeTypeName("ThreadID")] ulong threadId, void** ppAddress)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, ulong, void**, int>)(lpVtbl[51]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), classId, fieldToken, threadId, ppAddress);
        }

        [VtblIndex(52)]
        [return: NativeTypeName("HRESULT")]
        public int GetContextStaticAddress([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("mdFieldDef")] uint fieldToken, [NativeTypeName("ContextID")] ulong contextId, void** ppAddress)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, ulong, void**, int>)(lpVtbl[52]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), classId, fieldToken, contextId, ppAddress);
        }

        [VtblIndex(53)]
        [return: NativeTypeName("HRESULT")]
        public int GetStaticFieldInfo([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("mdFieldDef")] uint fieldToken, COR_PRF_STATIC_TYPE* pFieldInfo)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, COR_PRF_STATIC_TYPE*, int>)(lpVtbl[53]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), classId, fieldToken, pFieldInfo);
        }

        [VtblIndex(54)]
        [return: NativeTypeName("HRESULT")]
        public int GetGenerationBounds([NativeTypeName("ULONG")] uint cObjectRanges, [NativeTypeName("ULONG *")] uint* pcObjectRanges, [NativeTypeName("COR_PRF_GC_GENERATION_RANGE[]")] COR_PRF_GC_GENERATION_RANGE* ranges)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, uint, uint*, COR_PRF_GC_GENERATION_RANGE*, int>)(lpVtbl[54]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), cObjectRanges, pcObjectRanges, ranges);
        }

        [VtblIndex(55)]
        [return: NativeTypeName("HRESULT")]
        public int GetObjectGeneration([NativeTypeName("ObjectID")] ulong objectId, COR_PRF_GC_GENERATION_RANGE* range)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, COR_PRF_GC_GENERATION_RANGE*, int>)(lpVtbl[55]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), objectId, range);
        }

        [VtblIndex(56)]
        [return: NativeTypeName("HRESULT")]
        public int GetNotifiedExceptionClauseInfo(COR_PRF_EX_CLAUSE_INFO* pinfo)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, COR_PRF_EX_CLAUSE_INFO*, int>)(lpVtbl[56]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), pinfo);
        }

        [VtblIndex(57)]
        [return: NativeTypeName("HRESULT")]
        public int EnumJITedFunctions(ICorProfilerFunctionEnum** ppEnum)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ICorProfilerFunctionEnum**, int>)(lpVtbl[57]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), ppEnum);
        }

        [VtblIndex(58)]
        [return: NativeTypeName("HRESULT")]
        public int RequestProfilerDetach([NativeTypeName("DWORD")] uint dwExpectedCompletionMilliseconds)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, uint, int>)(lpVtbl[58]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), dwExpectedCompletionMilliseconds);
        }

        [VtblIndex(59)]
        [return: NativeTypeName("HRESULT")]
        public int SetFunctionIDMapper2([NativeTypeName("FunctionIDMapper2 *")] delegate* unmanaged[Stdcall]<ulong, void*, int*, ulong> pFunc, void* clientData)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, delegate* unmanaged[Stdcall]<ulong, void*, int*, ulong>, void*, int>)(lpVtbl[59]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), pFunc, clientData);
        }

        [VtblIndex(60)]
        [return: NativeTypeName("HRESULT")]
        public int GetStringLayout2([NativeTypeName("ULONG *")] uint* pStringLengthOffset, [NativeTypeName("ULONG *")] uint* pBufferOffset)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, uint*, uint*, int>)(lpVtbl[60]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), pStringLengthOffset, pBufferOffset);
        }

        [VtblIndex(61)]
        [return: NativeTypeName("HRESULT")]
        public int SetEnterLeaveFunctionHooks3([NativeTypeName("FunctionEnter3 *")] delegate* unmanaged[Stdcall]<FunctionIDOrClientID, void> pFuncEnter3, [NativeTypeName("FunctionLeave3 *")] delegate* unmanaged[Stdcall]<FunctionIDOrClientID, void> pFuncLeave3, [NativeTypeName("FunctionTailcall3 *")] delegate* unmanaged[Stdcall]<FunctionIDOrClientID, void> pFuncTailcall3)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, delegate* unmanaged[Stdcall]<FunctionIDOrClientID, void>, delegate* unmanaged[Stdcall]<FunctionIDOrClientID, void>, delegate* unmanaged[Stdcall]<FunctionIDOrClientID, void>, int>)(lpVtbl[61]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), pFuncEnter3, pFuncLeave3, pFuncTailcall3);
        }

        [VtblIndex(62)]
        [return: NativeTypeName("HRESULT")]
        public int SetEnterLeaveFunctionHooks3WithInfo([NativeTypeName("FunctionEnter3WithInfo *")] delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void> pFuncEnter3WithInfo, [NativeTypeName("FunctionLeave3WithInfo *")] delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void> pFuncLeave3WithInfo, [NativeTypeName("FunctionTailcall3WithInfo *")] delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void> pFuncTailcall3WithInfo)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void>, delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void>, delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void>, int>)(lpVtbl[62]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), pFuncEnter3WithInfo, pFuncLeave3WithInfo, pFuncTailcall3WithInfo);
        }

        [VtblIndex(63)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionEnter3Info([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("COR_PRF_ELT_INFO")] ulong eltInfo, [NativeTypeName("COR_PRF_FRAME_INFO *")] ulong* pFrameInfo, [NativeTypeName("ULONG *")] uint* pcbArgumentInfo, COR_PRF_FUNCTION_ARGUMENT_INFO* pArgumentInfo)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ulong, ulong*, uint*, COR_PRF_FUNCTION_ARGUMENT_INFO*, int>)(lpVtbl[63]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), functionId, eltInfo, pFrameInfo, pcbArgumentInfo, pArgumentInfo);
        }

        [VtblIndex(64)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionLeave3Info([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("COR_PRF_ELT_INFO")] ulong eltInfo, [NativeTypeName("COR_PRF_FRAME_INFO *")] ulong* pFrameInfo, COR_PRF_FUNCTION_ARGUMENT_RANGE* pRetvalRange)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ulong, ulong*, COR_PRF_FUNCTION_ARGUMENT_RANGE*, int>)(lpVtbl[64]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), functionId, eltInfo, pFrameInfo, pRetvalRange);
        }

        [VtblIndex(65)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionTailcall3Info([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("COR_PRF_ELT_INFO")] ulong eltInfo, [NativeTypeName("COR_PRF_FRAME_INFO *")] ulong* pFrameInfo)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ulong, ulong*, int>)(lpVtbl[65]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), functionId, eltInfo, pFrameInfo);
        }

        [VtblIndex(66)]
        [return: NativeTypeName("HRESULT")]
        public int EnumModules(ICorProfilerModuleEnum** ppEnum)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ICorProfilerModuleEnum**, int>)(lpVtbl[66]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), ppEnum);
        }

        [VtblIndex(67)]
        [return: NativeTypeName("HRESULT")]
        public int GetRuntimeInformation(ushort* pClrInstanceId, COR_PRF_RUNTIME_TYPE* pRuntimeType, ushort* pMajorVersion, ushort* pMinorVersion, ushort* pBuildNumber, ushort* pQFEVersion, [NativeTypeName("ULONG")] uint cchVersionString, [NativeTypeName("ULONG *")] uint* pcchVersionString, [NativeTypeName("WCHAR[]")] ushort* szVersionString)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ushort*, COR_PRF_RUNTIME_TYPE*, ushort*, ushort*, ushort*, ushort*, uint, uint*, ushort*, int>)(lpVtbl[67]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), pClrInstanceId, pRuntimeType, pMajorVersion, pMinorVersion, pBuildNumber, pQFEVersion, cchVersionString, pcchVersionString, szVersionString);
        }

        [VtblIndex(68)]
        [return: NativeTypeName("HRESULT")]
        public int GetThreadStaticAddress2([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("mdFieldDef")] uint fieldToken, [NativeTypeName("AppDomainID")] ulong appDomainId, [NativeTypeName("ThreadID")] ulong threadId, void** ppAddress)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, ulong, ulong, void**, int>)(lpVtbl[68]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), classId, fieldToken, appDomainId, threadId, ppAddress);
        }

        [VtblIndex(69)]
        [return: NativeTypeName("HRESULT")]
        public int GetAppDomainsContainingModule([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("ULONG32")] uint cAppDomainIds, [NativeTypeName("ULONG32 *")] uint* pcAppDomainIds, [NativeTypeName("AppDomainID[]")] ulong* appDomainIds)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, uint*, ulong*, int>)(lpVtbl[69]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), moduleId, cAppDomainIds, pcAppDomainIds, appDomainIds);
        }

        [VtblIndex(70)]
        [return: NativeTypeName("HRESULT")]
        public int GetModuleInfo2([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("LPCBYTE *")] byte** ppBaseLoadAddress, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pcchName, [NativeTypeName("WCHAR[]")] ushort* szName, [NativeTypeName("AssemblyID *")] ulong* pAssemblyId, [NativeTypeName("DWORD *")] uint* pdwModuleFlags)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, byte**, uint, uint*, ushort*, ulong*, uint*, int>)(lpVtbl[70]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), moduleId, ppBaseLoadAddress, cchName, pcchName, szName, pAssemblyId, pdwModuleFlags);
        }

        [VtblIndex(71)]
        [return: NativeTypeName("HRESULT")]
        public int EnumThreads(ICorProfilerThreadEnum** ppEnum)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ICorProfilerThreadEnum**, int>)(lpVtbl[71]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), ppEnum);
        }

        [VtblIndex(72)]
        [return: NativeTypeName("HRESULT")]
        public int InitializeCurrentThread()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, int>)(lpVtbl[72]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(73)]
        [return: NativeTypeName("HRESULT")]
        public int RequestReJIT([NativeTypeName("ULONG")] uint cFunctions, [NativeTypeName("ModuleID[]")] ulong* moduleIds, [NativeTypeName("mdMethodDef[]")] uint* methodIds)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, uint, ulong*, uint*, int>)(lpVtbl[73]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), cFunctions, moduleIds, methodIds);
        }

        [VtblIndex(74)]
        [return: NativeTypeName("HRESULT")]
        public int RequestRevert([NativeTypeName("ULONG")] uint cFunctions, [NativeTypeName("ModuleID[]")] ulong* moduleIds, [NativeTypeName("mdMethodDef[]")] uint* methodIds, [NativeTypeName("HRESULT[]")] int* status)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, uint, ulong*, uint*, int*, int>)(lpVtbl[74]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), cFunctions, moduleIds, methodIds, status);
        }

        [VtblIndex(75)]
        [return: NativeTypeName("HRESULT")]
        public int GetCodeInfo3([NativeTypeName("FunctionID")] ulong functionID, [NativeTypeName("ReJITID")] ulong reJitId, [NativeTypeName("ULONG32")] uint cCodeInfos, [NativeTypeName("ULONG32 *")] uint* pcCodeInfos, [NativeTypeName("COR_PRF_CODE_INFO[]")] COR_PRF_CODE_INFO* codeInfos)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ulong, uint, uint*, COR_PRF_CODE_INFO*, int>)(lpVtbl[75]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), functionID, reJitId, cCodeInfos, pcCodeInfos, codeInfos);
        }

        [VtblIndex(76)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionFromIP2([NativeTypeName("LPCBYTE")] byte* ip, [NativeTypeName("FunctionID *")] ulong* pFunctionId, [NativeTypeName("ReJITID *")] ulong* pReJitId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, byte*, ulong*, ulong*, int>)(lpVtbl[76]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), ip, pFunctionId, pReJitId);
        }

        [VtblIndex(77)]
        [return: NativeTypeName("HRESULT")]
        public int GetReJITIDs([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("ULONG")] uint cReJitIds, [NativeTypeName("ULONG *")] uint* pcReJitIds, [NativeTypeName("ReJITID[]")] ulong* reJitIds)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, uint*, ulong*, int>)(lpVtbl[77]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), functionId, cReJitIds, pcReJitIds, reJitIds);
        }

        [VtblIndex(78)]
        [return: NativeTypeName("HRESULT")]
        public int GetILToNativeMapping2([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("ReJITID")] ulong reJitId, [NativeTypeName("ULONG32")] uint cMap, [NativeTypeName("ULONG32 *")] uint* pcMap, [NativeTypeName("COR_DEBUG_IL_TO_NATIVE_MAP[]")] COR_DEBUG_IL_TO_NATIVE_MAP* map)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ulong, uint, uint*, COR_DEBUG_IL_TO_NATIVE_MAP*, int>)(lpVtbl[78]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), functionId, reJitId, cMap, pcMap, map);
        }

        [VtblIndex(79)]
        [return: NativeTypeName("HRESULT")]
        public int EnumJITedFunctions2(ICorProfilerFunctionEnum** ppEnum)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ICorProfilerFunctionEnum**, int>)(lpVtbl[79]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), ppEnum);
        }

        [VtblIndex(80)]
        [return: NativeTypeName("HRESULT")]
        public int GetObjectSize2([NativeTypeName("ObjectID")] ulong objectId, [NativeTypeName("SIZE_T *")] ulong* pcSize)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ulong*, int>)(lpVtbl[80]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), objectId, pcSize);
        }

        [VtblIndex(81)]
        [return: NativeTypeName("HRESULT")]
        public int GetEventMask2([NativeTypeName("DWORD *")] uint* pdwEventsLow, [NativeTypeName("DWORD *")] uint* pdwEventsHigh)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, uint*, uint*, int>)(lpVtbl[81]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), pdwEventsLow, pdwEventsHigh);
        }

        [VtblIndex(82)]
        [return: NativeTypeName("HRESULT")]
        public int SetEventMask2([NativeTypeName("DWORD")] uint dwEventsLow, [NativeTypeName("DWORD")] uint dwEventsHigh)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, uint, uint, int>)(lpVtbl[82]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), dwEventsLow, dwEventsHigh);
        }

        [VtblIndex(83)]
        [return: NativeTypeName("HRESULT")]
        public int EnumNgenModuleMethodsInliningThisMethod([NativeTypeName("ModuleID")] ulong inlinersModuleId, [NativeTypeName("ModuleID")] ulong inlineeModuleId, [NativeTypeName("mdMethodDef")] uint inlineeMethodId, [NativeTypeName("BOOL *")] int* incompleteData, ICorProfilerMethodEnum** ppEnum)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ulong, uint, int*, ICorProfilerMethodEnum**, int>)(lpVtbl[83]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), inlinersModuleId, inlineeModuleId, inlineeMethodId, incompleteData, ppEnum);
        }

        [VtblIndex(84)]
        [return: NativeTypeName("HRESULT")]
        public int ApplyMetaData([NativeTypeName("ModuleID")] ulong moduleId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, int>)(lpVtbl[84]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), moduleId);
        }

        [VtblIndex(85)]
        [return: NativeTypeName("HRESULT")]
        public int GetInMemorySymbolsLength([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("DWORD *")] uint* pCountSymbolBytes)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint*, int>)(lpVtbl[85]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), moduleId, pCountSymbolBytes);
        }

        [VtblIndex(86)]
        [return: NativeTypeName("HRESULT")]
        public int ReadInMemorySymbols([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("DWORD")] uint symbolsReadOffset, byte* pSymbolBytes, [NativeTypeName("DWORD")] uint countSymbolBytes, [NativeTypeName("DWORD *")] uint* pCountSymbolBytesRead)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, byte*, uint, uint*, int>)(lpVtbl[86]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), moduleId, symbolsReadOffset, pSymbolBytes, countSymbolBytes, pCountSymbolBytesRead);
        }

        [VtblIndex(87)]
        [return: NativeTypeName("HRESULT")]
        public int IsFunctionDynamic([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("BOOL *")] int* isDynamic)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, int*, int>)(lpVtbl[87]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), functionId, isDynamic);
        }

        [VtblIndex(88)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionFromIP3([NativeTypeName("LPCBYTE")] byte* ip, [NativeTypeName("FunctionID *")] ulong* functionId, [NativeTypeName("ReJITID *")] ulong* pReJitId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, byte*, ulong*, ulong*, int>)(lpVtbl[88]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), ip, functionId, pReJitId);
        }

        [VtblIndex(89)]
        [return: NativeTypeName("HRESULT")]
        public int GetDynamicFunctionInfo([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("ModuleID *")] ulong* moduleId, [NativeTypeName("PCCOR_SIGNATURE *")] byte** ppvSig, [NativeTypeName("ULONG *")] uint* pbSig, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pcchName, [NativeTypeName("WCHAR[]")] ushort* wszName)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ulong*, byte**, uint*, uint, uint*, ushort*, int>)(lpVtbl[89]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), functionId, moduleId, ppvSig, pbSig, cchName, pcchName, wszName);
        }

        [VtblIndex(90)]
        [return: NativeTypeName("HRESULT")]
        public int GetNativeCodeStartAddresses([NativeTypeName("FunctionID")] ulong functionID, [NativeTypeName("ReJITID")] ulong reJitId, [NativeTypeName("ULONG32")] uint cCodeStartAddresses, [NativeTypeName("ULONG32 *")] uint* pcCodeStartAddresses, [NativeTypeName("UINT_PTR[]")] ulong* codeStartAddresses)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, ulong, uint, uint*, ulong*, int>)(lpVtbl[90]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), functionID, reJitId, cCodeStartAddresses, pcCodeStartAddresses, codeStartAddresses);
        }

        [VtblIndex(91)]
        [return: NativeTypeName("HRESULT")]
        public int GetILToNativeMapping3([NativeTypeName("UINT_PTR")] ulong pNativeCodeStartAddress, [NativeTypeName("ULONG32")] uint cMap, [NativeTypeName("ULONG32 *")] uint* pcMap, [NativeTypeName("COR_DEBUG_IL_TO_NATIVE_MAP[]")] COR_DEBUG_IL_TO_NATIVE_MAP* map)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, uint*, COR_DEBUG_IL_TO_NATIVE_MAP*, int>)(lpVtbl[91]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), pNativeCodeStartAddress, cMap, pcMap, map);
        }

        [VtblIndex(92)]
        [return: NativeTypeName("HRESULT")]
        public int GetCodeInfo4([NativeTypeName("UINT_PTR")] ulong pNativeCodeStartAddress, [NativeTypeName("ULONG32")] uint cCodeInfos, [NativeTypeName("ULONG32 *")] uint* pcCodeInfos, [NativeTypeName("COR_PRF_CODE_INFO[]")] COR_PRF_CODE_INFO* codeInfos)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo9*, ulong, uint, uint*, COR_PRF_CODE_INFO*, int>)(lpVtbl[92]))((ICorProfilerInfo9*)Unsafe.AsPointer(ref this), pNativeCodeStartAddress, cCodeInfos, pcCodeInfos, codeInfos);
        }
    }
}
