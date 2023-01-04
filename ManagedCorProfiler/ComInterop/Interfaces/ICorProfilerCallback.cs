using CorProf.Bindings;
using ManagedCorProfiler.ComInterop;
using ManagedCorProfiler.Utilities;
using Microsoft.Diagnostics.Runtime.Utilities;

namespace ManagedCorProfiler.ComInterop.Interfaces
{
    public unsafe interface ICorProfilerCallback
    {
        public readonly static Guid IID_ICorProfilerCallback = new("176fbed1-a55c-4796-98ca-a9da0ef883e7");

        int QueryInterface(Guid* riid, void** ppvObject) { return HResult.S_OK; }
        uint AddRef() { return HResult.S_OK; }
        uint Release() { return HResult.S_OK; }
        int Initialize(IUnknown* pICorProfilerInfoUnk) { return HResult.S_OK; }
        int Shutdown() { return HResult.S_OK; }
        int AppDomainCreationStarted(ulong appDomainId) { return HResult.S_OK; }
        int AppDomainCreationFinished(ulong appDomainId, int hrStatus) { return HResult.S_OK; }
        int AppDomainShutdownStarted(ulong appDomainId) { return HResult.S_OK; }
        int AppDomainShutdownFinished(ulong appDomainId, int hrStatus) { return HResult.S_OK; }
        int AssemblyLoadStarted(ulong assemblyId) { return HResult.S_OK; }
        int AssemblyLoadFinished(ulong assemblyId, int hrStatus) { return HResult.S_OK; }
        int AssemblyUnloadStarted(ulong assemblyId) { return HResult.S_OK; }
        int AssemblyUnloadFinished(ulong assemblyId, int hrStatus) { return HResult.S_OK; }
        int ModuleLoadStarted(ulong moduleId) { return HResult.S_OK; }
        int ModuleLoadFinished(ulong moduleId, int hrStatus) { return HResult.S_OK; }
        int ModuleUnloadStarted(ulong moduleId) { return HResult.S_OK; }
        int ModuleUnloadFinished(ulong moduleId, int hrStatus) { return HResult.S_OK; }
        int ModuleAttachedToAssembly(ulong moduleId, ulong AssemblyId) { return HResult.S_OK; }
        int ClassLoadStarted(ulong classId) { return HResult.S_OK; }
        int ClassLoadFinished(ulong classId, int hrStatus) { return HResult.S_OK; }
        int ClassUnloadStarted(ulong classId) { return HResult.S_OK; }
        int ClassUnloadFinished(ulong classId, int hrStatus) { return HResult.S_OK; }
        int FunctionUnloadStarted(ulong functionId) { return HResult.S_OK; }
        int JITCompilationStarted(ulong functionId, int fIsSafeToBlock) { return HResult.S_OK; }
        int JITCompilationFinished(ulong functionId, int hrStatus, int fIsSafeToBlock) { return HResult.S_OK; }
        int JITCachedFunctionSearchStarted(ulong functionId, int* pbUseCachedFunction) { return HResult.S_OK; }
        int JITCachedFunctionSearchFinished(ulong functionId, COR_PRF_JIT_CACHE result) { return HResult.S_OK; }
        int JITFunctionPitched(ulong functionId) { return HResult.S_OK; }
        int JITInlining(ulong callerId, ulong calleeId, int* pfShouldInline) { return HResult.S_OK; }
        int ThreadCreated(ulong threadId) { return HResult.S_OK; }
        int ThreadDestroyed(ulong threadId) { return HResult.S_OK; }
        int ThreadAssignedToOSThread(ulong managedThreadId, uint osThreadId) { return HResult.S_OK; }
        int RemotingClientInvocationStarted() { return HResult.S_OK; }
        int RemotingClientSendingMessage(Guid* pCookie, int fIsAsync) { return HResult.S_OK; }
        int RemotingClientReceivingReply(Guid* pCookie, int fIsAsync) { return HResult.S_OK; }
        int RemotingClientInvocationFinished() { return HResult.S_OK; }
        int RemotingServerReceivingMessage(Guid* pCookie, int fIsAsync) { return HResult.S_OK; }
        int RemotingServerInvocationStarted() { return HResult.S_OK; }
        int RemotingServerInvocationReturned() { return HResult.S_OK; }
        int RemotingServerSendingReply(Guid* pCookie, int fIsAsync) { return HResult.S_OK; }
        int UnmanagedToManagedTransition(ulong functionId, COR_PRF_TRANSITION_REASON reason) { return HResult.S_OK; }
        int ManagedToUnmanagedTransition(ulong functionId, COR_PRF_TRANSITION_REASON reason) { return HResult.S_OK; }
        int RuntimeSuspendStarted(COR_PRF_SUSPEND_REASON suspendReason) { return HResult.S_OK; }
        int RuntimeSuspendFinished() { return HResult.S_OK; }
        int RuntimeSuspendAborted() { return HResult.S_OK; }
        int RuntimeResumeStarted() { return HResult.S_OK; }
        int RuntimeResumeFinished() { return HResult.S_OK; }
        int RuntimeThreadSuspended(ulong threadId) { return HResult.S_OK; }
        int RuntimeThreadResumed(ulong threadId) { return HResult.S_OK; }
        int MovedReferences(uint cMovedObjectIDRanges, ulong* oldObjectIDRangeStart, ulong* newObjectIDRangeStart, uint* cObjectIDRangeLength) { return HResult.S_OK; }
        int ObjectAllocated(ulong objectId, ulong classId) { return HResult.S_OK; }
        int ObjectsAllocatedByClass(uint cClassCount, ulong* classIds, uint* cObjects) { return HResult.S_OK; }
        int ObjectReferences(ulong objectId, ulong classId, uint cObjectRefs, ulong* objectRefIds) { return HResult.S_OK; }
        int RootReferences(uint cRootRefs, ulong* rootRefIds) { return HResult.S_OK; }
        int ExceptionThrown(ulong thrownObjectId) { return HResult.S_OK; }
        int ExceptionSearchFunctionEnter(ulong functionId) { return HResult.S_OK; }
        int ExceptionSearchFunctionLeave() { return HResult.S_OK; }
        int ExceptionSearchFilterEnter(ulong functionId) { return HResult.S_OK; }
        int ExceptionSearchFilterLeave() { return HResult.S_OK; }
        int ExceptionSearchCatcherFound(ulong functionId) { return HResult.S_OK; }
        int ExceptionOSHandlerEnter(ulong __unused) { return HResult.S_OK; }
        int ExceptionOSHandlerLeave(ulong __unused) { return HResult.S_OK; }
        int ExceptionUnwindFunctionEnter(ulong functionId) { return HResult.S_OK; }
        int ExceptionUnwindFunctionLeave() { return HResult.S_OK; }
        int ExceptionUnwindFinallyEnter(ulong functionId) { return HResult.S_OK; }
        int ExceptionUnwindFinallyLeave() { return HResult.S_OK; }
        int ExceptionCatcherEnter(ulong functionId, ulong objectId) { return HResult.S_OK; }
        int ExceptionCatcherLeave() { return HResult.S_OK; }
        int COMClassicVTableCreated(ulong wrappedClassId, Guid* implementedIID, void* pVTable, uint cSlots) { return HResult.S_OK; }
        int COMClassicVTableDestroyed(ulong wrappedClassId, Guid* implementedIID, void* pVTable) { return HResult.S_OK; }
        int ExceptionCLRCatcherFound() { return HResult.S_OK; }
        int ExceptionCLRCatcherExecute() { return HResult.S_OK; }
    }
}