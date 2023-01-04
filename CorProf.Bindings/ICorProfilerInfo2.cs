using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    [Guid("CC0935CD-A518-487D-B0BB-A93214E65478")]
    [NativeTypeName("struct ICorProfilerInfo2 : ICorProfilerInfo")]
    public unsafe partial struct ICorProfilerInfo2
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, Guid*, void**, int>)(lpVtbl[0]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, uint>)(lpVtbl[1]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, uint>)(lpVtbl[2]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int GetClassFromObject([NativeTypeName("ObjectID")] ulong objectId, [NativeTypeName("ClassID *")] ulong* pClassId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, ulong*, int>)(lpVtbl[3]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), objectId, pClassId);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int GetClassFromToken([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("mdTypeDef")] uint typeDef, [NativeTypeName("ClassID *")] ulong* pClassId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, ulong*, int>)(lpVtbl[4]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), moduleId, typeDef, pClassId);
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int GetCodeInfo([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("LPCBYTE *")] byte** pStart, [NativeTypeName("ULONG *")] uint* pcSize)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, byte**, uint*, int>)(lpVtbl[5]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), functionId, pStart, pcSize);
        }

        [VtblIndex(6)]
        [return: NativeTypeName("HRESULT")]
        public int GetEventMask([NativeTypeName("DWORD *")] uint* pdwEvents)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, uint*, int>)(lpVtbl[6]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), pdwEvents);
        }

        [VtblIndex(7)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionFromIP([NativeTypeName("LPCBYTE")] byte* ip, [NativeTypeName("FunctionID *")] ulong* pFunctionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, byte*, ulong*, int>)(lpVtbl[7]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), ip, pFunctionId);
        }

        [VtblIndex(8)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionFromToken([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("mdToken")] uint token, [NativeTypeName("FunctionID *")] ulong* pFunctionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, ulong*, int>)(lpVtbl[8]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), moduleId, token, pFunctionId);
        }

        [VtblIndex(9)]
        [return: NativeTypeName("HRESULT")]
        public int GetHandleFromThread([NativeTypeName("ThreadID")] ulong threadId, [NativeTypeName("HANDLE *")] void** phThread)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, void**, int>)(lpVtbl[9]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), threadId, phThread);
        }

        [VtblIndex(10)]
        [return: NativeTypeName("HRESULT")]
        public int GetObjectSize([NativeTypeName("ObjectID")] ulong objectId, [NativeTypeName("ULONG *")] uint* pcSize)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint*, int>)(lpVtbl[10]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), objectId, pcSize);
        }

        [VtblIndex(11)]
        [return: NativeTypeName("HRESULT")]
        public int IsArrayClass([NativeTypeName("ClassID")] ulong classId, CorElementType* pBaseElemType, [NativeTypeName("ClassID *")] ulong* pBaseClassId, [NativeTypeName("ULONG *")] uint* pcRank)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, CorElementType*, ulong*, uint*, int>)(lpVtbl[11]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), classId, pBaseElemType, pBaseClassId, pcRank);
        }

        [VtblIndex(12)]
        [return: NativeTypeName("HRESULT")]
        public int GetThreadInfo([NativeTypeName("ThreadID")] ulong threadId, [NativeTypeName("DWORD *")] uint* pdwWin32ThreadId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint*, int>)(lpVtbl[12]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), threadId, pdwWin32ThreadId);
        }

        [VtblIndex(13)]
        [return: NativeTypeName("HRESULT")]
        public int GetCurrentThreadID([NativeTypeName("ThreadID *")] ulong* pThreadId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong*, int>)(lpVtbl[13]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), pThreadId);
        }

        [VtblIndex(14)]
        [return: NativeTypeName("HRESULT")]
        public int GetClassIDInfo([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("ModuleID *")] ulong* pModuleId, [NativeTypeName("mdTypeDef *")] uint* pTypeDefToken)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, ulong*, uint*, int>)(lpVtbl[14]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), classId, pModuleId, pTypeDefToken);
        }

        [VtblIndex(15)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionInfo([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("ClassID *")] ulong* pClassId, [NativeTypeName("ModuleID *")] ulong* pModuleId, [NativeTypeName("mdToken *")] uint* pToken)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, ulong*, ulong*, uint*, int>)(lpVtbl[15]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), functionId, pClassId, pModuleId, pToken);
        }

        [VtblIndex(16)]
        [return: NativeTypeName("HRESULT")]
        public int SetEventMask([NativeTypeName("DWORD")] uint dwEvents)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, uint, int>)(lpVtbl[16]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), dwEvents);
        }

        [VtblIndex(17)]
        [return: NativeTypeName("HRESULT")]
        public int SetEnterLeaveFunctionHooks([NativeTypeName("FunctionEnter *")] delegate* unmanaged[Stdcall]<ulong, void> pFuncEnter, [NativeTypeName("FunctionLeave *")] delegate* unmanaged[Stdcall]<ulong, void> pFuncLeave, [NativeTypeName("FunctionTailcall *")] delegate* unmanaged[Stdcall]<ulong, void> pFuncTailcall)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, delegate* unmanaged[Stdcall]<ulong, void>, delegate* unmanaged[Stdcall]<ulong, void>, delegate* unmanaged[Stdcall]<ulong, void>, int>)(lpVtbl[17]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), pFuncEnter, pFuncLeave, pFuncTailcall);
        }

        [VtblIndex(18)]
        [return: NativeTypeName("HRESULT")]
        public int SetFunctionIDMapper([NativeTypeName("FunctionIDMapper *")] delegate* unmanaged[Stdcall]<ulong, int*, ulong> pFunc)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, delegate* unmanaged[Stdcall]<ulong, int*, ulong>, int>)(lpVtbl[18]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), pFunc);
        }

        [VtblIndex(19)]
        [return: NativeTypeName("HRESULT")]
        public int GetTokenAndMetaDataFromFunction([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("const IID &")] Guid* riid, IUnknown** ppImport, [NativeTypeName("mdToken *")] uint* pToken)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, Guid*, IUnknown**, uint*, int>)(lpVtbl[19]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), functionId, riid, ppImport, pToken);
        }

        [VtblIndex(20)]
        [return: NativeTypeName("HRESULT")]
        public int GetModuleInfo([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("LPCBYTE *")] byte** ppBaseLoadAddress, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pcchName, [NativeTypeName("WCHAR[]")] ushort* szName, [NativeTypeName("AssemblyID *")] ulong* pAssemblyId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, byte**, uint, uint*, ushort*, ulong*, int>)(lpVtbl[20]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), moduleId, ppBaseLoadAddress, cchName, pcchName, szName, pAssemblyId);
        }

        [VtblIndex(21)]
        [return: NativeTypeName("HRESULT")]
        public int GetModuleMetaData([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("DWORD")] uint dwOpenFlags, [NativeTypeName("const IID &")] Guid* riid, IUnknown** ppOut)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, Guid*, IUnknown**, int>)(lpVtbl[21]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), moduleId, dwOpenFlags, riid, ppOut);
        }

        [VtblIndex(22)]
        [return: NativeTypeName("HRESULT")]
        public int GetILFunctionBody([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("mdMethodDef")] uint methodId, [NativeTypeName("LPCBYTE *")] byte** ppMethodHeader, [NativeTypeName("ULONG *")] uint* pcbMethodSize)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, byte**, uint*, int>)(lpVtbl[22]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), moduleId, methodId, ppMethodHeader, pcbMethodSize);
        }

        [VtblIndex(23)]
        [return: NativeTypeName("HRESULT")]
        public int GetILFunctionBodyAllocator([NativeTypeName("ModuleID")] ulong moduleId, IMethodMalloc** ppMalloc)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, IMethodMalloc**, int>)(lpVtbl[23]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), moduleId, ppMalloc);
        }

        [VtblIndex(24)]
        [return: NativeTypeName("HRESULT")]
        public int SetILFunctionBody([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("mdMethodDef")] uint methodid, [NativeTypeName("LPCBYTE")] byte* pbNewILMethodHeader)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, byte*, int>)(lpVtbl[24]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), moduleId, methodid, pbNewILMethodHeader);
        }

        [VtblIndex(25)]
        [return: NativeTypeName("HRESULT")]
        public int GetAppDomainInfo([NativeTypeName("AppDomainID")] ulong appDomainId, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pcchName, [NativeTypeName("WCHAR[]")] ushort* szName, [NativeTypeName("ProcessID *")] ulong* pProcessId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, uint*, ushort*, ulong*, int>)(lpVtbl[25]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), appDomainId, cchName, pcchName, szName, pProcessId);
        }

        [VtblIndex(26)]
        [return: NativeTypeName("HRESULT")]
        public int GetAssemblyInfo([NativeTypeName("AssemblyID")] ulong assemblyId, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pcchName, [NativeTypeName("WCHAR[]")] ushort* szName, [NativeTypeName("AppDomainID *")] ulong* pAppDomainId, [NativeTypeName("ModuleID *")] ulong* pModuleId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, uint*, ushort*, ulong*, ulong*, int>)(lpVtbl[26]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), assemblyId, cchName, pcchName, szName, pAppDomainId, pModuleId);
        }

        [VtblIndex(27)]
        [return: NativeTypeName("HRESULT")]
        public int SetFunctionReJIT([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, int>)(lpVtbl[27]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(28)]
        [return: NativeTypeName("HRESULT")]
        public int ForceGC()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, int>)(lpVtbl[28]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(29)]
        [return: NativeTypeName("HRESULT")]
        public int SetILInstrumentedCodeMap([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("BOOL")] int fStartJit, [NativeTypeName("ULONG")] uint cILMapEntries, [NativeTypeName("COR_IL_MAP[]")] COR_IL_MAP* rgILMapEntries)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, int, uint, COR_IL_MAP*, int>)(lpVtbl[29]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), functionId, fStartJit, cILMapEntries, rgILMapEntries);
        }

        [VtblIndex(30)]
        [return: NativeTypeName("HRESULT")]
        public int GetInprocInspectionInterface(IUnknown** ppicd)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, IUnknown**, int>)(lpVtbl[30]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), ppicd);
        }

        [VtblIndex(31)]
        [return: NativeTypeName("HRESULT")]
        public int GetInprocInspectionIThisThread(IUnknown** ppicd)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, IUnknown**, int>)(lpVtbl[31]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), ppicd);
        }

        [VtblIndex(32)]
        [return: NativeTypeName("HRESULT")]
        public int GetThreadContext([NativeTypeName("ThreadID")] ulong threadId, [NativeTypeName("ContextID *")] ulong* pContextId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, ulong*, int>)(lpVtbl[32]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), threadId, pContextId);
        }

        [VtblIndex(33)]
        [return: NativeTypeName("HRESULT")]
        public int BeginInprocDebugging([NativeTypeName("BOOL")] int fThisThreadOnly, [NativeTypeName("DWORD *")] uint* pdwProfilerContext)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, int, uint*, int>)(lpVtbl[33]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), fThisThreadOnly, pdwProfilerContext);
        }

        [VtblIndex(34)]
        [return: NativeTypeName("HRESULT")]
        public int EndInprocDebugging([NativeTypeName("DWORD")] uint dwProfilerContext)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, uint, int>)(lpVtbl[34]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), dwProfilerContext);
        }

        [VtblIndex(35)]
        [return: NativeTypeName("HRESULT")]
        public int GetILToNativeMapping([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("ULONG32")] uint cMap, [NativeTypeName("ULONG32 *")] uint* pcMap, [NativeTypeName("COR_DEBUG_IL_TO_NATIVE_MAP[]")] COR_DEBUG_IL_TO_NATIVE_MAP* map)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, uint*, COR_DEBUG_IL_TO_NATIVE_MAP*, int>)(lpVtbl[35]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), functionId, cMap, pcMap, map);
        }

        [VtblIndex(36)]
        [return: NativeTypeName("HRESULT")]
        public int DoStackSnapshot([NativeTypeName("ThreadID")] ulong thread, [NativeTypeName("StackSnapshotCallback *")] delegate* unmanaged[Stdcall]<ulong, ulong, ulong, uint, byte*, void*, int> callback, [NativeTypeName("ULONG32")] uint infoFlags, void* clientData, [NativeTypeName("BYTE[]")] byte* context, [NativeTypeName("ULONG32")] uint contextSize)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, delegate* unmanaged[Stdcall]<ulong, ulong, ulong, uint, byte*, void*, int>, uint, void*, byte*, uint, int>)(lpVtbl[36]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), thread, callback, infoFlags, clientData, context, contextSize);
        }

        [VtblIndex(37)]
        [return: NativeTypeName("HRESULT")]
        public int SetEnterLeaveFunctionHooks2([NativeTypeName("FunctionEnter2 *")] delegate* unmanaged[Stdcall]<ulong, ulong, ulong, COR_PRF_FUNCTION_ARGUMENT_INFO*, void> pFuncEnter, [NativeTypeName("FunctionLeave2 *")] delegate* unmanaged[Stdcall]<ulong, ulong, ulong, COR_PRF_FUNCTION_ARGUMENT_RANGE*, void> pFuncLeave, [NativeTypeName("FunctionTailcall2 *")] delegate* unmanaged[Stdcall]<ulong, ulong, ulong, void> pFuncTailcall)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, delegate* unmanaged[Stdcall]<ulong, ulong, ulong, COR_PRF_FUNCTION_ARGUMENT_INFO*, void>, delegate* unmanaged[Stdcall]<ulong, ulong, ulong, COR_PRF_FUNCTION_ARGUMENT_RANGE*, void>, delegate* unmanaged[Stdcall]<ulong, ulong, ulong, void>, int>)(lpVtbl[37]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), pFuncEnter, pFuncLeave, pFuncTailcall);
        }

        [VtblIndex(38)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionInfo2([NativeTypeName("FunctionID")] ulong funcId, [NativeTypeName("COR_PRF_FRAME_INFO")] ulong frameInfo, [NativeTypeName("ClassID *")] ulong* pClassId, [NativeTypeName("ModuleID *")] ulong* pModuleId, [NativeTypeName("mdToken *")] uint* pToken, [NativeTypeName("ULONG32")] uint cTypeArgs, [NativeTypeName("ULONG32 *")] uint* pcTypeArgs, [NativeTypeName("ClassID[]")] ulong* typeArgs)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, ulong, ulong*, ulong*, uint*, uint, uint*, ulong*, int>)(lpVtbl[38]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), funcId, frameInfo, pClassId, pModuleId, pToken, cTypeArgs, pcTypeArgs, typeArgs);
        }

        [VtblIndex(39)]
        [return: NativeTypeName("HRESULT")]
        public int GetStringLayout([NativeTypeName("ULONG *")] uint* pBufferLengthOffset, [NativeTypeName("ULONG *")] uint* pStringLengthOffset, [NativeTypeName("ULONG *")] uint* pBufferOffset)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, uint*, uint*, uint*, int>)(lpVtbl[39]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), pBufferLengthOffset, pStringLengthOffset, pBufferOffset);
        }

        [VtblIndex(40)]
        [return: NativeTypeName("HRESULT")]
        public int GetClassLayout([NativeTypeName("ClassID")] ulong classID, [NativeTypeName("COR_FIELD_OFFSET[]")] COR_FIELD_OFFSET* rFieldOffset, [NativeTypeName("ULONG")] uint cFieldOffset, [NativeTypeName("ULONG *")] uint* pcFieldOffset, [NativeTypeName("ULONG *")] uint* pulClassSize)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, COR_FIELD_OFFSET*, uint, uint*, uint*, int>)(lpVtbl[40]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), classID, rFieldOffset, cFieldOffset, pcFieldOffset, pulClassSize);
        }

        [VtblIndex(41)]
        [return: NativeTypeName("HRESULT")]
        public int GetClassIDInfo2([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("ModuleID *")] ulong* pModuleId, [NativeTypeName("mdTypeDef *")] uint* pTypeDefToken, [NativeTypeName("ClassID *")] ulong* pParentClassId, [NativeTypeName("ULONG32")] uint cNumTypeArgs, [NativeTypeName("ULONG32 *")] uint* pcNumTypeArgs, [NativeTypeName("ClassID[]")] ulong* typeArgs)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, ulong*, uint*, ulong*, uint, uint*, ulong*, int>)(lpVtbl[41]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), classId, pModuleId, pTypeDefToken, pParentClassId, cNumTypeArgs, pcNumTypeArgs, typeArgs);
        }

        [VtblIndex(42)]
        [return: NativeTypeName("HRESULT")]
        public int GetCodeInfo2([NativeTypeName("FunctionID")] ulong functionID, [NativeTypeName("ULONG32")] uint cCodeInfos, [NativeTypeName("ULONG32 *")] uint* pcCodeInfos, [NativeTypeName("COR_PRF_CODE_INFO[]")] COR_PRF_CODE_INFO* codeInfos)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, uint*, COR_PRF_CODE_INFO*, int>)(lpVtbl[42]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), functionID, cCodeInfos, pcCodeInfos, codeInfos);
        }

        [VtblIndex(43)]
        [return: NativeTypeName("HRESULT")]
        public int GetClassFromTokenAndTypeArgs([NativeTypeName("ModuleID")] ulong moduleID, [NativeTypeName("mdTypeDef")] uint typeDef, [NativeTypeName("ULONG32")] uint cTypeArgs, [NativeTypeName("ClassID[]")] ulong* typeArgs, [NativeTypeName("ClassID *")] ulong* pClassID)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, uint, ulong*, ulong*, int>)(lpVtbl[43]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), moduleID, typeDef, cTypeArgs, typeArgs, pClassID);
        }

        [VtblIndex(44)]
        [return: NativeTypeName("HRESULT")]
        public int GetFunctionFromTokenAndTypeArgs([NativeTypeName("ModuleID")] ulong moduleID, [NativeTypeName("mdMethodDef")] uint funcDef, [NativeTypeName("ClassID")] ulong classId, [NativeTypeName("ULONG32")] uint cTypeArgs, [NativeTypeName("ClassID[]")] ulong* typeArgs, [NativeTypeName("FunctionID *")] ulong* pFunctionID)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, ulong, uint, ulong*, ulong*, int>)(lpVtbl[44]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), moduleID, funcDef, classId, cTypeArgs, typeArgs, pFunctionID);
        }

        [VtblIndex(45)]
        [return: NativeTypeName("HRESULT")]
        public int EnumModuleFrozenObjects([NativeTypeName("ModuleID")] ulong moduleID, ICorProfilerObjectEnum** ppEnum)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, ICorProfilerObjectEnum**, int>)(lpVtbl[45]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), moduleID, ppEnum);
        }

        [VtblIndex(46)]
        [return: NativeTypeName("HRESULT")]
        public int GetArrayObjectInfo([NativeTypeName("ObjectID")] ulong objectId, [NativeTypeName("ULONG32")] uint cDimensions, [NativeTypeName("ULONG32[]")] uint* pDimensionSizes, [NativeTypeName("int[]")] int* pDimensionLowerBounds, byte** ppData)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, uint*, int*, byte**, int>)(lpVtbl[46]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), objectId, cDimensions, pDimensionSizes, pDimensionLowerBounds, ppData);
        }

        [VtblIndex(47)]
        [return: NativeTypeName("HRESULT")]
        public int GetBoxClassLayout([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("ULONG32 *")] uint* pBufferOffset)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint*, int>)(lpVtbl[47]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), classId, pBufferOffset);
        }

        [VtblIndex(48)]
        [return: NativeTypeName("HRESULT")]
        public int GetThreadAppDomain([NativeTypeName("ThreadID")] ulong threadId, [NativeTypeName("AppDomainID *")] ulong* pAppDomainId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, ulong*, int>)(lpVtbl[48]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), threadId, pAppDomainId);
        }

        [VtblIndex(49)]
        [return: NativeTypeName("HRESULT")]
        public int GetRVAStaticAddress([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("mdFieldDef")] uint fieldToken, void** ppAddress)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, void**, int>)(lpVtbl[49]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), classId, fieldToken, ppAddress);
        }

        [VtblIndex(50)]
        [return: NativeTypeName("HRESULT")]
        public int GetAppDomainStaticAddress([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("mdFieldDef")] uint fieldToken, [NativeTypeName("AppDomainID")] ulong appDomainId, void** ppAddress)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, ulong, void**, int>)(lpVtbl[50]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), classId, fieldToken, appDomainId, ppAddress);
        }

        [VtblIndex(51)]
        [return: NativeTypeName("HRESULT")]
        public int GetThreadStaticAddress([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("mdFieldDef")] uint fieldToken, [NativeTypeName("ThreadID")] ulong threadId, void** ppAddress)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, ulong, void**, int>)(lpVtbl[51]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), classId, fieldToken, threadId, ppAddress);
        }

        [VtblIndex(52)]
        [return: NativeTypeName("HRESULT")]
        public int GetContextStaticAddress([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("mdFieldDef")] uint fieldToken, [NativeTypeName("ContextID")] ulong contextId, void** ppAddress)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, ulong, void**, int>)(lpVtbl[52]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), classId, fieldToken, contextId, ppAddress);
        }

        [VtblIndex(53)]
        [return: NativeTypeName("HRESULT")]
        public int GetStaticFieldInfo([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("mdFieldDef")] uint fieldToken, COR_PRF_STATIC_TYPE* pFieldInfo)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, uint, COR_PRF_STATIC_TYPE*, int>)(lpVtbl[53]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), classId, fieldToken, pFieldInfo);
        }

        [VtblIndex(54)]
        [return: NativeTypeName("HRESULT")]
        public int GetGenerationBounds([NativeTypeName("ULONG")] uint cObjectRanges, [NativeTypeName("ULONG *")] uint* pcObjectRanges, [NativeTypeName("COR_PRF_GC_GENERATION_RANGE[]")] COR_PRF_GC_GENERATION_RANGE* ranges)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, uint, uint*, COR_PRF_GC_GENERATION_RANGE*, int>)(lpVtbl[54]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), cObjectRanges, pcObjectRanges, ranges);
        }

        [VtblIndex(55)]
        [return: NativeTypeName("HRESULT")]
        public int GetObjectGeneration([NativeTypeName("ObjectID")] ulong objectId, COR_PRF_GC_GENERATION_RANGE* range)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, COR_PRF_GC_GENERATION_RANGE*, int>)(lpVtbl[55]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), objectId, range);
        }

        [VtblIndex(56)]
        [return: NativeTypeName("HRESULT")]
        public int GetNotifiedExceptionClauseInfo(COR_PRF_EX_CLAUSE_INFO* pinfo)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, COR_PRF_EX_CLAUSE_INFO*, int>)(lpVtbl[56]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), pinfo);
        }
    }
}
