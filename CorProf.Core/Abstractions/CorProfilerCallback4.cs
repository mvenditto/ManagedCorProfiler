using CorProf.Bindings;
using CorProf.Core.Interfaces;

namespace CorProf.Core.Abstractions
{
    public abstract class CorProfilerCallback4 : CorProfilerCallback3, ICorProfilerCallback4
    {
        public virtual unsafe int GetReJITParameters(ulong moduleId, uint methodId, ICorProfilerFunctionControl* pFunctionControl)
        {
            return 0;
        }

        public virtual unsafe int MovedReferences2(uint cMovedObjectIDRanges, ulong* oldObjectIDRangeStart, ulong* newObjectIDRangeStart, ulong* cObjectIDRangeLength)
        {
            return 0;
        }

        public virtual int ReJITCompilationFinished(ulong functionId, ulong rejitId, int hrStatus, int fIsSafeToBlock)
        {
            return 0;
        }

        public virtual int ReJITCompilationStarted(ulong functionId, ulong rejitId, int fIsSafeToBlock)
        {
            return 0;
        }

        public virtual int ReJITError(ulong moduleId, uint methodId, ulong functionId, int hrStatus)
        {
            return 0;
        }

        public virtual unsafe int SurvivingReferences2(uint cSurvivingObjectIDRanges, ulong* objectIDRangeStart, ulong* cObjectIDRangeLength)
        {
            return 0;
        }
    }
}
