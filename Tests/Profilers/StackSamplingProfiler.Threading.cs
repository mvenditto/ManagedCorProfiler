using CorProf.Bindings;
using CorProf.Core;
using CorProf.Shared;
using Microsoft.Diagnostics.Runtime.Utilities;
using TestProfilers;

namespace TestProfilers;

[ProfilerCallback("1B0551A7-17A5-444F-BE02-88556934C0D1")]
internal unsafe class StackSamplingProfiler_Threading : TestProfilerBase
{
    public override int Initialize(IUnknown* unknown)
    {
        return base.Initialize(unknown);
    }


    public override int Shutdown()
    {
        base.Shutdown();

        Console.WriteLine("PROFILER TEST PASSES");
        

        Console.Out.Flush();

        return HResult.S_OK;
    }
}
