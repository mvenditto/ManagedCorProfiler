using Windows.Win32.Foundation;
using Windows.Win32.System.Diagnostics.ClrProfiling;

namespace ClrProfiling.Core.Abstractions;

public abstract class CorProfilerCallback7 : CorProfilerCallback6, ICorProfilerCallback7.Interface
{
    public virtual HRESULT ModuleInMemorySymbolsUpdated(nuint moduleId)
    {
        return HRESULT.S_OK;
    }
}
