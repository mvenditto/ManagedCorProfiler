using CorProf.Bindings;
using CorProf.Core;
using CorProf.Helpers;
using CorProf.Shared;
using Microsoft.Diagnostics.Runtime.Utilities;

namespace TestProfilers
{
    [ProfilerCallback("A040B953-EDE7-42D9-9077-AA69BB2BE024")]
    internal unsafe class GCBasicProfiler : TestProfiler
    {
        private int _gcStarts = 0;
        private int _gcFinishes = 0;
        private int _gcFailures = 0;

        public override int Initialize(IUnknown* unknown)
        {
            base.Initialize(unknown);

            var eventsHigh = COR_PRF_HIGH_MONITOR.COR_PRF_HIGH_BASIC_GC;

            int hr = _profilerInfo->SetEventMask2(0, (uint) eventsHigh);

            if (hr < 0)
            {
                Console.WriteLine($"SetEventMask2 failed with hr=0x{hr:x8}");
                return hr;
            }

            return HResult.S_OK;
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
                Interlocked.Increment(ref _gcFailures);
                Console.WriteLine($"GCBasicProfiler::GarbageCollectionStarted: FAIL: Expected GCStart <= GCFinish+2. GCStart={gcStarts}, GCFinish={gcFinishes}");
                return HResult.S_OK;
            }

            if (gcStarts == 1)
            {
                Console.WriteLine($"Profiler!GarbageCollectionStarted GCStart == 1");
                uint nObjectRanges;
                bool fHeapAlloc = false;
                COR_PRF_GC_GENERATION_RANGE* pObjectRanges = null;
                uint cRanges = 32;
                using var objectRangesStackBuffer = NativeBuffer<COR_PRF_GC_GENERATION_RANGE>.Alloc(cRanges);
                int hr = _profilerInfo->GetGenerationBounds(cRanges, &nObjectRanges, objectRangesStackBuffer);
                if (hr < 0)
                {
                    Interlocked.Increment(ref _gcFailures);
                    Console.WriteLine($"GCBasicProfiler::GarbageCollectionStarted: FAIL: GetGenerationBounds hr=0x{hr:x8}");
                    return HResult.S_OK;
                }

                if (nObjectRanges <= cRanges)
                {
                    pObjectRanges = objectRangesStackBuffer;
                }

                if (pObjectRanges == null)
                {
                    using var buff = NativeBuffer<COR_PRF_GC_GENERATION_RANGE>.Alloc(nObjectRanges);
                    pObjectRanges = buff;
                }

                fHeapAlloc = true;
                
                uint nObjectRanges2;

                hr = _profilerInfo->GetGenerationBounds(cRanges, &nObjectRanges2, pObjectRanges);

                if (hr < 0 || nObjectRanges != nObjectRanges2)
                {
                    Interlocked.Increment(ref _gcFailures);
                    Console.WriteLine($"GCBasicProfiler::GarbageCollectionStarted: FAIL: GetGenerationBounds hr=0x{hr:x8} {nObjectRanges} {nObjectRanges2}");
                    return HResult.S_OK;
                }

                for (int i = (int)(nObjectRanges - 1); i >= 0; i--)
                {
                    if (pObjectRanges[i].generation is < 0 or > (COR_PRF_GC_GENERATION)4)
                    {
                        Interlocked.Increment(ref _gcFailures);
                        Console.WriteLine($"GCBasicProfiler::GarbageCollectionStarted: FAIL: invalid generation: {pObjectRanges[i].generation}");
                    }
                }

                if (nObjectRanges > 3 && pObjectRanges[2].generation == (COR_PRF_GC_GENERATION)2 
                    && pObjectRanges[2].rangeLength == 0x18 && pObjectRanges[2].generation == (COR_PRF_GC_GENERATION)1)
                {
                    if (pObjectRanges[3].rangeLength != 0x18)
                    {
                        Interlocked.Increment(ref _gcFailures);
                        Console.WriteLine("GCBasicProfiler::GarbageCollectionStarted: FAIL: in the first GC for the segment case, gen 1 should have size 0x18");
                    }
                }

                if (fHeapAlloc)
                {
                    //NativeMemory.Free(pObjectRanges);
                }
            }

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
                Interlocked.Increment(ref _gcFailures);
                Console.WriteLine($"GCBasicProfiler::GarbageCollectionFinished: FAIL: Expected GCStart >= GCFinish. Start={gcStarts}, Finish={gcFinishes}");
            }

            return HResult.S_OK;
        }

        public override int Shutdown()
        {
            base.Shutdown();

            if (Interlocked.CompareExchange(ref _gcStarts, 0, 0) == 0)
            {
                Console.WriteLine("GCBasicProfiler::Shutdown: FAIL: Expected GarbageCollectionStarted to be called");
            }
            else if (Interlocked.CompareExchange(ref _gcFinishes, 0, 0) == 0)
            {
                Console.WriteLine("GCBasicProfiler::Shutdown: FAIL: Expected GarbageCollectionFinished to be called");
            }
            else if (Interlocked.CompareExchange(ref _gcFailures, 0, 0) == 0)
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
