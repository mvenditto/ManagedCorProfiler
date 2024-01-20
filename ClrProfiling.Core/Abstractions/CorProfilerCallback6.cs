using Windows.Win32.Foundation;
using Windows.Win32.System.Diagnostics.ClrProfiling;

namespace ClrProfiling.Core.Abstractions;

public abstract class CorProfilerCallback6 : CorProfilerCallback5, ICorProfilerCallback6.Interface
{
    public virtual unsafe HRESULT GetAssemblyReferences(PCWSTR wszAssemblyPath, ICorProfilerAssemblyReferenceProvider* pAsmRefProvider)
    {
        return HRESULT.S_OK;
    }
}