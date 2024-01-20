using Windows.Win32.Foundation;
using Windows.Win32.System.Diagnostics.ClrProfiling;

namespace ClrProfiling.Core.Abstractions;

public abstract class CorProfilerCallback8 : CorProfilerCallback7, ICorProfilerCallback8.Interface
{
    public virtual unsafe HRESULT DynamicMethodJITCompilationStarted(nuint functionId, BOOL fIsSafeToBlock, byte* pILHeader, uint cbILHeader)
    {
        return HRESULT.S_OK;
    }

    public virtual HRESULT DynamicMethodJITCompilationFinished(nuint functionId, HRESULT hrStatus, BOOL fIsSafeToBlock)
    {
        return HRESULT.S_OK;
    }
}
