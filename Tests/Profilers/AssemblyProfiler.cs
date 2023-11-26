using CorProf.Bindings;
using CorProf.Core;
using CorProf.Shared;
using Microsoft.Diagnostics.Runtime.Utilities;
using TestProfilers;

namespace TestProfilers;

[ProfilerCallback("19A49007-9E58-4E31-B655-83EC3B924E7B")]
internal unsafe class AssemblyProfiler : TestProfilerBase
{
    private int _assemblyUnloadStartedCount = 0;
    private int _assemblyUnloadFinishedCount = 0;

    public override int Initialize(IUnknown* unknown)
    {
        return base.Initialize(unknown);
    }

    public override int AssemblyUnloadStarted(ulong assemblyId)
    {
        using var _ = new ShutdownGuard();

        if (ShutdownGuard.HasShutdownStarted())
        {
            return HResult.S_OK;
        }

        _assemblyUnloadStartedCount++;

        return HResult.S_OK;
    }

    public override int AssemblyUnloadFinished(ulong assemblyId, int hrStatus)
    {
        using var _ = new ShutdownGuard();

        if (ShutdownGuard.HasShutdownStarted())
        {
            return HResult.S_OK;
        }

        _assemblyUnloadFinishedCount++;

        return HResult.S_OK;
    }

    public override int Shutdown()
    {
        base.Shutdown();

        if (_assemblyUnloadStartedCount != _assemblyUnloadFinishedCount)
        {
            Console.WriteLine("AssemblyProfiler::Shutdown: FAIL: Expected AssemblyUnloadStarted and AssemblyUnloadFinished to be called the same number of times");
        }
        else
        {
            Console.WriteLine("PROFILER TEST PASSES");
        }

        Console.Out.Flush();

        return HResult.S_OK;
    }
}
