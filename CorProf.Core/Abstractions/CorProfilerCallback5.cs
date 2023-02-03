using CorProf.Core.Interfaces;

namespace CorProf.Core.Abstractions
{
    public abstract class CorProfilerCallback5 : CorProfilerCallback4, ICorProfilerCallback5
    {
        public virtual unsafe int ConditionalWeakTableElementReferences(uint cRootRefs, ulong* keyRefIds, ulong* valueRefIds, ulong* rootIds)
        {
            return 0;
        }
    }
}
