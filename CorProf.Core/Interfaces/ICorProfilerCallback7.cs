using CorProf.Bindings;
using Microsoft.Diagnostics.Runtime.Utilities;

namespace CorProf.Core.Interfaces
{
    public unsafe interface ICorProfilerCallback7 : ICorProfilerCallback, ICorProfilerCallback2, ICorProfilerCallback3, ICorProfilerCallback4, ICorProfilerCallback5, ICorProfilerCallback6
    {
        [VtblIndex(91)]
        int ModuleInMemorySymbolsUpdated(ulong moduleId);
    }
}
