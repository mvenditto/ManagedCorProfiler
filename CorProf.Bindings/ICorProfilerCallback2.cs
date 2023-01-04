using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    [Guid("8A8CC829-CCF2-49FE-BBAE-0F022228071A")]
    [NativeTypeName("struct ICorProfilerCallback2 : ICorProfilerCallback")]
    public unsafe partial struct ICorProfilerCallback2
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, Guid*, void**, int>)(lpVtbl[0]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, uint>)(lpVtbl[1]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, uint>)(lpVtbl[2]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int Initialize(IUnknown* pICorProfilerInfoUnk)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, IUnknown*, int>)(lpVtbl[3]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), pICorProfilerInfoUnk);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int Shutdown()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[4]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int AppDomainCreationStarted([NativeTypeName("AppDomainID")] ulong appDomainId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[5]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), appDomainId);
        }

        [VtblIndex(6)]
        [return: NativeTypeName("HRESULT")]
        public int AppDomainCreationFinished([NativeTypeName("AppDomainID")] ulong appDomainId, [NativeTypeName("HRESULT")] int hrStatus)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int, int>)(lpVtbl[6]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), appDomainId, hrStatus);
        }

        [VtblIndex(7)]
        [return: NativeTypeName("HRESULT")]
        public int AppDomainShutdownStarted([NativeTypeName("AppDomainID")] ulong appDomainId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[7]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), appDomainId);
        }

        [VtblIndex(8)]
        [return: NativeTypeName("HRESULT")]
        public int AppDomainShutdownFinished([NativeTypeName("AppDomainID")] ulong appDomainId, [NativeTypeName("HRESULT")] int hrStatus)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int, int>)(lpVtbl[8]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), appDomainId, hrStatus);
        }

        [VtblIndex(9)]
        [return: NativeTypeName("HRESULT")]
        public int AssemblyLoadStarted([NativeTypeName("AssemblyID")] ulong assemblyId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[9]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), assemblyId);
        }

        [VtblIndex(10)]
        [return: NativeTypeName("HRESULT")]
        public int AssemblyLoadFinished([NativeTypeName("AssemblyID")] ulong assemblyId, [NativeTypeName("HRESULT")] int hrStatus)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int, int>)(lpVtbl[10]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), assemblyId, hrStatus);
        }

        [VtblIndex(11)]
        [return: NativeTypeName("HRESULT")]
        public int AssemblyUnloadStarted([NativeTypeName("AssemblyID")] ulong assemblyId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[11]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), assemblyId);
        }

        [VtblIndex(12)]
        [return: NativeTypeName("HRESULT")]
        public int AssemblyUnloadFinished([NativeTypeName("AssemblyID")] ulong assemblyId, [NativeTypeName("HRESULT")] int hrStatus)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int, int>)(lpVtbl[12]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), assemblyId, hrStatus);
        }

        [VtblIndex(13)]
        [return: NativeTypeName("HRESULT")]
        public int ModuleLoadStarted([NativeTypeName("ModuleID")] ulong moduleId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[13]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), moduleId);
        }

        [VtblIndex(14)]
        [return: NativeTypeName("HRESULT")]
        public int ModuleLoadFinished([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("HRESULT")] int hrStatus)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int, int>)(lpVtbl[14]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), moduleId, hrStatus);
        }

        [VtblIndex(15)]
        [return: NativeTypeName("HRESULT")]
        public int ModuleUnloadStarted([NativeTypeName("ModuleID")] ulong moduleId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[15]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), moduleId);
        }

        [VtblIndex(16)]
        [return: NativeTypeName("HRESULT")]
        public int ModuleUnloadFinished([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("HRESULT")] int hrStatus)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int, int>)(lpVtbl[16]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), moduleId, hrStatus);
        }

        [VtblIndex(17)]
        [return: NativeTypeName("HRESULT")]
        public int ModuleAttachedToAssembly([NativeTypeName("ModuleID")] ulong moduleId, [NativeTypeName("AssemblyID")] ulong AssemblyId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, ulong, int>)(lpVtbl[17]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), moduleId, AssemblyId);
        }

        [VtblIndex(18)]
        [return: NativeTypeName("HRESULT")]
        public int ClassLoadStarted([NativeTypeName("ClassID")] ulong classId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[18]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), classId);
        }

        [VtblIndex(19)]
        [return: NativeTypeName("HRESULT")]
        public int ClassLoadFinished([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("HRESULT")] int hrStatus)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int, int>)(lpVtbl[19]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), classId, hrStatus);
        }

        [VtblIndex(20)]
        [return: NativeTypeName("HRESULT")]
        public int ClassUnloadStarted([NativeTypeName("ClassID")] ulong classId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[20]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), classId);
        }

        [VtblIndex(21)]
        [return: NativeTypeName("HRESULT")]
        public int ClassUnloadFinished([NativeTypeName("ClassID")] ulong classId, [NativeTypeName("HRESULT")] int hrStatus)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int, int>)(lpVtbl[21]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), classId, hrStatus);
        }

        [VtblIndex(22)]
        [return: NativeTypeName("HRESULT")]
        public int FunctionUnloadStarted([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[22]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(23)]
        [return: NativeTypeName("HRESULT")]
        public int JITCompilationStarted([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("BOOL")] int fIsSafeToBlock)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int, int>)(lpVtbl[23]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), functionId, fIsSafeToBlock);
        }

        [VtblIndex(24)]
        [return: NativeTypeName("HRESULT")]
        public int JITCompilationFinished([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("HRESULT")] int hrStatus, [NativeTypeName("BOOL")] int fIsSafeToBlock)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int, int, int>)(lpVtbl[24]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), functionId, hrStatus, fIsSafeToBlock);
        }

        [VtblIndex(25)]
        [return: NativeTypeName("HRESULT")]
        public int JITCachedFunctionSearchStarted([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("BOOL *")] int* pbUseCachedFunction)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int*, int>)(lpVtbl[25]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), functionId, pbUseCachedFunction);
        }

        [VtblIndex(26)]
        [return: NativeTypeName("HRESULT")]
        public int JITCachedFunctionSearchFinished([NativeTypeName("FunctionID")] ulong functionId, COR_PRF_JIT_CACHE result)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, COR_PRF_JIT_CACHE, int>)(lpVtbl[26]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), functionId, result);
        }

        [VtblIndex(27)]
        [return: NativeTypeName("HRESULT")]
        public int JITFunctionPitched([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[27]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(28)]
        [return: NativeTypeName("HRESULT")]
        public int JITInlining([NativeTypeName("FunctionID")] ulong callerId, [NativeTypeName("FunctionID")] ulong calleeId, [NativeTypeName("BOOL *")] int* pfShouldInline)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, ulong, int*, int>)(lpVtbl[28]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), callerId, calleeId, pfShouldInline);
        }

        [VtblIndex(29)]
        [return: NativeTypeName("HRESULT")]
        public int ThreadCreated([NativeTypeName("ThreadID")] ulong threadId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[29]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), threadId);
        }

        [VtblIndex(30)]
        [return: NativeTypeName("HRESULT")]
        public int ThreadDestroyed([NativeTypeName("ThreadID")] ulong threadId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[30]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), threadId);
        }

        [VtblIndex(31)]
        [return: NativeTypeName("HRESULT")]
        public int ThreadAssignedToOSThread([NativeTypeName("ThreadID")] ulong managedThreadId, [NativeTypeName("DWORD")] uint osThreadId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, uint, int>)(lpVtbl[31]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), managedThreadId, osThreadId);
        }

        [VtblIndex(32)]
        [return: NativeTypeName("HRESULT")]
        public int RemotingClientInvocationStarted()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[32]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(33)]
        [return: NativeTypeName("HRESULT")]
        public int RemotingClientSendingMessage(Guid* pCookie, [NativeTypeName("BOOL")] int fIsAsync)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, Guid*, int, int>)(lpVtbl[33]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), pCookie, fIsAsync);
        }

        [VtblIndex(34)]
        [return: NativeTypeName("HRESULT")]
        public int RemotingClientReceivingReply(Guid* pCookie, [NativeTypeName("BOOL")] int fIsAsync)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, Guid*, int, int>)(lpVtbl[34]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), pCookie, fIsAsync);
        }

        [VtblIndex(35)]
        [return: NativeTypeName("HRESULT")]
        public int RemotingClientInvocationFinished()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[35]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(36)]
        [return: NativeTypeName("HRESULT")]
        public int RemotingServerReceivingMessage(Guid* pCookie, [NativeTypeName("BOOL")] int fIsAsync)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, Guid*, int, int>)(lpVtbl[36]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), pCookie, fIsAsync);
        }

        [VtblIndex(37)]
        [return: NativeTypeName("HRESULT")]
        public int RemotingServerInvocationStarted()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[37]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(38)]
        [return: NativeTypeName("HRESULT")]
        public int RemotingServerInvocationReturned()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[38]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(39)]
        [return: NativeTypeName("HRESULT")]
        public int RemotingServerSendingReply(Guid* pCookie, [NativeTypeName("BOOL")] int fIsAsync)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, Guid*, int, int>)(lpVtbl[39]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), pCookie, fIsAsync);
        }

        [VtblIndex(40)]
        [return: NativeTypeName("HRESULT")]
        public int UnmanagedToManagedTransition([NativeTypeName("FunctionID")] ulong functionId, COR_PRF_TRANSITION_REASON reason)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, COR_PRF_TRANSITION_REASON, int>)(lpVtbl[40]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), functionId, reason);
        }

        [VtblIndex(41)]
        [return: NativeTypeName("HRESULT")]
        public int ManagedToUnmanagedTransition([NativeTypeName("FunctionID")] ulong functionId, COR_PRF_TRANSITION_REASON reason)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, COR_PRF_TRANSITION_REASON, int>)(lpVtbl[41]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), functionId, reason);
        }

        [VtblIndex(42)]
        [return: NativeTypeName("HRESULT")]
        public int RuntimeSuspendStarted(COR_PRF_SUSPEND_REASON suspendReason)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, COR_PRF_SUSPEND_REASON, int>)(lpVtbl[42]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), suspendReason);
        }

        [VtblIndex(43)]
        [return: NativeTypeName("HRESULT")]
        public int RuntimeSuspendFinished()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[43]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(44)]
        [return: NativeTypeName("HRESULT")]
        public int RuntimeSuspendAborted()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[44]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(45)]
        [return: NativeTypeName("HRESULT")]
        public int RuntimeResumeStarted()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[45]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(46)]
        [return: NativeTypeName("HRESULT")]
        public int RuntimeResumeFinished()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[46]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(47)]
        [return: NativeTypeName("HRESULT")]
        public int RuntimeThreadSuspended([NativeTypeName("ThreadID")] ulong threadId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[47]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), threadId);
        }

        [VtblIndex(48)]
        [return: NativeTypeName("HRESULT")]
        public int RuntimeThreadResumed([NativeTypeName("ThreadID")] ulong threadId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[48]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), threadId);
        }

        [VtblIndex(49)]
        [return: NativeTypeName("HRESULT")]
        public int MovedReferences([NativeTypeName("ULONG")] uint cMovedObjectIDRanges, [NativeTypeName("ObjectID[]")] ulong* oldObjectIDRangeStart, [NativeTypeName("ObjectID[]")] ulong* newObjectIDRangeStart, [NativeTypeName("ULONG[]")] uint* cObjectIDRangeLength)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, uint, ulong*, ulong*, uint*, int>)(lpVtbl[49]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), cMovedObjectIDRanges, oldObjectIDRangeStart, newObjectIDRangeStart, cObjectIDRangeLength);
        }

        [VtblIndex(50)]
        [return: NativeTypeName("HRESULT")]
        public int ObjectAllocated([NativeTypeName("ObjectID")] ulong objectId, [NativeTypeName("ClassID")] ulong classId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, ulong, int>)(lpVtbl[50]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), objectId, classId);
        }

        [VtblIndex(51)]
        [return: NativeTypeName("HRESULT")]
        public int ObjectsAllocatedByClass([NativeTypeName("ULONG")] uint cClassCount, [NativeTypeName("ClassID[]")] ulong* classIds, [NativeTypeName("ULONG[]")] uint* cObjects)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, uint, ulong*, uint*, int>)(lpVtbl[51]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), cClassCount, classIds, cObjects);
        }

        [VtblIndex(52)]
        [return: NativeTypeName("HRESULT")]
        public int ObjectReferences([NativeTypeName("ObjectID")] ulong objectId, [NativeTypeName("ClassID")] ulong classId, [NativeTypeName("ULONG")] uint cObjectRefs, [NativeTypeName("ObjectID[]")] ulong* objectRefIds)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, ulong, uint, ulong*, int>)(lpVtbl[52]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), objectId, classId, cObjectRefs, objectRefIds);
        }

        [VtblIndex(53)]
        [return: NativeTypeName("HRESULT")]
        public int RootReferences([NativeTypeName("ULONG")] uint cRootRefs, [NativeTypeName("ObjectID[]")] ulong* rootRefIds)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, uint, ulong*, int>)(lpVtbl[53]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), cRootRefs, rootRefIds);
        }

        [VtblIndex(54)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionThrown([NativeTypeName("ObjectID")] ulong thrownObjectId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[54]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), thrownObjectId);
        }

        [VtblIndex(55)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionSearchFunctionEnter([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[55]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(56)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionSearchFunctionLeave()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[56]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(57)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionSearchFilterEnter([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[57]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(58)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionSearchFilterLeave()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[58]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(59)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionSearchCatcherFound([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[59]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(60)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionOSHandlerEnter([NativeTypeName("UINT_PTR")] ulong __unused)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[60]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), __unused);
        }

        [VtblIndex(61)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionOSHandlerLeave([NativeTypeName("UINT_PTR")] ulong __unused)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[61]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), __unused);
        }

        [VtblIndex(62)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionUnwindFunctionEnter([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[62]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(63)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionUnwindFunctionLeave()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[63]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(64)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionUnwindFinallyEnter([NativeTypeName("FunctionID")] ulong functionId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[64]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), functionId);
        }

        [VtblIndex(65)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionUnwindFinallyLeave()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[65]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(66)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionCatcherEnter([NativeTypeName("FunctionID")] ulong functionId, [NativeTypeName("ObjectID")] ulong objectId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, ulong, int>)(lpVtbl[66]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), functionId, objectId);
        }

        [VtblIndex(67)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionCatcherLeave()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[67]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(68)]
        [return: NativeTypeName("HRESULT")]
        public int COMClassicVTableCreated([NativeTypeName("ClassID")] ulong wrappedClassId, [NativeTypeName("const GUID &")] Guid* implementedIID, void* pVTable, [NativeTypeName("ULONG")] uint cSlots)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, Guid*, void*, uint, int>)(lpVtbl[68]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), wrappedClassId, implementedIID, pVTable, cSlots);
        }

        [VtblIndex(69)]
        [return: NativeTypeName("HRESULT")]
        public int COMClassicVTableDestroyed([NativeTypeName("ClassID")] ulong wrappedClassId, [NativeTypeName("const GUID &")] Guid* implementedIID, void* pVTable)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, Guid*, void*, int>)(lpVtbl[69]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), wrappedClassId, implementedIID, pVTable);
        }

        [VtblIndex(70)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionCLRCatcherFound()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[70]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(71)]
        [return: NativeTypeName("HRESULT")]
        public int ExceptionCLRCatcherExecute()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[71]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(72)]
        [return: NativeTypeName("HRESULT")]
        public int ThreadNameChanged([NativeTypeName("ThreadID")] ulong threadId, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("WCHAR[]")] ushort* name)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, uint, ushort*, int>)(lpVtbl[72]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), threadId, cchName, name);
        }

        [VtblIndex(73)]
        [return: NativeTypeName("HRESULT")]
        public int GarbageCollectionStarted(int cGenerations, [NativeTypeName("BOOL[]")] int* generationCollected, COR_PRF_GC_REASON reason)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int, int*, COR_PRF_GC_REASON, int>)(lpVtbl[73]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), cGenerations, generationCollected, reason);
        }

        [VtblIndex(74)]
        [return: NativeTypeName("HRESULT")]
        public int SurvivingReferences([NativeTypeName("ULONG")] uint cSurvivingObjectIDRanges, [NativeTypeName("ObjectID[]")] ulong* objectIDRangeStart, [NativeTypeName("ULONG[]")] uint* cObjectIDRangeLength)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, uint, ulong*, uint*, int>)(lpVtbl[74]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), cSurvivingObjectIDRanges, objectIDRangeStart, cObjectIDRangeLength);
        }

        [VtblIndex(75)]
        [return: NativeTypeName("HRESULT")]
        public int GarbageCollectionFinished()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, int>)(lpVtbl[75]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(76)]
        [return: NativeTypeName("HRESULT")]
        public int FinalizeableObjectQueued([NativeTypeName("DWORD")] uint finalizerFlags, [NativeTypeName("ObjectID")] ulong objectID)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, uint, ulong, int>)(lpVtbl[76]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), finalizerFlags, objectID);
        }

        [VtblIndex(77)]
        [return: NativeTypeName("HRESULT")]
        public int RootReferences2([NativeTypeName("ULONG")] uint cRootRefs, [NativeTypeName("ObjectID[]")] ulong* rootRefIds, [NativeTypeName("COR_PRF_GC_ROOT_KIND[]")] COR_PRF_GC_ROOT_KIND* rootKinds, [NativeTypeName("COR_PRF_GC_ROOT_FLAGS[]")] COR_PRF_GC_ROOT_FLAGS* rootFlags, [NativeTypeName("UINT_PTR[]")] ulong* rootIds)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, uint, ulong*, COR_PRF_GC_ROOT_KIND*, COR_PRF_GC_ROOT_FLAGS*, ulong*, int>)(lpVtbl[77]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), cRootRefs, rootRefIds, rootKinds, rootFlags, rootIds);
        }

        [VtblIndex(78)]
        [return: NativeTypeName("HRESULT")]
        public int HandleCreated([NativeTypeName("GCHandleID")] ulong handleId, [NativeTypeName("ObjectID")] ulong initialObjectId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, ulong, int>)(lpVtbl[78]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), handleId, initialObjectId);
        }

        [VtblIndex(79)]
        [return: NativeTypeName("HRESULT")]
        public int HandleDestroyed([NativeTypeName("GCHandleID")] ulong handleId)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerCallback2*, ulong, int>)(lpVtbl[79]))((ICorProfilerCallback2*)Unsafe.AsPointer(ref this), handleId);
        }
    }
}
