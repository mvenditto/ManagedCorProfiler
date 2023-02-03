using CorProf.Bindings;
using CorProf.Core.Interfaces;

namespace CorProf.Core.Abstractions
{
    public abstract class CorProfilerCallback : ICorProfilerCallback
    {
        public virtual uint AddRef()
        {
            return 0;
        }

        public virtual  int AppDomainCreationFinished(ulong appDomainId, int hrStatus)
        {
            return 0;
        }

        public virtual  int AppDomainCreationStarted(ulong appDomainId)
        {
            return 0;
        }

        public virtual  int AppDomainShutdownFinished(ulong appDomainId, int hrStatus)
        {
            return 0;
        }

        public virtual  int AppDomainShutdownStarted(ulong appDomainId)
        {
            return 0;
        }

        public virtual  int AssemblyLoadFinished(ulong assemblyId, int hrStatus)
        {
            return 0;
        }

        public virtual  int AssemblyLoadStarted(ulong assemblyId)
        {
            return 0;
        }

        public virtual  int AssemblyUnloadFinished(ulong assemblyId, int hrStatus)
        {
            return 0;
        }

        public virtual  int AssemblyUnloadStarted(ulong assemblyId)
        {
            return 0;
        }

        public virtual  int ClassLoadFinished(ulong classId, int hrStatus)
        {
            return 0;
        }

        public virtual  int ClassLoadStarted(ulong classId)
        {
            return 0;
        }

        public virtual  int ClassUnloadFinished(ulong classId, int hrStatus)
        {
            return 0;
        }

        public virtual  int ClassUnloadStarted(ulong classId)
        {
            return 0;
        }

        public virtual  unsafe int COMClassicVTableCreated(ulong wrappedClassId, Guid* implementedIID, void* pVTable, uint cSlots)
        {
            return 0;
        }

        public virtual  unsafe int COMClassicVTableDestroyed(ulong wrappedClassId, Guid* implementedIID, void* pVTable)
        {
            return 0;
        }

        public virtual  int ExceptionCatcherEnter(ulong functionId, ulong objectId)
        {
            return 0;
        }

        public virtual  int ExceptionCatcherLeave()
        {
            return 0;
        }

        public virtual  int ExceptionCLRCatcherExecute()
        {
            return 0;
        }

        public virtual  int ExceptionCLRCatcherFound()
        {
            return 0;
        }

        public virtual  int ExceptionOSHandlerEnter(ulong __unused)
        {
            return 0;
        }

        public virtual  int ExceptionOSHandlerLeave(ulong __unused)
        {
            return 0;
        }

        public virtual  int ExceptionSearchCatcherFound(ulong functionId)
        {
            return 0;
        }

        public virtual  int ExceptionSearchFilterEnter(ulong functionId)
        {
            return 0;
        }

        public virtual  int ExceptionSearchFilterLeave()
        {
            return 0;
        }

        public virtual  int ExceptionSearchFunctionEnter(ulong functionId)
        {
            return 0;
        }

        public virtual  int ExceptionSearchFunctionLeave()
        {
            return 0;
        }

        public virtual  int ExceptionThrown(ulong thrownObjectId)
        {
            return 0;
        }

        public virtual  int ExceptionUnwindFinallyEnter(ulong functionId)
        {
            return 0;
        }

        public virtual  int ExceptionUnwindFinallyLeave()
        {
            return 0;
        }

        public virtual  int ExceptionUnwindFunctionEnter(ulong functionId)
        {
            return 0;
        }

        public virtual  int ExceptionUnwindFunctionLeave()
        {
            return 0;
        }

        public virtual  int FunctionUnloadStarted(ulong functionId)
        {
            return 0;
        }

        public virtual  unsafe int Initialize(IUnknown* pICorProfilerInfoUnk)
        {
            return 0;
        }

        public virtual  int JITCachedFunctionSearchFinished(ulong functionId, COR_PRF_JIT_CACHE result)
        {
            return 0;
        }

        public virtual  unsafe int JITCachedFunctionSearchStarted(ulong functionId, int* pbUseCachedFunction)
        {
            return 0;
        }

        public virtual  int JITCompilationFinished(ulong functionId, int hrStatus, int fIsSafeToBlock)
        {
            return 0;
        }

