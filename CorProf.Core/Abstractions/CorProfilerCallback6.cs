using CorProf.Bindings;
using ICorProfilerCallback6 = CorProf.Core.Interfaces.ICorProfilerCallback6;

namespace CorProf.Core.Abstractions
{
    public abstract class CorProfilerCallback6 : CorProfilerCallback5, ICorProfilerCallback6
    {
        public virtual unsafe int GetAssemblyReferences(ushort* wszAssemblyPath, ICorProfilerAssemblyReferenceProvider* pAsmRefProvider)
        {
            return 0;
        }
    }
}
