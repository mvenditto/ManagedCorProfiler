using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace ClrProfiling.Runner;

public abstract class ProfilerRunnerBase : IProfilerRunner
{
    private readonly ILogger<ProfilerRunnerBase> _logger;

    public Guid ProfilerClsid { get; }

    public string ProfilerPath { get; }

    public string ProfileeApplicationPath { get; }

    public string ProfileeArguments { get; set; } = string.Empty;

    public string HostProgramArguments { get; set; } = string.Empty;

    public bool ProfilerLogEnabled { get; set; } = true;

    public int ProfilerLogLevel { get; set; } = 3;

    public bool ProfilerLogToConsole { get; set; } = true;

    public bool ProfilerLogToFile { get; set; } = false;

    public string ProfilerLogFile { get; set; } = string.Empty;

    public bool LoadAsNotificationProfiler { get; set; } = false;

    public int NotificationCopies { get; set; } = 1;

    public ProfileeOptions ProfileeOptions { get; set; } = ProfileeOptions.None;

    public string ReverseServerName {  get; set; } = string.Empty;

    public Dictionary<string, string> EnviromentVariables { get; set; } = null!;

    public bool ForwardProcessEnvironmentVariables { get; set; } = true;

    public bool CaptureProfileeOutput { get; set; } = true;

    public int? ProcessId { get; private set; } = null;

    public string HostProgram { get; }

    public event EventHandler<string> OnOutuputReceived;

    protected ProfilerRunnerBase(string hostProgram, 
        string profileeApplicationPath,
        string profilerPath,
        Guid profilerClsid,
        ILogger<ProfilerRunnerBase>? logger = null)
    {
        _logger = logger ?? NullLogger<ProfilerRunnerBase>.Instance;
        ProfileeApplicationPath = profileeApplicationPath;
        ProfilerPath = profilerPath;
        ProfilerClsid = profilerClsid;
        HostProgram = hostProgram;
    }

    private void Validate()
    {
        if (string.IsNullOrEmpty(ProfilerPath) || !File.Exists(ProfilerPath))
        {
            throw new InvalidOperationException($"Profiler library not found: '{ProfilerPath}'");
        }

        if (string.IsNullOrEmpty(ProfileeApplicationPath) || !File.Exists(ProfileeApplicationPath))
        {
            throw new InvalidOperationException($"Profilee dll library not found: '{ProfileeApplicationPath}'");
        }

        if (ProfilerClsid == Guid.Empty)
        {
            throw new InvalidOperationException($"Invalid profiler id: '{ProfilerClsid}'");
        }

        if (EnviromentVariables == null)
        {
            EnviromentVariables = [];
        }
    }

    protected virtual void ConfigureProcessStart(ProcessStartInfo processStartInfo)
    {
    }

    protected virtual void OnDataReceived(string output)
    {
        OnOutuputReceived?.Invoke(this, output);
    }

    private ProcessStartInfo CreateProcessStartInfo()
    {
        var procStartInfo = new ProcessStartInfo
        {
            FileName = HostProgram,
            Arguments = HostProgramArguments + " " + ProfileeApplicationPath + " " + ProfileeArguments,
            UseShellExecute = false
        };

        if (CaptureProfileeOutput)
        {
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.RedirectStandardError = true;
        }

        if (ForwardProcessEnvironmentVariables)
        {
            foreach (string key in Environment.GetEnvironmentVariables().Keys)
            {
                procStartInfo.EnvironmentVariables[key] = Environment.GetEnvironmentVariable(key);
            }
        }

        foreach (var (key, val) in EnviromentVariables)
        {
            procStartInfo.EnvironmentVariables[key] = val;
        }

        ConfigureProcessStart(procStartInfo);

        return procStartInfo;
    }

