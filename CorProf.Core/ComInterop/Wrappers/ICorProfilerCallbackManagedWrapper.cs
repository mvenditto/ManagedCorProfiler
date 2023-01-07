using CorProf.Bindings;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.ComWrappers;
using ICorProfilerCallback = CorProf.Core.Interfaces.ICorProfilerCallback;

namespace CorProf.ComInterop.Wrappers
{
    static unsafe class ICorProfilerCallbackManagedWrapper
    {

        [UnmanagedCallersOnly]
        public static unsafe int QueryInterface(IntPtr _this, Guid* riid, void** ppvObject)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .QueryInterface(riid, ppvObject);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe uint AddRef(IntPtr _this)
        {
            try
            {
                var count = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .AddRef();

                return count;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe uint Release(IntPtr _this)
        {
            try
            {
                var count = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .Release();

                return count;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int Initialize(IntPtr _this, IUnknown* pICorProfilerInfoUnk)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .Initialize(pICorProfilerInfoUnk);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int Shutdown(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .Shutdown();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int AppDomainCreationStarted(IntPtr _this, ulong appDomainId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .AppDomainCreationStarted(appDomainId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int AppDomainCreationFinished(IntPtr _this, ulong appDomainId, int hrStatus)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .AppDomainCreationFinished(appDomainId, hrStatus);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int AppDomainShutdownStarted(IntPtr _this, ulong appDomainId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .AppDomainShutdownStarted(appDomainId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int AppDomainShutdownFinished(IntPtr _this, ulong appDomainId, int hrStatus)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .AppDomainShutdownFinished(appDomainId, hrStatus);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int AssemblyLoadStarted(IntPtr _this, ulong assemblyId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .AssemblyLoadStarted(assemblyId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int AssemblyLoadFinished(IntPtr _this, ulong assemblyId, int hrStatus)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .AssemblyLoadFinished(assemblyId, hrStatus);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int AssemblyUnloadStarted(IntPtr _this, ulong assemblyId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .AssemblyUnloadStarted(assemblyId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int AssemblyUnloadFinished(IntPtr _this, ulong assemblyId, int hrStatus)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .AssemblyUnloadFinished(assemblyId, hrStatus);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ModuleLoadStarted(IntPtr _this, ulong moduleId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ModuleLoadStarted(moduleId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ModuleLoadFinished(IntPtr _this, ulong moduleId, int hrStatus)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ModuleLoadFinished(moduleId, hrStatus);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ModuleUnloadStarted(IntPtr _this, ulong moduleId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ModuleUnloadStarted(moduleId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ModuleUnloadFinished(IntPtr _this, ulong moduleId, int hrStatus)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ModuleUnloadFinished(moduleId, hrStatus);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ModuleAttachedToAssembly(IntPtr _this, ulong moduleId, ulong AssemblyId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ModuleAttachedToAssembly(moduleId, AssemblyId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ClassLoadStarted(IntPtr _this, ulong classId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ClassLoadStarted(classId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ClassLoadFinished(IntPtr _this, ulong classId, int hrStatus)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ClassLoadFinished(classId, hrStatus);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ClassUnloadStarted(IntPtr _this, ulong classId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ClassUnloadStarted(classId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ClassUnloadFinished(IntPtr _this, ulong classId, int hrStatus)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ClassUnloadFinished(classId, hrStatus);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int FunctionUnloadStarted(IntPtr _this, ulong functionId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .FunctionUnloadStarted(functionId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int JITCompilationStarted(IntPtr _this, ulong functionId, int fIsSafeToBlock)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .JITCompilationStarted(functionId, fIsSafeToBlock);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int JITCompilationFinished(IntPtr _this, ulong functionId, int hrStatus, int fIsSafeToBlock)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .JITCompilationFinished(functionId, hrStatus, fIsSafeToBlock);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int JITCachedFunctionSearchStarted(IntPtr _this, ulong functionId, int* pbUseCachedFunction)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .JITCachedFunctionSearchStarted(functionId, pbUseCachedFunction);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int JITCachedFunctionSearchFinished(IntPtr _this, ulong functionId, COR_PRF_JIT_CACHE result)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .JITCachedFunctionSearchFinished(functionId, result);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int JITFunctionPitched(IntPtr _this, ulong functionId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .JITFunctionPitched(functionId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int JITInlining(IntPtr _this, ulong callerId, ulong calleeId, int* pfShouldInline)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .JITInlining(callerId, calleeId, pfShouldInline);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ThreadCreated(IntPtr _this, ulong threadId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ThreadCreated(threadId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ThreadDestroyed(IntPtr _this, ulong threadId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ThreadDestroyed(threadId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ThreadAssignedToOSThread(IntPtr _this, ulong managedThreadId, uint osThreadId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ThreadAssignedToOSThread(managedThreadId, osThreadId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RemotingClientInvocationStarted(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .RemotingClientInvocationStarted();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RemotingClientSendingMessage(IntPtr _this, Guid* pCookie, int fIsAsync)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .RemotingClientSendingMessage(pCookie, fIsAsync);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RemotingClientReceivingReply(IntPtr _this, Guid* pCookie, int fIsAsync)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .RemotingClientReceivingReply(pCookie, fIsAsync);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RemotingClientInvocationFinished(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .RemotingClientInvocationFinished();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RemotingServerReceivingMessage(IntPtr _this, Guid* pCookie, int fIsAsync)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .RemotingServerReceivingMessage(pCookie, fIsAsync);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RemotingServerInvocationStarted(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .RemotingServerInvocationStarted();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RemotingServerInvocationReturned(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .RemotingServerInvocationReturned();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RemotingServerSendingReply(IntPtr _this, Guid* pCookie, int fIsAsync)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .RemotingServerSendingReply(pCookie, fIsAsync);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int UnmanagedToManagedTransition(IntPtr _this, ulong functionId, COR_PRF_TRANSITION_REASON reason)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .UnmanagedToManagedTransition(functionId, reason);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ManagedToUnmanagedTransition(IntPtr _this, ulong functionId, COR_PRF_TRANSITION_REASON reason)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ManagedToUnmanagedTransition(functionId, reason);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RuntimeSuspendStarted(IntPtr _this, COR_PRF_SUSPEND_REASON suspendReason)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .RuntimeSuspendStarted(suspendReason);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RuntimeSuspendFinished(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .RuntimeSuspendFinished();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RuntimeSuspendAborted(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .RuntimeSuspendAborted();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RuntimeResumeStarted(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .RuntimeResumeStarted();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RuntimeResumeFinished(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .RuntimeResumeFinished();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RuntimeThreadSuspended(IntPtr _this, ulong threadId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .RuntimeThreadSuspended(threadId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RuntimeThreadResumed(IntPtr _this, ulong threadId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .RuntimeThreadResumed(threadId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int MovedReferences(IntPtr _this, uint cMovedObjectIDRanges, ulong* oldObjectIDRangeStart, ulong* newObjectIDRangeStart, uint* cObjectIDRangeLength)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .MovedReferences(cMovedObjectIDRanges, oldObjectIDRangeStart, newObjectIDRangeStart, cObjectIDRangeLength);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ObjectAllocated(IntPtr _this, ulong objectId, ulong classId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ObjectAllocated(objectId, classId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ObjectsAllocatedByClass(IntPtr _this, uint cClassCount, ulong* classIds, uint* cObjects)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ObjectsAllocatedByClass(cClassCount, classIds, cObjects);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ObjectReferences(IntPtr _this, ulong objectId, ulong classId, uint cObjectRefs, ulong* objectRefIds)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ObjectReferences(objectId, classId, cObjectRefs, objectRefIds);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RootReferences(IntPtr _this, uint cRootRefs, ulong* rootRefIds)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .RootReferences(cRootRefs, rootRefIds);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ExceptionThrown(IntPtr _this, ulong thrownObjectId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ExceptionThrown(thrownObjectId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ExceptionSearchFunctionEnter(IntPtr _this, ulong functionId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ExceptionSearchFunctionEnter(functionId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ExceptionSearchFunctionLeave(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ExceptionSearchFunctionLeave();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ExceptionSearchFilterEnter(IntPtr _this, ulong functionId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ExceptionSearchFilterEnter(functionId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ExceptionSearchFilterLeave(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ExceptionSearchFilterLeave();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ExceptionSearchCatcherFound(IntPtr _this, ulong functionId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ExceptionSearchCatcherFound(functionId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ExceptionOSHandlerEnter(IntPtr _this, ulong __unused)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ExceptionOSHandlerEnter(__unused);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ExceptionOSHandlerLeave(IntPtr _this, ulong __unused)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ExceptionOSHandlerLeave(__unused);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ExceptionUnwindFunctionEnter(IntPtr _this, ulong functionId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ExceptionUnwindFunctionEnter(functionId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ExceptionUnwindFunctionLeave(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ExceptionUnwindFunctionLeave();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ExceptionUnwindFinallyEnter(IntPtr _this, ulong functionId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ExceptionUnwindFinallyEnter(functionId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ExceptionUnwindFinallyLeave(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ExceptionUnwindFinallyLeave();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ExceptionCatcherEnter(IntPtr _this, ulong functionId, ulong objectId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ExceptionCatcherEnter(functionId, objectId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ExceptionCatcherLeave(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ExceptionCatcherLeave();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int COMClassicVTableCreated(IntPtr _this, ulong wrappedClassId, Guid* implementedIID, void* pVTable, uint cSlots)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .COMClassicVTableCreated(wrappedClassId, implementedIID, pVTable, cSlots);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int COMClassicVTableDestroyed(IntPtr _this, ulong wrappedClassId, Guid* implementedIID, void* pVTable)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .COMClassicVTableDestroyed(wrappedClassId, implementedIID, pVTable);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ExceptionCLRCatcherFound(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ExceptionCLRCatcherFound();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int ExceptionCLRCatcherExecute(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback>((ComInterfaceDispatch*)_this)
                    .ExceptionCLRCatcherExecute();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        public readonly static uint VtblCount = 3 + 69;

        public static void InitVtable(IntPtr* vtable)
        {
            var idx = 3;

            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, IUnknown*, int>)&ICorProfilerCallbackManagedWrapper.Initialize;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallbackManagedWrapper.Shutdown;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.AppDomainCreationStarted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int, int>)&ICorProfilerCallbackManagedWrapper.AppDomainCreationFinished;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.AppDomainShutdownStarted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int, int>)&ICorProfilerCallbackManagedWrapper.AppDomainShutdownFinished;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.AssemblyLoadStarted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int, int>)&ICorProfilerCallbackManagedWrapper.AssemblyLoadFinished;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.AssemblyUnloadStarted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int, int>)&ICorProfilerCallbackManagedWrapper.AssemblyUnloadFinished;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.ModuleLoadStarted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int, int>)&ICorProfilerCallbackManagedWrapper.ModuleLoadFinished;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.ModuleUnloadStarted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int, int>)&ICorProfilerCallbackManagedWrapper.ModuleUnloadFinished;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, ulong, int>)&ICorProfilerCallbackManagedWrapper.ModuleAttachedToAssembly;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.ClassLoadStarted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int, int>)&ICorProfilerCallbackManagedWrapper.ClassLoadFinished;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.ClassUnloadStarted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int, int>)&ICorProfilerCallbackManagedWrapper.ClassUnloadFinished;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.FunctionUnloadStarted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int, int>)&ICorProfilerCallbackManagedWrapper.JITCompilationStarted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int, int, int>)&ICorProfilerCallbackManagedWrapper.JITCompilationFinished;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int*, int>)&ICorProfilerCallbackManagedWrapper.JITCachedFunctionSearchStarted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, COR_PRF_JIT_CACHE, int>)&ICorProfilerCallbackManagedWrapper.JITCachedFunctionSearchFinished;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.JITFunctionPitched;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, ulong, int*, int>)&ICorProfilerCallbackManagedWrapper.JITInlining;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.ThreadCreated;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.ThreadDestroyed;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, uint, int>)&ICorProfilerCallbackManagedWrapper.ThreadAssignedToOSThread;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallbackManagedWrapper.RemotingClientInvocationStarted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, Guid*, int, int>)&ICorProfilerCallbackManagedWrapper.RemotingClientSendingMessage;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, Guid*, int, int>)&ICorProfilerCallbackManagedWrapper.RemotingClientReceivingReply;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallbackManagedWrapper.RemotingClientInvocationFinished;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, Guid*, int, int>)&ICorProfilerCallbackManagedWrapper.RemotingServerReceivingMessage;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallbackManagedWrapper.RemotingServerInvocationStarted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallbackManagedWrapper.RemotingServerInvocationReturned;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, Guid*, int, int>)&ICorProfilerCallbackManagedWrapper.RemotingServerSendingReply;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, COR_PRF_TRANSITION_REASON, int>)&ICorProfilerCallbackManagedWrapper.UnmanagedToManagedTransition;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, COR_PRF_TRANSITION_REASON, int>)&ICorProfilerCallbackManagedWrapper.ManagedToUnmanagedTransition;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, COR_PRF_SUSPEND_REASON, int>)&ICorProfilerCallbackManagedWrapper.RuntimeSuspendStarted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallbackManagedWrapper.RuntimeSuspendFinished;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallbackManagedWrapper.RuntimeSuspendAborted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallbackManagedWrapper.RuntimeResumeStarted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallbackManagedWrapper.RuntimeResumeFinished;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.RuntimeThreadSuspended;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.RuntimeThreadResumed;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, uint, ulong*, ulong*, uint*, int>)&ICorProfilerCallbackManagedWrapper.MovedReferences;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, ulong, int>)&ICorProfilerCallbackManagedWrapper.ObjectAllocated;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, uint, ulong*, uint*, int>)&ICorProfilerCallbackManagedWrapper.ObjectsAllocatedByClass;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, ulong, uint, ulong*, int>)&ICorProfilerCallbackManagedWrapper.ObjectReferences;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, uint, ulong*, int>)&ICorProfilerCallbackManagedWrapper.RootReferences;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.ExceptionThrown;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.ExceptionSearchFunctionEnter;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallbackManagedWrapper.ExceptionSearchFunctionLeave;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.ExceptionSearchFilterEnter;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallbackManagedWrapper.ExceptionSearchFilterLeave;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.ExceptionSearchCatcherFound;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.ExceptionOSHandlerEnter;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.ExceptionOSHandlerLeave;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.ExceptionUnwindFunctionEnter;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallbackManagedWrapper.ExceptionUnwindFunctionLeave;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallbackManagedWrapper.ExceptionUnwindFinallyEnter;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallbackManagedWrapper.ExceptionUnwindFinallyLeave;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, ulong, int>)&ICorProfilerCallbackManagedWrapper.ExceptionCatcherEnter;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallbackManagedWrapper.ExceptionCatcherLeave;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, Guid*, void*, uint, int>)&ICorProfilerCallbackManagedWrapper.COMClassicVTableCreated;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, Guid*, void*, int>)&ICorProfilerCallbackManagedWrapper.COMClassicVTableDestroyed;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallbackManagedWrapper.ExceptionCLRCatcherFound;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallbackManagedWrapper.ExceptionCLRCatcherExecute;

            Debug.Assert(VtblCount == idx);
        }
    }
}