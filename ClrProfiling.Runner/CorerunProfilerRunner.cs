using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Diagnostics;

namespace ClrProfiling.Runner;

public class CorerunProfilerRunner : ProfilerRunnerBase
{
    private readonly ILogger<CorerunProfilerRunner> _logger;

    // Where to search the runtime binary, default to corerun location if not null;
    public string? ClrPath { get; init; } = null;

    // Additional included directory for class library assemblies
    public string? LibrariesPath { get; init; } = null;

    public bool WaitForDebuggerAttach { get; init; } = false;

    public CorerunProfilerRunner(string corerunPath = "corerun", ILogger<CorerunProfilerRunner>? logger = null) : base(corerunPath, logger)
    {
        _logger = logger ?? NullLogger<CorerunProfilerRunner>.Instance;
    }

    protected override void ConfigureProcessStart(ProcessStartInfo processStartInfo)
    {
        if (!string.IsNullOrEmpty(ClrPath) && Directory.Exists(ClrPath))
        {
            processStartInfo.Environment.Add("CORE_ROOT", ClrPath);
        }

        if (WaitForDebuggerAttach)
        {
            processStartInfo.Arguments = "--debug " + processStartInfo.Arguments;
        }

        if (!string.IsNullOrEmpty(LibrariesPath) && Directory.Exists(LibrariesPath))
        {
            processStartInfo.Environment.Add("CORE_LIBRARIES", LibrariesPath);
        }

        _logger.LogDebug("CoreRunProfilerRunner: CORE_ROOT={ClrPath}", ClrPath);
        _logger.LogDebug("CoreRunProfilerRunner: CORE_LIBRARIES={LibrariesPath}", LibrariesPath);
    }
}
