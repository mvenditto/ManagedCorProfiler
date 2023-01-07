using CorProf.Bindings;
using Microsoft.Diagnostics.Runtime.Utilities;

namespace CorProf.Core.Interfaces
{
    public unsafe interface ICorProfilerCallback3 : ICorProfilerCallback, ICorProfilerCallback2
    {
        [VtblIndex(80)]
        int InitializeForAttach(IUnknown* pCorProfilerInfoUnk, void* pvClientData, uint cbClientData) { return HResult.S_OK; }
        [VtblIndex(81)]
        int ProfilerAttachComplete() { return HResult.S_OK; }
        [VtblIndex(82)]
        int ProfilerDetachSucceeded() { return HResult.S_OK; }
    }
}
