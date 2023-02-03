using CorProf.Bindings;
using Microsoft.Diagnostics.Runtime.Utilities;

namespace CorProf.Core.Interfaces
{
    public unsafe interface ICorProfilerCallback8 : ICorProfilerCallback, ICorProfilerCallback2, ICorProfilerCallback3, ICorProfilerCallback4, ICorProfilerCallback5, ICorProfilerCallback6, ICorProfilerCallback7
    {
        [VtblIndex(92)]
        int DynamicMethodJITCompilationStarted(ulong functionId, int fIsSafeToBlock, byte* pILHeader, uint cbILHeader);
        [VtblIndex(93)]
        int DynamicMethodJITCompilationFinished(ulong functionId, int hrStatus, int fIsSafeToBlock);
    }
}
