using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace ClrProfiling.Runner;

public class DotnetProfilerRunner : ProfilerRunnerBase
{
    private readonly ILogger<DotnetProfilerRunner> _logger;

    public DotnetProfilerRunner(ILogger<DotnetProfilerRunner>? logger = null) : base("dotnet", logger)
    {
        _logger = logger ?? NullLogger<DotnetProfilerRunner>.Instance;
    }
}