using ClrProfiling.Core;
using ClrProfiling.Shared;
using System.Collections.Concurrent;
using Windows.Win32.Foundation;
using Windows.Win32.System.Com;
using Windows.Win32.System.Diagnostics.ClrProfiling;
using static Windows.Win32.System.Diagnostics.ClrProfiling.COR_PRF_MONITOR;

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
        private ConcurrentDictionary<nuint, object> _rootReferencesSeen = new();
        private ConcurrentDictionary<nuint, object> _objectReferencesSeen = new();

        public override HRESULT Initialize(IUnknown* unknown)
        {
            base.Initialize(unknown);

            var hr = ProfilerInfo->SetEventMask2((uint) COR_PRF_MONITOR_GC, 0);

            if (hr.Failed)
            {
                Console.WriteLine($"SetEventMask2 failed with hr=0x{hr:x8}");
                return hr;
            }

            return HRESULT.S_OK;
        }

        private int NumPOHObjectsSeen(IEnumerable<nuint> objects)
        {
            int count = 0;

            var hr = HRESULT.S_OK;

            foreach (nuint objectId in objects)
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

        public override HRESULT GarbageCollectionStarted(int cGenerations, BOOL* generationCollected, COR_PRF_GC_REASON reason)
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                return HRESULT.S_OK;
            }

            var gcStarts = Interlocked.Increment(ref _gcStarts);
            var gcFinishes = Interlocked.CompareExchange(ref _gcFinishes, 0, 0);

            Console.WriteLine($"Profiler!GarbageCollectionStarted GCStart={gcStarts}, GCFinish={gcFinishes}");

            if (gcStarts - gcFinishes > 2)
            {
                Interlocked.Increment(ref _failures);
                Console.WriteLine($"GCBasicProfiler::GarbageCollectionStarted: FAIL: Expected GCStart <= GCFinish+2. GCStart={gcStarts}, GCFinish={gcFinishes}");
                return HRESULT.S_OK;
            }

            _rootReferencesSeen.Clear();
            _objectReferencesSeen.Clear();

            return HRESULT.S_OK;
        }

        public override HRESULT GarbageCollectionFinished()
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                return HRESULT.S_OK;
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

            return HRESULT.S_OK;
        }

        public override HRESULT ObjectsAllocatedByClass(uint cClassCount, nuint* classIds, uint* cObjects)
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                return HRESULT.S_OK;
            }


            var allocatedByClassCalls = Interlocked.Increment(ref _allocatedByClassCalls);

            var gcStarts = Interlocked.CompareExchange(ref _gcStarts, 0, 0);

            if (gcStarts != allocatedByClassCalls)
            {
                Interlocked.Increment(ref _failures);
                Console.WriteLine($"GCProfiler::ObjectsAllocatedByClass: FAIL: Expected ObjectsAllocatedByClass Calls == GCStart. AllocatedByClassCalls={allocatedByClassCalls}, GCStart={gcStarts}"); 
            }

            return HRESULT.S_OK;
        }

        public override HRESULT ObjectReferences(nuint objectId, nuint classId, uint cObjectRefs, nuint* objectRefIds)
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                return HRESULT.S_OK;
            }

            for (uint i = 0; i < cObjectRefs; i++)
            {
                nuint obj = objectRefIds[i];

                if (obj != 0)
                {
                    _objectReferencesSeen.TryAdd(obj, null);
                }
            }

            return HRESULT.S_OK;
        }

        public override HRESULT RootReferences(uint cRootRefs, nuint* rootRefIds) 
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                return HRESULT.S_OK;
            }

            for (uint i = 0; i < cRootRefs; i++)
            {
                nuint obj = rootRefIds[i];

                if (obj != 0)
                {
                    _rootReferencesSeen.TryAdd(obj, null);
                }
            }

            return HRESULT.S_OK;
        }

        public override HRESULT Shutdown()
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

            return HRESULT.S_OK;
        }
    }
}
