
using System;
using System.Threading;

namespace ClrProfiling.Runner;

public interface IProfilerRunner
{
    Guid ProfilerClsid { get; }

    string ProfilerPath { get; }

    string ProfileeApplicationPath { get; }

    void AttachToProcess(int pid);

    int RunWithProfilerEnabled(CancellationToken cancellationToken = default);

    public event EventHandler<string> OnOutuputReceived;
}