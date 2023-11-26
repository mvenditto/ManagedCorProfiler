using CorProf.Bindings;
using CorProf.Utilities;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CorProf.ComInterop.Wrappers
{
    internal unsafe class CorProfilerComWrappers : ComWrappers
    {
        /* ICorProfilerCallback Vtable */
        //static readonly IntPtr s_ICorProfilerCallbackVtbl;
        //static readonly IntPtr s_ICorProfilerCallback2Vtbl;

        //static readonly ComInterfaceEntry* s_CorProfilerImplDefinition;
        //static readonly int s_CorProfilerImplDefinitionLen;

        private static void InitIUnknownVtbl(IntPtr* vtable)
        {
            // Get system provided IUnknown implementation.
            GetIUnknownImpl(
                out IntPtr fpQueryInterface,
                out IntPtr fpAddRef,
                out IntPtr fpRelease);

            // IUnknown
            vtable[0] = fpQueryInterface;
            vtable[1] = fpAddRef;
            vtable[2] = fpRelease;
        }

        /*
        static CorProfilerComWrappers()
        {
            // Get system provided IUnknown implementation.
            GetIUnknownImpl(
                out IntPtr fpQueryInterface,
                out IntPtr fpAddRef,
                out IntPtr fpRelease);

            // Construct VTable(s) for supported interface(s)
            // ICorProfilerCallback
            {
                int tableCount = 3 + 69;

                int idx = 0;

                var vtable = (IntPtr*)RuntimeHelpers.AllocateTypeAssociatedMemory(
                    typeof(CorProfilerComWrappers),
                    IntPtr.Size * tableCount);

                // IUnknown
                vtable[idx++] = fpQueryInterface;
                vtable[idx++] = fpAddRef;
                vtable[idx++] = fpRelease;

                // ICorProfilerCallback
                //ICorProfilerCallback Vtable
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

                Debug.Assert(tableCount == idx);

                s_ICorProfilerCallbackVtbl = (IntPtr)vtable;
            }
            {
                int tableCount = 3 + 69 + 8;

                int idx = 0;

                var vtable = (IntPtr*)RuntimeHelpers.AllocateTypeAssociatedMemory(
                    typeof(CorProfilerComWrappers),
                    IntPtr.Size * tableCount);

                // IUnknown
                vtable[idx++] = fpQueryInterface;
                vtable[idx++] = fpAddRef;
                vtable[idx++] = fpRelease;

                //ICorProfilerCallback Vtable
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

                //ICorProfilerCallback2 Vtable
                vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, uint, ushort*, int>)&ICorProfilerCallback2ManagedWrapper.ThreadNameChanged;
                vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int, int*, COR_PRF_GC_REASON, int>)&ICorProfilerCallback2ManagedWrapper.GarbageCollectionStarted;
                vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, uint, ulong*, uint*, int>)&ICorProfilerCallback2ManagedWrapper.SurvivingReferences;
                vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallback2ManagedWrapper.GarbageCollectionFinished;
                vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, uint, ulong, int>)&ICorProfilerCallback2ManagedWrapper.FinalizeableObjectQueued;
                vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, uint, ulong*, COR_PRF_GC_ROOT_KIND*, COR_PRF_GC_ROOT_FLAGS*, ulong*, int>)&ICorProfilerCallback2ManagedWrapper.RootReferences2;
                vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, ulong, int>)&ICorProfilerCallback2ManagedWrapper.HandleCreated;
                vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallback2ManagedWrapper.HandleDestroyed;

                Debug.Assert(tableCount == idx);

                s_ICorProfilerCallback2Vtbl = (nint)vtable;
            }

            //
            // Construct entries for supported managed types
            //
            {
                s_CorProfilerImplDefinitionLen = 2;
                int idx = 0;
                var entries = (ComInterfaceEntry*)RuntimeHelpers.AllocateTypeAssociatedMemory(
                    typeof(CorProfilerComWrappers),
                    sizeof(ComInterfaceEntry) * s_CorProfilerImplDefinitionLen);
                entries[idx].IID = CorProfConsts.IID_ICorProfilerCallback;
                entries[idx++].Vtable = s_ICorProfilerCallbackVtbl;
                entries[idx].IID = CorProfConsts.IID_ICorProfilerCallback2;
                entries[idx++].Vtable = s_ICorProfilerCallback2Vtbl;
                Debug.Assert(s_CorProfilerImplDefinitionLen == idx);
                s_CorProfilerImplDefinition = entries;
            }
        }*/

        readonly delegate*<IntPtr, object?> _createIfSupported;

        public CorProfilerComWrappers()
        {
            _createIfSupported = &CorProfilerDynamicWrapper.CreateIfSupported;
        }

        private class VtableDef
        {
            public uint VtableCount;
        
            public delegate* managed<IntPtr*, void> InitVtable;

            public Guid IID;
        
            public VtableDef(uint count, delegate* managed<IntPtr*, void> initVtable, Guid iid)
            {
                VtableCount = count;
                InitVtable = initVtable;
                IID = iid;
            }
        }

        private static readonly Dictionary<Type, VtableDef> _ifaceVtblTypeMap = new()
        {
            { typeof(CorProf.Core.Interfaces.ICorProfilerCallback), new(
                ICorProfilerCallbackManagedWrapper.VtblCount, 
                &ICorProfilerCallbackManagedWrapper.InitVtable,
                CorProfConsts.IID_ICorProfilerCallback) },
            { typeof(CorProf.Core.Interfaces.ICorProfilerCallback2), new(
                ICorProfilerCallback2ManagedWrapper.VtblCount,
                &ICorProfilerCallback2ManagedWrapper.InitVtable,
                CorProfConsts.IID_ICorProfilerCallback2) },
            { typeof(CorProf.Core.Interfaces.ICorProfilerCallback3), new(
                ICorProfilerCallback3ManagedWrapper.VtblCount,
                &ICorProfilerCallback3ManagedWrapper.InitVtable,
                CorProfConsts.IID_ICorProfilerCallback3) },
            { typeof(CorProf.Core.Interfaces.ICorProfilerCallback4), new(
                ICorProfilerCallback4ManagedWrapper.VtblCount,
                &ICorProfilerCallback4ManagedWrapper.InitVtable,
                CorProfConsts.IID_ICorProfilerCallback4) },
            { typeof(CorProf.Core.Interfaces.ICorProfilerCallback5), new(
                ICorProfilerCallback5ManagedWrapper.VtblCount,
                &ICorProfilerCallback5ManagedWrapper.InitVtable,
                CorProfConsts.IID_ICorProfilerCallback5) },
            { typeof(CorProf.Core.Interfaces.ICorProfilerCallback6), new(
                ICorProfilerCallback6ManagedWrapper.VtblCount,
                &ICorProfilerCallback6ManagedWrapper.InitVtable,
                CorProfConsts.IID_ICorProfilerCallback6) },
            { typeof(CorProf.Core.Interfaces.ICorProfilerCallback7), new(
                ICorProfilerCallback7ManagedWrapper.VtblCount,
                &ICorProfilerCallback7ManagedWrapper.InitVtable,
                CorProfConsts.IID_ICorProfilerCallback7) },
            { typeof(CorProf.Core.Interfaces.ICorProfilerCallback8), new(
                ICorProfilerCallback8ManagedWrapper.VtblCount,
                &ICorProfilerCallback8ManagedWrapper.InitVtable,
                CorProfConsts.IID_ICorProfilerCallback8) },
            { typeof(CorProf.Core.Interfaces.ICorProfilerCallback9), new(
                ICorProfilerCallback9ManagedWrapper.VtblCount,
                &ICorProfilerCallback9ManagedWrapper.InitVtable,
                CorProfConsts.IID_ICorProfilerCallback9) },
        };

        protected override unsafe ComInterfaceEntry* ComputeVtables(object obj, CreateComInterfaceFlags flags, out int count)
        {
            Debug.Assert(flags is CreateComInterfaceFlags.None);

            var profilerCallbackIfaces = obj
                .GetType()
                .GetInterfaces()
                .Where(x => x.Name.StartsWith("ICorProfilerCallback"))
                .ToList();

            if (!profilerCallbackIfaces.Any())
            {
                throw new ArgumentException();
            }

            var implDefinitionLen = profilerCallbackIfaces.Count();
        
            var implDef = (ComInterfaceEntry*)RuntimeHelpers.AllocateTypeAssociatedMemory(
                    typeof(CorProfilerComWrappers),
                    sizeof(ComInterfaceEntry) * implDefinitionLen);

            var idx = 0;

            for (var i = 0; i < profilerCallbackIfaces.Count(); i++)
            {
                var iface = profilerCallbackIfaces[i];

                var vtblInitializer = _ifaceVtblTypeMap[iface];

                var vtable = (IntPtr*)RuntimeHelpers.AllocateTypeAssociatedMemory(
                        typeof(CorProfilerComWrappers),
                        (int)(IntPtr.Size * vtblInitializer.VtableCount));

                InitIUnknownVtbl(vtable);

                vtblInitializer.InitVtable(vtable);

                implDef[idx].IID = vtblInitializer.IID;

                implDef[idx++].Vtable = (nint)vtable;
            }
        
            count = implDefinitionLen;

            return implDef;
        }

        protected override object? CreateObject(nint externalComObject, CreateObjectFlags flags)
        {
            Debug.Assert(flags.HasFlag(CreateObjectFlags.UniqueInstance));

            // Throw an exception if the type is not supported by the implementation.
            // Null can be returned as well, but an ArgumentNullException will be thrown for
            // the consumer of this ComWrappers instance.
            return _createIfSupported(externalComObject) ?? throw new NotSupportedException();
        }

        protected override void ReleaseObjects(IEnumerable objects)
        {
            throw new NotImplementedException();
        }
    }
}
