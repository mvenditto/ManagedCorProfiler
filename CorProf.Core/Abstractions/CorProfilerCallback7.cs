using CorProf.Core.Interfaces;

namespace CorProf.Core.Abstractions
{
    public abstract class CorProfilerCallback7 : CorProfilerCallback6, ICorProfilerCallback7
    {
        public virtual int ModuleInMemorySymbolsUpdated(ulong moduleId)
        {
            return 0;
        }
    }
}
