using Windows.Win32.Foundation;
using Windows.Win32.System.Com;
using Windows.Win32.System.Diagnostics.ClrProfiling;

namespace ClrProfiling.Core.Abstractions;

public abstract class CorProfilerCallback3 : CorProfilerCallback2, ICorProfilerCallback3.Interface
{
    public virtual unsafe HRESULT InitializeForAttach(IUnknown* pCorProfilerInfoUnk, void* pvClientData, uint cbClientData)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ProfilerAttachComplete()
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT ProfilerDetachSucceeded()
    {
        return HRESULT.S_OK;
    }
}
