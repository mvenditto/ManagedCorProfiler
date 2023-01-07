using CorProf.Bindings;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.ComWrappers;
using ICorProfilerCallback2 = CorProf.Core.Interfaces.ICorProfilerCallback2;

namespace ManagedCorProfiler.ComInterop.Wrappers
{
    static unsafe class ICorProfilerCallback2ManagedWrapper
    {

        [UnmanagedCallersOnly]
        public static unsafe int ThreadNameChanged(IntPtr _this, ulong threadId, uint cchName, ushort* name)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback2>((ComInterfaceDispatch*)_this)
                    .ThreadNameChanged(threadId, cchName, name);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int GarbageCollectionStarted(IntPtr _this, int cGenerations, int* generationCollected, COR_PRF_GC_REASON reason)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback2>((ComInterfaceDispatch*)_this)
                    .GarbageCollectionStarted(cGenerations, generationCollected, reason);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int SurvivingReferences(IntPtr _this, uint cSurvivingObjectIDRanges, ulong* objectIDRangeStart, uint* cObjectIDRangeLength)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback2>((ComInterfaceDispatch*)_this)
                    .SurvivingReferences(cSurvivingObjectIDRanges, objectIDRangeStart, cObjectIDRangeLength);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int GarbageCollectionFinished(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback2>((ComInterfaceDispatch*)_this)
                    .GarbageCollectionFinished();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int FinalizeableObjectQueued(IntPtr _this, uint finalizerFlags, ulong objectID)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback2>((ComInterfaceDispatch*)_this)
                    .FinalizeableObjectQueued(finalizerFlags, objectID);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int RootReferences2(IntPtr _this, uint cRootRefs, ulong* rootRefIds, COR_PRF_GC_ROOT_KIND* rootKinds, COR_PRF_GC_ROOT_FLAGS* rootFlags, ulong* rootIds)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback2>((ComInterfaceDispatch*)_this)
                    .RootReferences2(cRootRefs, rootRefIds, rootKinds, rootFlags, rootIds);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int HandleCreated(IntPtr _this, ulong handleId, ulong initialObjectId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback2>((ComInterfaceDispatch*)_this)
                    .HandleCreated(handleId, initialObjectId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        [UnmanagedCallersOnly]
        public static unsafe int HandleDestroyed(IntPtr _this, ulong handleId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback2>((ComInterfaceDispatch*)_this)
                    .HandleDestroyed(handleId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        public readonly static uint VtblCount = /* ICorProfilerCallback */ 69 + 
            /* IUnknown */ 3 
            + 8;

        public static void InitVtable(IntPtr* vtable)
        {
            ICorProfilerCallbackManagedWrapper.InitVtable(vtable);

            var idx = ICorProfilerCallbackManagedWrapper.VtblCount;

            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, uint, ushort*, int>)&ICorProfilerCallback2ManagedWrapper.ThreadNameChanged;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int, int*, COR_PRF_GC_REASON, int>)&ICorProfilerCallback2ManagedWrapper.GarbageCollectionStarted;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, uint, ulong*, uint*, int>)&ICorProfilerCallback2ManagedWrapper.SurvivingReferences;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ICorProfilerCallback2ManagedWrapper.GarbageCollectionFinished;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, uint, ulong, int>)&ICorProfilerCallback2ManagedWrapper.FinalizeableObjectQueued;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, uint, ulong*, COR_PRF_GC_ROOT_KIND*, COR_PRF_GC_ROOT_FLAGS*, ulong*, int>)&ICorProfilerCallback2ManagedWrapper.RootReferences2;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, ulong, int>)&ICorProfilerCallback2ManagedWrapper.HandleCreated;
            vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ICorProfilerCallback2ManagedWrapper.HandleDestroyed;
            Debug.Assert(VtblCount == idx);
        }
    }
}