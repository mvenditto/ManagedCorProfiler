using CorProf.Bindings;
using Microsoft.Diagnostics.Runtime.Utilities;

namespace CorProf.Core.Interfaces
{
    public unsafe interface ICorProfilerCallback9 : ICorProfilerCallback, ICorProfilerCallback2, ICorProfilerCallback3, ICorProfilerCallback4, ICorProfilerCallback5, ICorProfilerCallback6, ICorProfilerCallback7, ICorProfilerCallback8
    {
        [VtblIndex(94)]
        int DynamicMethodUnloaded(ulong functionId);
    }
}
