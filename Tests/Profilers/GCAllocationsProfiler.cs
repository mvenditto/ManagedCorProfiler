using CorProf.Bindings;
using CorProf.Core;
using CorProf.Shared;
using Microsoft.Diagnostics.Runtime.Utilities;

using ICorProfilerCallback = CorProf.Core.Interfaces.ICorProfilerCallback;
using ICorProfilerCallback2 = CorProf.Core.Interfaces.ICorProfilerCallback2;

using static CorProf.Bindings.COR_PRF_MONITOR;
using static CorProf.Bindings.COR_PRF_HIGH_MONITOR;
using static CorProf.Bindings.COR_PRF_GC_GENERATION;
using System.Threading;

namespace TestProfilers
{
    [ProfilerCallback("55b9554d-6115-45a2-be1e-c80f7fa35369")]
    internal unsafe class GCAllocationsProfiler : TestProfilerBase, ICorProfilerCallback2
    {
        private int _gcLOHAllocations = 0;
        private int _gcPOHAllocations = 0;
        private int _failures = 0;

        int ICorProfilerCallback.Initialize(IUnknown* unknown)
        {
            base.Initialize(unknown);

            var eventsLow = COR_PRF_ENABLE_OBJECT_ALLOCATED;
            var eventsHigh = COR_PRF_HIGH_BASIC_GC 
                | COR_PRF_HIGH_MONITOR_LARGEOBJECT_ALLOCATED 
                | COR_PRF_HIGH_MONITOR_PINNEDOBJECT_ALLOCATED;

            int hr = _profilerInfo->SetEventMask2((uint)eventsLow, (uint)eventsHigh);

            if (hr < 0)
            {
                Console.WriteLine($"SetEventMask2 failed with hr=0x{hr:x8}");
                return hr;
            }

            return HResult.S_OK;
        }

        int ICorProfilerCallback2.GarbageCollectionStarted(int cGenerations, int* generationCollected, CorProf.Bindings.COR_PRF_GC_REASON reason)
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                return HResult.S_OK;
            }

           

            return HResult.S_OK;
        }

        int ICorProfilerCallback.ObjectAllocated(ulong objectId, ulong classId)
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                return HResult.S_OK;
            }

            COR_PRF_GC_GENERATION_RANGE gen;

            int hr = _profilerInfo->GetObjectGeneration(objectId, &gen);

            if (hr < 0)
            {
                Console.WriteLine($"GetObjectGeneration failed hr=0x{hr:x8}");
                Interlocked.Increment(ref _failures);
            }
            else if (gen.generation == COR_PRF_GC_LARGE_OBJECT_HEAP)
            {
                Interlocked.Increment(ref _gcLOHAllocations);
            }
            else if (gen.generation == COR_PRF_GC_PINNED_OBJECT_HEAP)
            {
                Interlocked.Increment(ref _gcPOHAllocations);
            }
            else
            {
                Console.WriteLine($"Unexpected object allocation captured, gen.generation={gen.generation}");
                Interlocked.Increment(ref _failures);
            }

            return HResult.S_OK;
        }

        int ICorProfilerCallback.Shutdown()
        {
            base.Shutdown();

            if (Interlocked.CompareExchange(ref _gcPOHAllocations, 0, 0) == 0)
            {
                Console.WriteLine("There is no POH allocations");
            }
            else if (Interlocked.CompareExchange(ref _gcLOHAllocations, 0, 0) == 0)
            {
                Console.WriteLine("There is no LOH allocations");
            }
            else if (Interlocked.CompareExchange(ref _failures, 0, 0) == 0)
            {
                Console.WriteLine($"{_gcLOHAllocations} LOH objects allocated");
                Console.WriteLine($"{_gcPOHAllocations} POH objects allocated");
                Console.WriteLine("PROFILER TEST PASSES");
            }    

            Console.Out.Flush();

            return HResult.S_OK;
        }
    }
}
