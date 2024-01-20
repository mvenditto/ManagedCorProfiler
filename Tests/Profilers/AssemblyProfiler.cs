using ClrProfiling.Core;
using ClrProfiling.Shared;
using Windows.Win32.Foundation;
using Windows.Win32.System.Com;

namespace TestProfilers;

[ProfilerCallback("19A49007-9E58-4E31-B655-83EC3B924E7B")]
internal unsafe class AssemblyProfiler : TestProfilerBase
{
    private int _assemblyUnloadStartedCount = 0;
    private int _assemblyUnloadFinishedCount = 0;

    public override HRESULT Initialize(IUnknown* unknown)
    {
        return base.Initialize(unknown);
    }

    public override HRESULT AssemblyUnloadStarted(nuint assemblyId)
    {
        using var _ = new ShutdownGuard();

        if (ShutdownGuard.HasShutdownStarted())
        {
            return HRESULT.S_OK;
        }

        _assemblyUnloadStartedCount++;

        return HRESULT.S_OK;
    }

    public override HRESULT AssemblyUnloadFinished(nuint assemblyId, HRESULT hrStatus)
    {
        using var _ = new ShutdownGuard();

        if (ShutdownGuard.HasShutdownStarted())
        {
            return HRESULT.S_OK;
        }

        _assemblyUnloadFinishedCount++;

        return HRESULT.S_OK;
    }

    public override HRESULT Shutdown()
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

        return HRESULT.S_OK;
    }
}
