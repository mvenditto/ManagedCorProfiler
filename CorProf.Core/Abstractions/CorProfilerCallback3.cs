using CorProf.Bindings;
using ICorProfilerCallback3 = CorProf.Core.Interfaces.ICorProfilerCallback3;


namespace CorProf.Core.Abstractions
{
    public abstract class CorProfilerCallback3 : CorProfilerCallback2, ICorProfilerCallback3
    {
        public virtual unsafe int InitializeForAttach(IUnknown* pCorProfilerInfoUnk, void* pvClientData, uint cbClientData)
        {
            return 0;
        }

        public virtual int ProfilerAttachComplete()
        {
            return 0;
        }

        public virtual int ProfilerDetachSucceeded()
        {
            return 0;
        }
    }
}
