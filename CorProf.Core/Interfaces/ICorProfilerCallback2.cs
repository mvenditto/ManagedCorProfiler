using CorProf.Bindings;
using CorProf.Utilities;
using Microsoft.Diagnostics.Runtime.Utilities;

namespace CorProf.Core.Interfaces
{
    public unsafe interface ICorProfilerCallback2 : ICorProfilerCallback
    {
        public readonly static Guid IID_ICorProfilerCallback2 = new("8a8cc829-ccf2-49fe-bbae-0f022228071a");

        int ThreadNameChanged(ulong threadId, uint cchName, ushort* name) { return HResult.S_OK; }
        int GarbageCollectionStarted(int cGenerations, int* generationCollected, COR_PRF_GC_REASON reason) { return HResult.S_OK; }
        int SurvivingReferences(uint cSurvivingObjectIDRanges, ulong* objectIDRangeStart, uint* cObjectIDRangeLength) { return HResult.S_OK; }
        int GarbageCollectionFinished() { return HResult.S_OK; }
        int FinalizeableObjectQueued(uint finalizerFlags, ulong objectID) { return HResult.S_OK; }
        int RootReferences2(uint cRootRefs, ulong* rootRefIds, COR_PRF_GC_ROOT_KIND* rootKinds, COR_PRF_GC_ROOT_FLAGS* rootFlags, ulong* rootIds) { return HResult.S_OK; }
        int HandleCreated(ulong handleId, ulong initialObjectId) { return HResult.S_OK; }
        int HandleDestroyed(ulong handleId) { return HResult.S_OK; }
    }
}