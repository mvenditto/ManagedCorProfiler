using CorProf.Bindings;

namespace CorProf.Core.Interfaces
{
    /// <summary>
    /// <remarks>
    /// For the .NET Framework version 2.0 or later, the profiler must also implement the ICorProfilerCallback2
    /// </remarks>
    /// </summary>
    public unsafe interface ICorProfilerCallback
    {
        public readonly static Guid IID_ICorProfilerCallback = new("176fbed1-a55c-4796-98ca-a9da0ef883e7");

        int QueryInterface(Guid* riid, void** ppvObject);
        uint AddRef();
        uint Release();
        int Initialize(IUnknown* pICorProfilerInfoUnk);
        int Shutdown();
        int AppDomainCreationStarted(ulong appDomainId);
        int AppDomainCreationFinished(ulong appDomainId, int hrStatus);
        int AppDomainShutdownStarted(ulong appDomainId);
        int AppDomainShutdownFinished(ulong appDomainId, int hrStatus);
        int AssemblyLoadStarted(ulong assemblyId);
        int AssemblyLoadFinished(ulong assemblyId, int hrStatus);
        int AssemblyUnloadStarted(ulong assemblyId);
        int AssemblyUnloadFinished(ulong assemblyId, int hrStatus);
        int ModuleLoadStarted(ulong moduleId);
        int ModuleLoadFinished(ulong moduleId, int hrStatus);
        int ModuleUnloadStarted(ulong moduleId);
        int ModuleUnloadFinished(ulong moduleId, int hrStatus);
        int ModuleAttachedToAssembly(ulong moduleId, ulong AssemblyId);
        int ClassLoadStarted(ulong classId);
        int ClassLoadFinished(ulong classId, int hrStatus);
        int ClassUnloadStarted(ulong classId);
        int ClassUnloadFinished(ulong classId, int hrStatus);
        int FunctionUnloadStarted(ulong functionId);
        int JITCompilationStarted(ulong functionId, int fIsSafeToBlock);
        int JITCompilationFinished(ulong functionId, int hrStatus, int fIsSafeToBlock);
        int JITCachedFunctionSearchStarted(ulong functionId, int* pbUseCachedFunction);
        int JITCachedFunctionSearchFinished(ulong functionId, COR_PRF_JIT_CACHE result);
        int JITFunctionPitched(ulong functionId);
        int JITInlining(ulong callerId, ulong calleeId, int* pfShouldInline);
        int ThreadCreated(ulong threadId);
        int ThreadDestroyed(ulong threadId);
        int ThreadAssignedToOSThread(ulong managedThreadId, uint osThreadId);
        int RemotingClientInvocationStarted();
        int RemotingClientSendingMessage(Guid* pCookie, int fIsAsync);
        int RemotingClientReceivingReply(Guid* pCookie, int fIsAsync);
        int RemotingClientInvocationFinished();
        int RemotingServerReceivingMessage(Guid* pCookie, int fIsAsync);
        int RemotingServerInvocationStarted();
        int RemotingServerInvocationReturned();
        int RemotingServerSendingReply(Guid* pCookie, int fIsAsync);
        int UnmanagedToManagedTransition(ulong functionId, COR_PRF_TRANSITION_REASON reason);
        int ManagedToUnmanagedTransition(ulong functionId, COR_PRF_TRANSITION_REASON reason);
        int RuntimeSuspendStarted(COR_PRF_SUSPEND_REASON suspendReason);
        int RuntimeSuspendFinished();
        int RuntimeSuspendAborted();
        int RuntimeResumeStarted();
        int RuntimeResumeFinished();
        int RuntimeThreadSuspended(ulong threadId);
        int RuntimeThreadResumed(ulong threadId);
        int MovedReferences(uint cMovedObjectIDRanges, ulong* oldObjectIDRangeStart, ulong* newObjectIDRangeStart, uint* cObjectIDRangeLength);
        int ObjectAllocated(ulong objectId, ulong classId);
        int ObjectsAllocatedByClass(uint cClassCount, ulong* classIds, uint* cObjects);
        int ObjectReferences(ulong objectId, ulong classId, uint cObjectRefs, ulong* objectRefIds);
        int RootReferences(uint cRootRefs, ulong* rootRefIds);
        int ExceptionThrown(ulong thrownObjectId);
        int ExceptionSearchFunctionEnter(ulong functionId);
        int ExceptionSearchFunctionLeave();
        int ExceptionSearchFilterEnter(ulong functionId);
        int ExceptionSearchFilterLeave();
        int ExceptionSearchCatcherFound(ulong functionId);
        int ExceptionOSHandlerEnter(ulong __unused);
        int ExceptionOSHandlerLeave(ulong __unused);
        int ExceptionUnwindFunctionEnter(ulong functionId);
        int ExceptionUnwindFunctionLeave();
        int ExceptionUnwindFinallyEnter(ulong functionId);
        int ExceptionUnwindFinallyLeave();
        int ExceptionCatcherEnter(ulong functionId, ulong objectId);
        int ExceptionCatcherLeave();
        int COMClassicVTableCreated(ulong wrappedClassId, Guid* implementedIID, void* pVTable, uint cSlots);
        int COMClassicVTableDestroyed(ulong wrappedClassId, Guid* implementedIID, void* pVTable);
        int ExceptionCLRCatcherFound();
        int ExceptionCLRCatcherExecute();
    }
}