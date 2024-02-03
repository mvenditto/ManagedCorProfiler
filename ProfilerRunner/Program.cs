using ClrProfiling.Runner;
using Serilog;
using Serilog.Extensions.Logging;
using System.CommandLine;
using Microsoft.Extensions.Logging;
using System.Reflection;

var rootCommand = new RootCommand("Sample profiler runner");

#region arguments
var profileeArgument = new Argument<FileInfo>("profilee-app", "The app to profile");
var profilerPathArgument = new Argument<FileInfo>("profiler-lib", "The profiler library path");
var profilerClsidArgument = new Argument<Guid>("profiler-guid", "The profiler CLSID");

rootCommand.AddArgument(profileeArgument);
rootCommand.AddArgument(profilerPathArgument);
rootCommand.AddArgument(profilerClsidArgument);
#endregion

#region options
var profilerLogEnable = new Option<bool>("--prof-log-enable", () => true, "Enable profiler logging");
var profilerLogLevelOption = new Option<int?>("--prof-log-level", () => null, "The profiler log level");
var profilerLogToConsole = new Option<bool>("--prof-log-to-console", () => false, "Enable to log to the console");
var profilerLogToFile = new Option<bool>("--prof-log-to-file", () => false, "Enable to log to a file");
var profilerLogFilePath = new Option<FileInfo>("--prof-log-file", "Enable to log to the console");
var hostArgs = new Option<string>("--host-args", "Argument for the host program");

rootCommand.AddOption(profilerLogEnable);
rootCommand.AddOption(profilerLogLevelOption);
rootCommand.AddOption(profilerLogToConsole);
rootCommand.AddOption(profilerLogToFile);
rootCommand.AddOption(profilerLogFilePath);
rootCommand.AddOption(hostArgs);
#endregion options


rootCommand.SetHandler(async (
    targetApp, profPath, profClsid, 
    profLogEnable, profLogLevel, profLogToConsole, profLogToFile, profLogFilePath) =>
{
    Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .WriteTo.Console(outputTemplate: "[{Level:u3}] {Message}{NewLine}{Exception}")
           .CreateLogger();
    
    var loggerFactory = new SerilogLoggerFactory(Log.Logger);

    var logger = loggerFactory.CreateLogger<DotnetProfilerRunner>();

    var profilerLogFile = Path.Combine(Environment.ProcessPath ?? Assembly.GetExecutingAssembly().Location, "prof.log");

    Console.WriteLine($"Profiler log file will be written at: {profilerLogFile}");

    var runner = new DotnetProfilerRunner(targetApp.FullName, profPath.FullName, profClsid, logger: logger)
    {
        ProfileeArguments = "RunTest",
        ProfilerLogEnabled = profLogEnable,
        ProfilerLogToConsole = profLogToConsole,
        ProfilerLogToFile = profLogToFile,
        ProfilerLogFile = profilerLogFile
    };

    if (profLogLevel != null)
    {
        runner.ProfilerLogLevel = profLogLevel.Value;
    }

    if (profLogToFile)
    {
        runner.ProfilerLogFile = profLogFilePath.FullName;
    }

    runner.OnOutuputReceived += (_, msg) =>
    {
        Console.WriteLine($"profilee: {msg}");
    };

    var exitCode = runner.RunWithProfilerEnabled();

}, profileeArgument, profilerPathArgument, profilerClsidArgument,
   profilerLogEnable, profilerLogLevelOption, profilerLogToConsole, profilerLogToFile, profilerLogFilePath);

return await rootCommand.InvokeAsync(args);
