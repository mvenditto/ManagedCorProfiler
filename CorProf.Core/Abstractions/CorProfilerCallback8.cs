using CorProf.Core.Interfaces;

namespace CorProf.Core.Abstractions
{
    public abstract class CorProfilerCallback8 : CorProfilerCallback7, ICorProfilerCallback8
    {
        public virtual int DynamicMethodJITCompilationFinished(ulong functionId, int hrStatus, int fIsSafeToBlock)
        {
            return 0;
        }

        public virtual unsafe int DynamicMethodJITCompilationStarted(ulong functionId, int fIsSafeToBlock, byte* pILHeader, uint cbILHeader)
        {
            return 0;
        }
    }
}
