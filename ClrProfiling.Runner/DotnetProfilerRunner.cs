using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;

namespace ClrProfiling.Runner;

public class DotnetProfilerRunner : ProfilerRunnerBase
{
    private readonly ILogger<DotnetProfilerRunner> _logger;

    public DotnetProfilerRunner(
        string profileeApp,
        string profilerPath,
        Guid profilerClsid, 
        ILogger<DotnetProfilerRunner>? logger = null) : base("dotnet", profileeApp, profilerPath, profilerClsid, logger)
    {
        _logger = logger ?? NullLogger<DotnetProfilerRunner>.Instance;
    }
}