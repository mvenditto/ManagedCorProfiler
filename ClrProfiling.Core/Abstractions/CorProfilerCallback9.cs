using Windows.Win32.Foundation;
using Windows.Win32.System.Diagnostics.ClrProfiling;

namespace ClrProfiling.Core.Abstractions;

public abstract class CorProfilerCallback9 : CorProfilerCallback8, ICorProfilerCallback9.Interface
{
    public virtual HRESULT DynamicMethodUnloaded(nuint functionId)
    {
        return HRESULT.S_OK;
    }
}
