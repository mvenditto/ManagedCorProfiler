using CorProf.Bindings;
using Microsoft.Diagnostics.Runtime.Utilities;

namespace CorProf.Core.Interfaces
{
    public unsafe interface ICorProfilerCallback6 : ICorProfilerCallback, ICorProfilerCallback2, ICorProfilerCallback3, ICorProfilerCallback4, ICorProfilerCallback5
    {
        [VtblIndex(90)]
        int GetAssemblyReferences(ushort* wszAssemblyPath, ICorProfilerAssemblyReferenceProvider* pAsmRefProvider) { return HResult.S_OK; }
    }
}
