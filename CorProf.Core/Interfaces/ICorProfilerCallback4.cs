using CorProf.Bindings;
using Microsoft.Diagnostics.Runtime.Utilities;

namespace CorProf.Core.Interfaces
{
    public unsafe interface ICorProfilerCallback4 : ICorProfilerCallback, ICorProfilerCallback2, ICorProfilerCallback3
    {
        [VtblIndex(83)]
        int ReJITCompilationStarted(ulong functionId, ulong rejitId, int fIsSafeToBlock) { return HResult.S_OK; }
        [VtblIndex(84)]
        int GetReJITParameters(ulong moduleId, uint methodId, ICorProfilerFunctionControl* pFunctionControl) { return HResult.S_OK; }
        [VtblIndex(85)]
        int ReJITCompilationFinished(ulong functionId, ulong rejitId, int hrStatus, int fIsSafeToBlock) { return HResult.S_OK; }
        [VtblIndex(86)]
        int ReJITError(ulong moduleId, uint methodId, ulong functionId, int hrStatus) { return HResult.S_OK; }
        [VtblIndex(87)]
        int MovedReferences2(uint cMovedObjectIDRanges, ulong* oldObjectIDRangeStart, ulong* newObjectIDRangeStart, ulong* cObjectIDRangeLength) { return HResult.S_OK; }
        [VtblIndex(88)]
        int SurvivingReferences2(uint cSurvivingObjectIDRanges, ulong* objectIDRangeStart, ulong* cObjectIDRangeLength) { return HResult.S_OK; }
    }
}
