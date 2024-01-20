using Windows.Win32.Foundation;
using Windows.Win32.System.Diagnostics.ClrProfiling;

namespace ClrProfiling.Core.Abstractions;

public abstract class CorProfilerCallback5 : CorProfilerCallback4, ICorProfilerCallback5.Interface
{
    public virtual unsafe HRESULT ConditionalWeakTableElementReferences(uint cRootRefs, nuint* keyRefIds, nuint* valueRefIds, nuint* rootIds)
    {
        return HRESULT.S_OK;
    }
}