    public int RunWithProfilerEnabled(CancellationToken cancellationToken = default)
    {
        Validate();

        var profileeAppPath = Path.GetDirectoryName(ProfilerPath);

        // Configure profiler logging
        if (ProfilerLogEnabled)
        {
            _logger.LogDebug("ProfilerRunner: profiler logging enabled with log level {LogLevel}", ProfilerLogLevel);
            _logger.LogWarning("COMPlus_LogEnable is only supported in .NET debug builds.");

            EnviromentVariables.Add("COMPlus_LogEnable", "1");
            EnviromentVariables.Add("COMPlus_LogLevel", ProfilerLogLevel.ToString());
            if (ProfilerLogToConsole)
            {
                EnviromentVariables.Add("COMPlus_LogToConsole", "1");
            }
            else if (ProfilerLogToFile)
            {
                EnviromentVariables.Add("COMPLUS_LogToFile", "1");
                EnviromentVariables.Add("COMPLUS_LogFile", ProfilerLogFile);
            }
        }

        // Disable tiered compilation, jitstress, and minopts
        if (ProfileeOptions.HasFlag(ProfileeOptions.OptimizationSensitive))
        {
            _logger.LogWarning("ProfilerRunner: Disabling tiered compilation, jitstress, and minopts.");
            EnviromentVariables.Add("COMPlus_TieredCompilation", "0");
            EnviromentVariables.Add("COMPlus_JitStress", "0");
            EnviromentVariables.Add("COMPlus_JITMinOpts", "0");
        }

        // Run with profiler from start
        if (!ProfileeOptions.HasFlag(ProfileeOptions.NoStartupAttach))
        {
            // enable the profiler
            EnviromentVariables.Add("CORECLR_ENABLE_PROFILING", "1");

            if (LoadAsNotificationProfiler)
            {
                var sb = new StringBuilder();

                for (var i = 0; i < NotificationCopies; i++)
                {
                    sb.Append($"{ProfilerPath}={{{ProfilerClsid}}};");
                }

                EnviromentVariables.Add("CORECLR_ENABLE_NOTIFICATION_PROFILERS", "1");

                // A semi-colon separated list of notification profilers to load into currently running process in the form \"path={guid}\""
                EnviromentVariables.Add("CORECLR_NOTIFICATION_PROFILERS", sb.ToString());
            }
            else
            {
                EnviromentVariables.Add("CORECLR_PROFILER", "{" + ProfilerClsid + "}");
                EnviromentVariables.Add("CORECLR_PROFILER_PATH", ProfilerPath);
            }
        }

        if (ProfileeOptions.HasFlag(ProfileeOptions.ReverseDiagnosticsMode))
        {
            _logger.LogInformation("ProfilerRunner: Launching profilee in reverse diagnostics port mode.");

            if (string.IsNullOrEmpty(ReverseServerName))
            {
                throw new ArgumentException(nameof(ReverseServerName));
            }

            EnviromentVariables.Add("DOTNET_DiagnosticPorts", ReverseServerName);
        }

        var process = new Process
        {
            StartInfo = CreateProcessStartInfo()
        };

        _logger.LogDebug("ProfilerRunner: Environment={EnvironmentVariables}", EnviromentVariables);

        if (CaptureProfileeOutput)
        {
            process.OutputDataReceived += ProcessDataReceived;
        }

        _logger.LogDebug("ProfilerRunner: starting process cmd=[{FileName:l} {Arguments:l}]", 
            process.StartInfo.FileName, process.StartInfo.Arguments);

        process.Start();

        ProcessId = process.Id;

        _logger.LogDebug("ProfilerRunner: profilee process started pid={Pid}", ProcessId);

        if (CaptureProfileeOutput)
        {
            process.BeginOutputReadLine();
        }

        process.WaitForExit();

        _logger.LogDebug("ProfilerRunner: profilee process terminated exitCode={ExitCode}", process.ExitCode);

        return process.ExitCode;
    }

    private void ProcessDataReceived(object sender, DataReceivedEventArgs args)
    {
        try
        {
            if (!string.IsNullOrEmpty(args?.Data))
                OnDataReceived(args.Data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to process redirected output data");
        }
    }

    public void AttachToProcess(int pid)
    {
        throw new NotImplementedException();
    }
}