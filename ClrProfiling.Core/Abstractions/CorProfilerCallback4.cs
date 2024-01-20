using Windows.Win32.Foundation;
using Windows.Win32.System.Diagnostics.ClrProfiling;

namespace ClrProfiling.Core.Abstractions;

public abstract class CorProfilerCallback4 : CorProfilerCallback3, ICorProfilerCallback4.Interface
{
    public virtual HRESULT ReJITCompilationStarted(nuint functionId, nuint rejitId, BOOL fIsSafeToBlock)
    {
        return HRESULT.S_OK;
    }

    public virtual unsafe HRESULT GetReJITParameters(nuint moduleId, uint methodId, ICorProfilerFunctionControl* pFunctionControl)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ReJITCompilationFinished(nuint functionId, nuint rejitId, HRESULT hrStatus, BOOL fIsSafeToBlock)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ReJITError(nuint moduleId, uint methodId, nuint functionId, HRESULT hrStatus)
    {
        return HRESULT.S_OK;
    }

    public virtual unsafe HRESULT MovedReferences2(uint cMovedObjectIDRanges, nuint* oldObjectIDRangeStart, nuint* newObjectIDRangeStart, nuint* cObjectIDRangeLength)
    {
        return HRESULT.S_OK;
    }

    public virtual unsafe HRESULT SurvivingReferences2(uint cSurvivingObjectIDRanges, nuint* objectIDRangeStart, nuint* cObjectIDRangeLength)
    {
        return HRESULT.S_OK;
    }
}
