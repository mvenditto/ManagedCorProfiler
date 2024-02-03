using ClrProfiling.Shared;
using Windows.Win32.Foundation;
using Windows.Win32.System.Com;
using Windows.Win32.System.Diagnostics.ClrProfiling;
using ClrProfiling.Core;
using static Windows.Win32.System.Diagnostics.ClrProfiling.COR_PRF_MONITOR;
using static Windows.Win32.System.Diagnostics.ClrProfiling.COR_PRF_HIGH_MONITOR;
using static Windows.Win32.System.Diagnostics.ClrProfiling.COR_PRF_GC_GENERATION;
using Tests.Common.Utils;

namespace TestProfilers
{
    [ProfilerCallback("55b9554d-6115-45a2-be1e-c80f7fa35369")]
    internal unsafe class GCAllocationsProfiler : TestProfilerBase
    {
        private int _gcLOHAllocations = 0;
        private int _gcPOHAllocations = 0;
        private int _failures = 0;

        public override HRESULT Initialize(IUnknown* unknown)
        {
            base.Initialize(unknown);

            if (Runtime.IsNet6OrGreater() == false)
            {
                Console.WriteLine("PROFILER TEST SKIPPED: ObjectAllocated callback for pinned object heap allocation only supported by runtime 6 or above. see: https://github.com/dotnet/runtime/pull/55448.");
                return HRESULT.E_FAIL;
            }

            var eventsLow = COR_PRF_ENABLE_OBJECT_ALLOCATED;

            var eventsHigh = COR_PRF_HIGH_BASIC_GC 
                | COR_PRF_HIGH_MONITOR_LARGEOBJECT_ALLOCATED 
                | COR_PRF_HIGH_MONITOR_PINNEDOBJECT_ALLOCATED;

            var hr = ProfilerInfo->SetEventMask2((uint)eventsLow, (uint)eventsHigh);

            if (hr.Failed)
            {
                Console.WriteLine($"SetEventMask2 failed with hr=0x{hr:x8}");
                return hr;
            }

            return HRESULT.S_OK;
        }

        public override HRESULT ObjectAllocated(nuint objectId, nuint classId)
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                Console.WriteLine("Shutdown guard: shutdown started.");
                return HRESULT.S_OK;
            }

            COR_PRF_GC_GENERATION_RANGE gen;

            var hr = ProfilerInfo->GetObjectGeneration(objectId, &gen);

            if (hr.Failed)
            {
                Console.WriteLine($"GetObjectGeneration failed hr=0x{hr:x8}");
                Interlocked.Increment(ref _failures);
            }
            else if (gen.generation == COR_PRF_GC_LARGE_OBJECT_HEAP)
            {
                Interlocked.Increment(ref _gcLOHAllocations);
                Console.WriteLine($"0x{objectId:x8} -> LARGE_OBJECT_HEAP");
            }
            else if (gen.generation == COR_PRF_GC_PINNED_OBJECT_HEAP)
            {
                Interlocked.Increment(ref _gcPOHAllocations);
                Console.WriteLine($"0x{objectId:x8} -> PINNED_OBJECT_HEAP");
            }
            else
            {
                Console.WriteLine($"Unexpected object allocation captured, gen.generation={gen.generation}");
                Interlocked.Increment(ref _failures);
            }

            return HRESULT.S_OK;
        }

        public override HRESULT Shutdown()
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

            return HRESULT.S_OK;
        }
    }
}
