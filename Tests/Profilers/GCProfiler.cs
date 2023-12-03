using CorProf.Bindings;
using CorProf.Core;
using CorProf.Shared;
using Microsoft.Diagnostics.Runtime.Utilities;
using System.Collections.Concurrent;
using static CorProf.Bindings.COR_PRF_MONITOR;

namespace TestProfilers
{
    [ProfilerCallback("BCD8186F-1EEC-47E9-AFA7-396F879382C3")]
    internal unsafe class GCProfiler : TestProfilerBase
    {
        private int _gcStarts;
        private int _gcFinishes;
        private int _allocatedByClassCalls;
        private int _failures;
        private int _pohObjectsSeenRootReferences;
        private int _pohObjectsSeenObjectReferences;
        private ConcurrentDictionary<ulong, object> _rootReferencesSeen = new();
        private ConcurrentDictionary<ulong, object> _objectReferencesSeen = new();

        public override int Initialize(IUnknown* unknown)
        {
            base.Initialize(unknown);

            int hr = ProfilerInfo->SetEventMask2((uint) COR_PRF_MONITOR_GC, 0);

            if (hr < 0)
            {
                Console.WriteLine($"SetEventMask2 failed with hr=0x{hr:x8}");
                return hr;
            }

            return HResult.S_OK;
        }

        private int NumPOHObjectsSeen(IEnumerable<ulong> objects)
        {
            int count = 0;
            int hr = 0;

            foreach(ulong objectId in objects)
            {
                COR_PRF_GC_GENERATION_RANGE gen;
            
                hr = ProfilerInfo->GetObjectGeneration(objectId, &gen);
            
                if (hr < 0)
                {
                    Console.WriteLine($"GetObjectGeneration failed hr=0x{hr:x8}");
                    return hr;
                }

                if (gen.generation == COR_PRF_GC_GENERATION.COR_PRF_GC_PINNED_OBJECT_HEAP)
                {
                    count++;
                }
            }

            return count;
        }

        public override int GarbageCollectionStarted(int cGenerations, int* generationCollected, CorProf.Bindings.COR_PRF_GC_REASON reason)
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                return HResult.S_OK;
            }

            var gcStarts = Interlocked.Increment(ref _gcStarts);
            var gcFinishes = Interlocked.CompareExchange(ref _gcFinishes, 0, 0);

            Console.WriteLine($"Profiler!GarbageCollectionStarted GCStart={gcStarts}, GCFinish={gcFinishes}");

            if (gcStarts - gcFinishes > 2)
            {
                Interlocked.Increment(ref _failures);
                Console.WriteLine($"GCBasicProfiler::GarbageCollectionStarted: FAIL: Expected GCStart <= GCFinish+2. GCStart={gcStarts}, GCFinish={gcFinishes}");
                return HResult.S_OK;
            }

            _rootReferencesSeen.Clear();
            _objectReferencesSeen.Clear();

            return HResult.S_OK;
        }

        public override int GarbageCollectionFinished()
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                return HResult.S_OK;
            }

            var gcFinishes = Interlocked.Increment(ref _gcFinishes);
            var gcStarts = Interlocked.CompareExchange(ref _gcStarts, 0, 0);

            if (gcStarts < gcFinishes)
            {
                Interlocked.Increment(ref _failures);
                Console.WriteLine($"GCBasicProfiler::GarbageCollectionFinished: FAIL: Expected GCStart >= GCFinish. Start={gcStarts}, Finish={gcFinishes}");
            }

            Interlocked.Add(ref _pohObjectsSeenObjectReferences, NumPOHObjectsSeen(_objectReferencesSeen.Keys));
            Interlocked.Add(ref _pohObjectsSeenRootReferences, NumPOHObjectsSeen(_rootReferencesSeen.Keys));

            return HResult.S_OK;
        }

        public override int ObjectsAllocatedByClass(uint cClassCount, ulong* classIds, uint* cObjects)
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                return HResult.S_OK;
            }


            var allocatedByClassCalls = Interlocked.Increment(ref _allocatedByClassCalls);

            var gcStarts = Interlocked.CompareExchange(ref _gcStarts, 0, 0);

            if (gcStarts != allocatedByClassCalls)
            {
                Interlocked.Increment(ref _failures);
                Console.WriteLine($"GCProfiler::ObjectsAllocatedByClass: FAIL: Expected ObjectsAllocatedByClass Calls == GCStart. AllocatedByClassCalls={allocatedByClassCalls}, GCStart={gcStarts}"); 
            }

            return HResult.S_OK;
        }

        public override int ObjectReferences(ulong objectId, ulong classId, uint cObjectRefs, ulong* objectRefIds)
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                return HResult.S_OK;
            }

            for (uint i = 0; i < cObjectRefs; i++)
            {
                ulong obj = objectRefIds[i];

                if (obj != 0)
                {
                    _objectReferencesSeen.TryAdd(obj, null);
                }
            }

            return HResult.S_OK; 
        }

        public override int RootReferences(uint cRootRefs, ulong* rootRefIds) 
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                return HResult.S_OK;
            }

            for (uint i = 0; i < cRootRefs; i++)
            {
                ulong obj = rootRefIds[i];

                if (obj != 0)
                {
                    _rootReferencesSeen.TryAdd(obj, null);
                }
            }

            return HResult.S_OK;
        }

        public override int Shutdown()
        {
            base.Shutdown();

            if (_gcStarts == 0)
            {
                Console.WriteLine("GCProfiler::Shutdown: FAIL: Expected GarbageCollectionStarted to be called");
            }
            else if (_gcFinishes == 0)
            {
                Console.WriteLine("GCProfiler::Shutdown: FAIL: Expected GarbageCollectionFinished to be called");
            }
            else if (_allocatedByClassCalls == 0)
            {
                Console.WriteLine("GCProfiler::Shutdown: FAIL: Expected ObjectsAllocatedByClass to be called");
            }
            else if (_pohObjectsSeenRootReferences == 0 || _pohObjectsSeenObjectReferences == 0)
            {
                Console.WriteLine(
                    $"GCProfiler::Shutdown: FAIL: no POH objects seen. root references={_pohObjectsSeenRootReferences} object references={_pohObjectsSeenObjectReferences}");
            }
            else if (_failures == 0)
            {
                Console.WriteLine("PROFILER TEST PASSES");
            }
            else
            {
                // failures were printed earlier when _failures was incremented
            }

            Console.Out.Flush();

            return HResult.S_OK;
        }
    }
}
