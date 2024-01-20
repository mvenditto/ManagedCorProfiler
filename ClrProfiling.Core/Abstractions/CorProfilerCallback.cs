using Windows.Win32.Foundation;
using Windows.Win32.System.Com;
using Windows.Win32.System.Diagnostics.ClrProfiling;

namespace ClrProfiling.Core.Abstractions;

public abstract class CorProfilerCallback : ICorProfilerCallback.Interface
{
    public virtual unsafe HRESULT Initialize(IUnknown* pICorProfilerInfoUnk)
    {
        return HRESULT.E_FAIL;
    }

    public virtual HRESULT Shutdown()
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT AppDomainCreationStarted(nuint appDomainId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT AppDomainCreationFinished(nuint appDomainId, HRESULT hrStatus)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT AppDomainShutdownStarted(nuint appDomainId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT AppDomainShutdownFinished(nuint appDomainId, HRESULT hrStatus)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT AssemblyLoadStarted(nuint assemblyId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT AssemblyLoadFinished(nuint assemblyId, HRESULT hrStatus)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT AssemblyUnloadStarted(nuint assemblyId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT AssemblyUnloadFinished(nuint assemblyId, HRESULT hrStatus)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ModuleLoadStarted(nuint moduleId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ModuleLoadFinished(nuint moduleId, HRESULT hrStatus)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ModuleUnloadStarted(nuint moduleId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ModuleUnloadFinished(nuint moduleId, HRESULT hrStatus)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ModuleAttachedToAssembly(nuint moduleId, nuint AssemblyId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ClassLoadStarted(nuint classId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ClassLoadFinished(nuint classId, HRESULT hrStatus)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ClassUnloadStarted(nuint classId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ClassUnloadFinished(nuint classId, HRESULT hrStatus)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT FunctionUnloadStarted(nuint functionId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT JITCompilationStarted(nuint functionId, BOOL fIsSafeToBlock)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT JITCompilationFinished(nuint functionId, HRESULT hrStatus, BOOL fIsSafeToBlock)
    {
        return HRESULT.S_OK;
    }

    public virtual unsafe HRESULT JITCachedFunctionSearchStarted(nuint functionId, BOOL* pbUseCachedFunction)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT JITCachedFunctionSearchFinished(nuint functionId, COR_PRF_JIT_CACHE result)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT JITFunctionPitched(nuint functionId)
    {
        return HRESULT.S_OK;
    }

    public virtual unsafe HRESULT JITInlining(nuint callerId, nuint calleeId, BOOL* pfShouldInline)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ThreadCreated(nuint threadId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ThreadDestroyed(nuint threadId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ThreadAssignedToOSThread(nuint managedThreadId, uint osThreadId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT RemotingClientInvocationStarted()
    {
        return HRESULT.S_OK;
    }

    public virtual unsafe HRESULT RemotingClientSendingMessage(Guid* pCookie, BOOL fIsAsync)
    {
        return HRESULT.S_OK;
    }

    public virtual unsafe HRESULT RemotingClientReceivingReply(Guid* pCookie, BOOL fIsAsync)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT RemotingClientInvocationFinished()
    {
        return HRESULT.S_OK;
    }

    public virtual unsafe HRESULT RemotingServerReceivingMessage(Guid* pCookie, BOOL fIsAsync)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT RemotingServerInvocationStarted()
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT RemotingServerInvocationReturned()
    {
        return HRESULT.S_OK;
    }

    public virtual unsafe HRESULT RemotingServerSendingReply(Guid* pCookie, BOOL fIsAsync)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT UnmanagedToManagedTransition(nuint functionId, COR_PRF_TRANSITION_REASON reason)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ManagedToUnmanagedTransition(nuint functionId, COR_PRF_TRANSITION_REASON reason)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT RuntimeSuspendStarted(COR_PRF_SUSPEND_REASON suspendReason)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT RuntimeSuspendFinished()
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT RuntimeSuspendAborted()
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT RuntimeResumeStarted()
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT RuntimeResumeFinished()
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT RuntimeThreadSuspended(nuint threadId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT RuntimeThreadResumed(nuint threadId)
    {
        return HRESULT.S_OK;
    }

    public virtual unsafe HRESULT MovedReferences(uint cMovedObjectIDRanges, nuint* oldObjectIDRangeStart, nuint* newObjectIDRangeStart, uint* cObjectIDRangeLength)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ObjectAllocated(nuint objectId, nuint classId)
    {
        return HRESULT.S_OK;
    }

    public virtual unsafe HRESULT ObjectsAllocatedByClass(uint cClassCount, nuint* classIds, uint* cObjects)
    {
        return HRESULT.S_OK;
    }

    public virtual unsafe HRESULT ObjectReferences(nuint objectId, nuint classId, uint cObjectRefs, nuint* objectRefIds)
    {
        return HRESULT.S_OK;
    }

    public virtual unsafe HRESULT RootReferences(uint cRootRefs, nuint* rootRefIds)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ExceptionThrown(nuint thrownObjectId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ExceptionSearchFunctionEnter(nuint functionId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ExceptionSearchFunctionLeave()
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ExceptionSearchFilterEnter(nuint functionId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ExceptionSearchFilterLeave()
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ExceptionSearchCatcherFound(nuint functionId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ExceptionOSHandlerEnter(nuint __unused)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ExceptionOSHandlerLeave(nuint __unused)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ExceptionUnwindFunctionEnter(nuint functionId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ExceptionUnwindFunctionLeave()
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ExceptionUnwindFinallyEnter(nuint functionId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ExceptionUnwindFinallyLeave()
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ExceptionCatcherEnter(nuint functionId, nuint objectId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ExceptionCatcherLeave()
    {
        return HRESULT.S_OK;
    }

    public virtual unsafe HRESULT COMClassicVTableCreated(nuint wrappedClassId, Guid* implementedIID, void* pVTable, uint cSlots)
    {
        return HRESULT.S_OK;
    }

    public virtual unsafe HRESULT COMClassicVTableDestroyed(nuint wrappedClassId, Guid* implementedIID, void* pVTable)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ExceptionCLRCatcherFound()
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ExceptionCLRCatcherExecute()
    {
        return HRESULT.S_OK;
    }
}
