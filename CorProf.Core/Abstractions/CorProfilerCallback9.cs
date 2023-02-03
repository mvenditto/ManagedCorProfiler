using CorProf.Core.Interfaces;

namespace CorProf.Core.Abstractions
{
    public abstract class CorProfilerCallback9 : CorProfilerCallback8, ICorProfilerCallback9
    {
        public virtual int DynamicMethodUnloaded(ulong functionId)
        {
            return 0;
        }
    }
}
