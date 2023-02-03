using CorProf.Bindings;
using CorProf.Utilities;
using Microsoft.Diagnostics.Runtime.Utilities;

namespace CorProf.Core.Interfaces
{
    public unsafe interface ICorProfilerCallback2 : ICorProfilerCallback
    {
        public readonly static Guid IID_ICorProfilerCallback2 = new("8a8cc829-ccf2-49fe-bbae-0f022228071a");

        int ThreadNameChanged(ulong threadId, uint cchName, ushort* name);
        int GarbageCollectionStarted(int cGenerations, int* generationCollected, COR_PRF_GC_REASON reason);
        int SurvivingReferences(uint cSurvivingObjectIDRanges, ulong* objectIDRangeStart, uint* cObjectIDRangeLength);
        int GarbageCollectionFinished();
        int FinalizeableObjectQueued(uint finalizerFlags, ulong objectID);
        int RootReferences2(uint cRootRefs, ulong* rootRefIds, COR_PRF_GC_ROOT_KIND* rootKinds, COR_PRF_GC_ROOT_FLAGS* rootFlags, ulong* rootIds);
        int HandleCreated(ulong handleId, ulong initialObjectId);
        int HandleDestroyed(ulong handleId);
    }
}