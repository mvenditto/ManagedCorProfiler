using ManagedCorProfiler.ComInterop.Interfaces;
using ManagedCorProfiler.Utilities;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.ComWrappers;

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
}
