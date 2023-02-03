using CorProf.Bindings;
using Microsoft.Diagnostics.Runtime.Utilities;

namespace CorProf.Core.Interfaces
{
    public unsafe interface ICorProfilerCallback5 : ICorProfilerCallback, ICorProfilerCallback2, ICorProfilerCallback3, ICorProfilerCallback4
    {
        [VtblIndex(89)]
        int ConditionalWeakTableElementReferences(uint cRootRefs, ulong* keyRefIds, ulong* valueRefIds, ulong* rootIds);
    }
}
