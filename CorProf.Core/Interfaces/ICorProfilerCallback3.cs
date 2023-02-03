using CorProf.Bindings;
using Microsoft.Diagnostics.Runtime.Utilities;

namespace CorProf.Core.Interfaces
{
    public unsafe interface ICorProfilerCallback3 : ICorProfilerCallback, ICorProfilerCallback2
    {
        [VtblIndex(80)]
        int InitializeForAttach(IUnknown* pCorProfilerInfoUnk, void* pvClientData, uint cbClientData);
        [VtblIndex(81)]
        int ProfilerAttachComplete();
        [VtblIndex(82)]
        int ProfilerDetachSucceeded();
    }
}
