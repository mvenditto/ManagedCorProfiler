using Windows.Win32.Foundation;
using Windows.Win32.System.Com;
using Windows.Win32.System.Diagnostics.ClrProfiling;

namespace ClrProfiling.Core.Abstractions;

public abstract class CorProfilerCallback2 : CorProfilerCallback, ICorProfilerCallback2.Interface
{
    public virtual HRESULT ThreadNameChanged(nuint threadId, uint cchName, PWSTR name)
    {
        return HRESULT.S_OK;
    }

    public unsafe virtual HRESULT GarbageCollectionStarted(int cGenerations, BOOL* generationCollected, COR_PRF_GC_REASON reason)
    {
        return HRESULT.S_OK;
    }

    public unsafe virtual HRESULT SurvivingReferences(uint cSurvivingObjectIDRanges, nuint* objectIDRangeStart, uint* cObjectIDRangeLength)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT GarbageCollectionFinished()
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT FinalizeableObjectQueued(uint finalizerFlags, nuint objectID)
    {
        return HRESULT.S_OK;
    }

    public unsafe virtual HRESULT RootReferences2(uint cRootRefs, nuint* rootRefIds, COR_PRF_GC_ROOT_KIND* rootKinds, COR_PRF_GC_ROOT_FLAGS* rootFlags, nuint* rootIds)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT HandleCreated(nuint handleId, nuint initialObjectId)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT HandleDestroyed(nuint handleId)
    {
        return HRESULT.S_OK;
    }
}
