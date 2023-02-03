using CorProf.Bindings;
using CorProf.Core.Interfaces;

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
