using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    [Guid("176FBED1-A55C-4796-98CA-A9DA0EF883E7")]
    [NativeTypeName("struct ICorProfilerCallback : IUnknown")]
    public unsafe partial struct ICorProfilerCallback
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, Guid*, void**, int>)(lpVtbl[0]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, uint>)(lpVtbl[1]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, uint>)(lpVtbl[2]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int Initialize(IUnknown* pICorProfilerInfoUnk)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, IUnknown*, int>)(lpVtbl[3]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), pICorProfilerInfoUnk);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int Shutdown()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, int>)(lpVtbl[4]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int AppDomainCreationStarted([NativeTypeName("AppDomainID")] ulong appDomainId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[5]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), appDomainId);
        }

        [VtblIndex(6)]
        [return: NativeTypeName("HRESULT")]
        public int AppDomainCreationFinished([NativeTypeName("AppDomainID")] ulong appDomainId, [NativeTypeName("HRESULT")] int hrStatus)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int, int>)(lpVtbl[6]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), appDomainId, hrStatus);
        }

        [VtblIndex(7)]
        [return: NativeTypeName("HRESULT")]
        public int AppDomainShutdownStarted([NativeTypeName("AppDomainID")] ulong appDomainId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[7]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), appDomainId);
        }

        [VtblIndex(8)]
        [return: NativeTypeName("HRESULT")]
        public int AppDomainShutdownFinished([NativeTypeName("AppDomainID")] ulong appDomainId, [NativeTypeName("HRESULT")] int hrStatus)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int, int>)(lpVtbl[8]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), appDomainId, hrStatus);
        }

        [VtblIndex(9)]
        [return: NativeTypeName("HRESULT")]
        public int AssemblyLoadStarted([NativeTypeName("AssemblyID")] ulong assemblyId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[9]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), assemblyId);
        }

        [VtblIndex(10)]
        [return: NativeTypeName("HRESULT")]
        public int AssemblyLoadFinished([NativeTypeName("AssemblyID")] ulong assemblyId, [NativeTypeName("HRESULT")] int hrStatus)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int, int>)(lpVtbl[10]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), assemblyId, hrStatus);
        }

        [VtblIndex(11)]
        [return: NativeTypeName("HRESULT")]
        public int AssemblyUnloadStarted([NativeTypeName("AssemblyID")] ulong assemblyId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[11]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), assemblyId);
        }

        [VtblIndex(12)]
        [return: NativeTypeName("HRESULT")]
        public int AssemblyUnloadFinished([NativeTypeName("AssemblyID")] ulong assemblyId, [NativeTypeName("HRESULT")] int hrStatus)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int, int>)(lpVtbl[12]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), assemblyId, hrStatus);
        }

        [VtblIndex(13)]
        [return: NativeTypeName("HRESULT")]
        public int ModuleLoadStarted([NativeTypeName("ModuleID")] ulong moduleId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[13]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), moduleId);
        }

        [VtblIndex(14)]
        [return: NativeTypeName("HRESULT")]
        public int ModuleLoadFinished([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("HRESULT")] int hrStatus)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int, int>)(lpVtbl[14]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), moduleId, hrStatus);
        }

        [VtblIndex(15)]
        [return: NativeTypeName("HRESULT")]
        public int ModuleUnloadStarted([NativeTypeName("ModuleID")] ulong moduleId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[15]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), moduleId);
        }

        [VtblIndex(16)]
        [return: NativeTypeName("HRESULT")]
        public int ModuleUnloadFinished([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("HRESULT")] int hrStatus)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int, int>)(lpVtbl[16]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), moduleId, hrStatus);
        }

        [VtblIndex(17)]
        [return: NativeTypeName("HRESULT")]
        public int ModuleAttachedToAssembly([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("AssemblyID")] ulong AssemblyId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, ulong, int>)(lpVtbl[17]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), moduleId, AssemblyId);
        }

        [VtblIndex(18)]
        [return: NativeTypeName("HRESULT")]
        public int ClassLoadStarted([NativeTypeName("ClassID")] ulong classId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[18]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), classId);
        }

        [VtblIndex(19)]
        [return: NativeTypeName("HRESULT")]
        public int ClassLoadFinished([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("HRESULT")] int hrStatus)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int, int>)(lpVtbl[19]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), classId, hrStatus);
        }

        [VtblIndex(20)]
        [return: NativeTypeName("HRESULT")]
        public int ClassUnloadStarted([NativeTypeName("ClassID")] ulong classId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[20]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), classId);
        }

        [VtblIndex(21)]
        [return: NativeTypeName("HRESULT")]
        public int ClassUnloadFinished([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("HRESULT")] int hrStatus)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int, int>)(lpVtbl[21]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), classId, hrStatus);
        }

        [VtblIndex(22)]
        [return: NativeTypeName("HRESULT")]
        public int FunctionUnloadStarted([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[22]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(23)]
        [return: NativeTypeName("HRESULT")]
        public int JITCompilationStarted([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("BOOL")] int fIsSafeToBlock)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int, int>)(lpVtbl[23]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), functionId, fIsSafeToBlock);
        }

        [VtblIndex(24)]
        [return: NativeTypeName("HRESULT")]
        public int JITCompilationFinished([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("HRESULT")] int hrStatus, [NativeTypeName("BOOL")] int fIsSafeToBlock)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int, int, int>)(lpVtbl[24]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), functionId, hrStatus, fIsSafeToBlock);
        }

        [VtblIndex(25)]
        [return: NativeTypeName("HRESULT")]
        public int JITCachedFunctionSearchStarted([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("BOOL *")] int* pbUseCachedFunction)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int*, int>)(lpVtbl[25]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), functionId, pbUseCachedFunction);
        }

        [VtblIndex(26)]
        [return: NativeTypeName("HRESULT")]
        public int JITCachedFunctionSearchFinished([NativeTypeName("FunctionID")] ulong functionId, COR_PRF_JIT_CACHE result)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, COR_PRF_JIT_CACHE, int>)(lpVtbl[26]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), functionId, result);
        }

        [VtblIndex(27)]
        [return: NativeTypeName("HRESULT")]
        public int JITFunctionPitched([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[27]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(28)]
        [return: NativeTypeName("HRESULT")]
        public int JITInlining([NativeTypeName("FunctionID")] ulong callerId, [NativeTypeName("FunctionID")] ulong calleeId, [NativeTypeName("BOOL *")] int* pfShouldInline)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, ulong, int*, int>)(lpVtbl[28]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), callerId, calleeId, pfShouldInline);
        }

        [VtblIndex(29)]
        [return: NativeTypeName("HRESULT")]
        public int ThreadCreated([NativeTypeName("ThreadID")] ulong threadId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[29]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), threadId);
        }

        [VtblIndex(30)]
        [return: NativeTypeName("HRESULT")]
        public int ThreadDestroyed([NativeTypeName("ThreadID")] ulong threadId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[30]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), threadId);
        }

        [VtblIndex(31)]
        [return: NativeTypeName("HRESULT")]
        public int ThreadAssignedToOSThread([NativeTypeName("ThreadID")] ulong managedThreadId, [NativeTypeName("DWORD")] uint osThreadId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, uint, int>)(lpVtbl[31]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), managedThreadId, osThreadId);
        }

        [VtblIndex(32)]
        [return: NativeTypeName("HRESULT")]
        public int RemotingClientInvocationStarted()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, int>)(lpVtbl[32]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(33)]
        [return: NativeTypeName("HRESULT")]
        public int RemotingClientSendingMessage(Guid* pCookie, [NativeTypeName("BOOL")] int fIsAsync)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, Guid*, int, int>)(lpVtbl[33]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), pCookie, fIsAsync);
        }

        [VtblIndex(34)]
        [return: NativeTypeName("HRESULT")]
        public int RemotingClientReceivingReply(Guid* pCookie, [NativeTypeName("BOOL")] int fIsAsync)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, Guid*, int, int>)(lpVtbl[34]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), pCookie, fIsAsync);
        }

        [VtblIndex(35)]
        [return: NativeTypeName("HRESULT")]
        public int RemotingClientInvocationFinished()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, int>)(lpVtbl[35]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(36)]
        [return: NativeTypeName("HRESULT")]
        public int RemotingServerReceivingMessage(Guid* pCookie, [NativeTypeName("BOOL")] int fIsAsync)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, Guid*, int, int>)(lpVtbl[36]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), pCookie, fIsAsync);
        }

        [VtblIndex(37)]
        [return: NativeTypeName("HRESULT")]
        public int RemotingServerInvocationStarted()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, int>)(lpVtbl[37]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(38)]
        [return: NativeTypeName("HRESULT")]
        public int RemotingServerInvocationReturned()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, int>)(lpVtbl[38]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(39)]
        [return: NativeTypeName("HRESULT")]
        public int RemotingServerSendingReply(Guid* pCookie, [NativeTypeName("BOOL")] int fIsAsync)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, Guid*, int, int>)(lpVtbl[39]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), pCookie, fIsAsync);
        }

        [VtblIndex(40)]
        [return: NativeTypeName("HRESULT")]
        public int UnmanagedToManagedTransition([NativeTypeName("FunctionID")] ulong functionId, COR_PRF_TRANSITION_REASON reason)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, COR_PRF_TRANSITION_REASON, int>)(lpVtbl[40]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), functionId, reason);
        }

        [VtblIndex(41)]
        [return: NativeTypeName("HRESULT")]
        public int ManagedToUnmanagedTransition([NativeTypeName("FunctionID")] ulong functionId, COR_PRF_TRANSITION_REASON reason)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, COR_PRF_TRANSITION_REASON, int>)(lpVtbl[41]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), functionId, reason);
        }

        [VtblIndex(42)]
        [return: NativeTypeName("HRESULT")]
        public int RuntimeSuspendStarted(COR_PRF_SUSPEND_REASON suspendReason)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, COR_PRF_SUSPEND_REASON, int>)(lpVtbl[42]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), suspendReason);
        }

        [VtblIndex(43)]
        [return: NativeTypeName("HRESULT")]
        public int RuntimeSuspendFinished()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, int>)(lpVtbl[43]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(44)]
        [return: NativeTypeName("HRESULT")]
        public int RuntimeSuspendAborted()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, int>)(lpVtbl[44]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(45)]
        [return: NativeTypeName("HRESULT")]
        public int RuntimeResumeStarted()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, int>)(lpVtbl[45]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(46)]
        [return: NativeTypeName("HRESULT")]
        public int RuntimeResumeFinished()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, int>)(lpVtbl[46]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(47)]
        [return: NativeTypeName("HRESULT")]
        public int RuntimeThreadSuspended([NativeTypeName("ThreadID")] ulong threadId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[47]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), threadId);
        }

        [VtblIndex(48)]
        [return: NativeTypeName("HRESULT")]
        public int RuntimeThreadResumed([NativeTypeName("ThreadID")] ulong threadId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[48]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), threadId);
        }

        [VtblIndex(49)]
        [return: NativeTypeName("HRESULT")]
        public int MovedReferences([NativeTypeName("ULONG")] uint cMovedObjectIDRanges, [NativeTypeName("ObjectID[]")] ulong* oldObjectIDRangeStart, [NativeTypeName("ObjectID[]")] ulong* newObjectIDRangeStart, [NativeTypeName("ULONG[]")] uint* cObjectIDRangeLength)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, uint, ulong*, ulong*, uint*, int>)(lpVtbl[49]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), cMovedObjectIDRanges, oldObjectIDRangeStart, newObjectIDRangeStart, cObjectIDRangeLength);
        }

        [VtblIndex(50)]
        [return: NativeTypeName("HRESULT")]
        public int ObjectAllocated([NativeTypeName("ObjectID")] ulong objectId, [NativeTypeName("ClassID")] ulong classId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, ulong, int>)(lpVtbl[50]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), objectId, classId);
        }

        [VtblIndex(51)]
        [return: NativeTypeName("HRESULT")]
        public int ObjectsAllocatedByClass([NativeTypeName("ULONG")] uint cClassCount, [NativeTypeName("ClassID[]")] ulong* classIds, [NativeTypeName("ULONG[]")] uint* cObjects)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, uint, ulong*, uint*, int>)(lpVtbl[51]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), cClassCount, classIds, cObjects);
        }

        [VtblIndex(52)]
        [return: NativeTypeName("HRESULT")]
        public int ObjectReferences([NativeTypeName("ObjectID")] ulong objectId, [NativeTypeName("ClassID")] ulong classId, [NativeTypeName("ULONG")] uint cObjectRefs, [NativeTypeName("ObjectID[]")] ulong* objectRefIds)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, ulong, uint, ulong*, int>)(lpVtbl[52]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), objectId, classId, cObjectRefs, objectRefIds);
        }

        [VtblIndex(53)]
        [return: NativeTypeName("HRESULT")]
        public int RootReferences([NativeTypeName("ULONG")] uint cRootRefs, [NativeTypeName("ObjectID[]")] ulong* rootRefIds)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, uint, ulong*, int>)(lpVtbl[53]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), cRootRefs, rootRefIds);
        }

        [VtblIndex(54)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionThrown([NativeTypeName("ObjectID")] ulong thrownObjectId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[54]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), thrownObjectId);
        }

        [VtblIndex(55)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionSearchFunctionEnter([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[55]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(56)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionSearchFunctionLeave()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, int>)(lpVtbl[56]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(57)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionSearchFilterEnter([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[57]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(58)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionSearchFilterLeave()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, int>)(lpVtbl[58]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(59)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionSearchCatcherFound([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[59]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(60)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionOSHandlerEnter([NativeTypeName("UINT_PTR")] ulong __unused)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[60]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), __unused);
        }

        [VtblIndex(61)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionOSHandlerLeave([NativeTypeName("UINT_PTR")] ulong __unused)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[61]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), __unused);
        }

        [VtblIndex(62)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionUnwindFunctionEnter([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[62]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(63)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionUnwindFunctionLeave()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, int>)(lpVtbl[63]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(64)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionUnwindFinallyEnter([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, int>)(lpVtbl[64]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(65)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionUnwindFinallyLeave()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, int>)(lpVtbl[65]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(66)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionCatcherEnter([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("ObjectID")] ulong objectId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, ulong, int>)(lpVtbl[66]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), functionId, objectId);
        }

        [VtblIndex(67)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionCatcherLeave()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, int>)(lpVtbl[67]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(68)]
        [return: NativeTypeName("HRESULT")]
        public int COMClassicVTableCreated([NativeTypeName("ClassID")] ulong wrappedClassId, [NativeTypeName("const GUID &")] Guid* implementedIID, void* pVTable, [NativeTypeName("ULONG")] uint cSlots)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, Guid*, void*, uint, int>)(lpVtbl[68]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), wrappedClassId, implementedIID, pVTable, cSlots);
        }

        [VtblIndex(69)]
        [return: NativeTypeName("HRESULT")]
        public int COMClassicVTableDestroyed([NativeTypeName("ClassID")] ulong wrappedClassId, [NativeTypeName("const GUID &")] Guid* implementedIID, void* pVTable)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, ulong, Guid*, void*, int>)(lpVtbl[69]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this), wrappedClassId, implementedIID, pVTable);
        }

        [VtblIndex(70)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionCLRCatcherFound()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, int>)(lpVtbl[70]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(71)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionCLRCatcherExecute()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback*, int>)(lpVtbl[71]))((ICorProfilerCallback*)Unsafe.AsPointer(ref this));
        }
    }
}