        public virtual  int JITCompilationStarted(ulong functionId, int fIsSafeToBlock)
        {
            return 0;
        }

        public virtual  int JITFunctionPitched(ulong functionId)
        {
            return 0;
        }

        public virtual  unsafe int JITInlining(ulong callerId, ulong calleeId, int* pfShouldInline)
        {
            return 0;
        }

        public virtual  int ManagedToUnmanagedTransition(ulong functionId, COR_PRF_TRANSITION_REASON reason)
        {
            return 0;
        }

        public virtual  int ModuleAttachedToAssembly(ulong moduleId, ulong AssemblyId)
        {
            return 0;
        }

        public virtual  int ModuleLoadFinished(ulong moduleId, int hrStatus)
        {
            return 0;
        }

        public virtual  int ModuleLoadStarted(ulong moduleId)
        {
            return 0;
        }

        public virtual  int ModuleUnloadFinished(ulong moduleId, int hrStatus)
        {
            return 0;
        }

        public virtual  int ModuleUnloadStarted(ulong moduleId)
        {
            return 0;
        }

        public virtual  unsafe int MovedReferences(uint cMovedObjectIDRanges, ulong* oldObjectIDRangeStart, ulong* newObjectIDRangeStart, uint* cObjectIDRangeLength)
        {
            return 0;
        }

        public virtual  int ObjectAllocated(ulong objectId, ulong classId)
        {
            return 0;
        }

        public virtual  unsafe int ObjectReferences(ulong objectId, ulong classId, uint cObjectRefs, ulong* objectRefIds)
        {
            return 0;
        }

        public virtual  unsafe int ObjectsAllocatedByClass(uint cClassCount, ulong* classIds, uint* cObjects)
        {
            return 0;
        }

        public virtual  unsafe int QueryInterface(Guid* riid, void** ppvObject)
        {
            return 0;
        }

        public virtual  uint Release()
        {
            return 0;
        }

        public virtual  int RemotingClientInvocationFinished()
        {
            return 0;
        }

        public virtual  int RemotingClientInvocationStarted()
        {
            return 0;
        }

        public virtual  unsafe int RemotingClientReceivingReply(Guid* pCookie, int fIsAsync)
        {
            return 0;
        }

        public virtual  unsafe int RemotingClientSendingMessage(Guid* pCookie, int fIsAsync)
        {
            return 0;
        }

        public virtual  int RemotingServerInvocationReturned()
        {
            return 0;
        }

        public virtual  int RemotingServerInvocationStarted()
        {
            return 0;
        }

        public virtual  unsafe int RemotingServerReceivingMessage(Guid* pCookie, int fIsAsync)
        {
            return 0;
        }

        public virtual  unsafe int RemotingServerSendingReply(Guid* pCookie, int fIsAsync)
        {
            return 0;
        }

        public virtual  unsafe int RootReferences(uint cRootRefs, ulong* rootRefIds)
        {
            return 0;
        }

        public virtual  int RuntimeResumeFinished()
        {
            return 0;
        }

        public virtual  int RuntimeResumeStarted()
        {
            return 0;
        }

        public virtual  int RuntimeSuspendAborted()
        {
            return 0;
        }

        public virtual  int RuntimeSuspendFinished()
        {
            return 0;
        }

        public virtual  int RuntimeSuspendStarted(COR_PRF_SUSPEND_REASON suspendReason)
        {
            return 0;
        }

        public virtual  int RuntimeThreadResumed(ulong threadId)
        {
            return 0;
        }

        public virtual  int RuntimeThreadSuspended(ulong threadId)
        {
            return 0;
        }

        public virtual  int Shutdown()
        {
            return 0;
        }

        public virtual  int ThreadAssignedToOSThread(ulong managedThreadId, uint osThreadId)
        {
            return 0;
        }

        public virtual  int ThreadCreated(ulong threadId)
        {
            return 0;
        }

        public virtual  int ThreadDestroyed(ulong threadId)
        {
            return 0;
        }

        public virtual  int UnmanagedToManagedTransition(ulong functionId, COR_PRF_TRANSITION_REASON reason)
        {
            return 0;
        }
    }
}
