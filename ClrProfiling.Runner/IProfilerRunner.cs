
namespace ClrProfiling.Runner;

public interface IProfilerRunner
{
    Guid ProfilerId { get; init; }

    string ProfilerPath { get; init; }

    string ProfileeApplicationPath { get; init; }

    void AttachToProcess(int pid);

    Task<int> RunWithProfilerEnabled(CancellationToken cancellationToken = default);
}