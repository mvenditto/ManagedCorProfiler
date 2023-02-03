using CorProf.Bindings;
using CorProf.Core.Interfaces;

namespace CorProf.Core.Abstractions
{
    public abstract class CorProfilerCallback2 : CorProfilerCallback, ICorProfilerCallback2
    {
        public virtual int FinalizeableObjectQueued(uint finalizerFlags, ulong objectID)
        {
            return 0;
        }

        public virtual int GarbageCollectionFinished()
        {
            return 0;
        }

        public virtual unsafe int GarbageCollectionStarted(int cGenerations, int* generationCollected, COR_PRF_GC_REASON reason)
        {
            return 0;
        }

        public virtual int HandleCreated(ulong handleId, ulong initialObjectId)
        {
            return 0;
        }

        public virtual int HandleDestroyed(ulong handleId)
        {
            return 0;
        }

        public virtual unsafe int RootReferences2(uint cRootRefs, ulong* rootRefIds, COR_PRF_GC_ROOT_KIND* rootKinds, COR_PRF_GC_ROOT_FLAGS* rootFlags, ulong* rootIds)
        {
            return 0;
        }

        public virtual unsafe int SurvivingReferences(uint cSurvivingObjectIDRanges, ulong* objectIDRangeStart, uint* cObjectIDRangeLength)
        {
            return 0;
        }

        public virtual unsafe int ThreadNameChanged(ulong threadId, uint cchName, ushort* name)
        {
            return 0;
        }
    }
}
