// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ClrProfiling.Runner;
using System.Runtime.InteropServices;
using Tests.Common.Exceptions;

namespace Tests.Common;

public interface IOutputHelper
{
    void WriteLine(string message);

    void WriteLine(string format, params object[] args);
}

public static class ProfilerTestRunner
{
    public static string GetProfilerPath()
    {
        string profilerName;
        if (OperatingSystem.IsWindows())
        {
            profilerName = "Profiler.dll";
        }
        else if (OperatingSystem.IsLinux())
        {
            profilerName = "libProfiler.so";
        }
        else
        {
            profilerName = "libProfiler.dylib";
        }

        var currDir = Environment.CurrentDirectory;

        Console.WriteLine(currDir);

        string profilerPath = Path.Combine(
            Path.GetFullPath(@"..\..\..\..\..\Profilers\bin\profiler\"),
            profilerName);

        return profilerPath;
    }

    private static string GetCorerunPath()
    {
        string corerunName;

        if (OperatingSystem.IsWindows())
        {
            corerunName = "CoreRun.exe";
        }
        else
        {
            corerunName = "corerun";
        }

        var corerunPathEnvVar = Environment.GetEnvironmentVariable("CORERUN_PATH");

        var corerunPath = !string.IsNullOrEmpty(corerunPathEnvVar)
            ? Path.Combine(corerunPathEnvVar, corerunName)
            : corerunName;

        return corerunPath;
    }

    private static void FailFastWithMessage(string error)
    {
        Console.WriteLine("Test failed: " + error);
        throw new Exception(error);
    }

    public static int Run(string profileePath,
        string testName,
        Guid profilerClsid,
        string profileeArguments = "",
        ProfileeOptions profileeOptions = ProfileeOptions.None,
        Dictionary<string, string> envVars = null,
        string reverseServerName = null,
        bool loadAsNotification = false,
        int notificationCopies = 1,
        IOutputHelper outputHelper = null)
    {

        var runtimeHost = Environment.GetEnvironmentVariable("TEST_RUNTIME_HOST") ?? "dotnet";

        string profilerPath = GetProfilerPath();

        if (!File.Exists(profilerPath))
        {
            throw new ArgumentException("Cannot locate profiler dll.");
        }

        if (envVars == null)
        {
            envVars = new Dictionary<string, string>();
        }
        envVars.Add("Profiler_Test_Name", testName);

        IProfilerRunner runner = null;

        var args = "RunTest " + profileeArguments;

        if (runtimeHost == "dotnet")
        {
            runner = new DotnetProfilerRunner(profileePath, profilerPath, profilerClsid)
            {
                CaptureProfileeOutput = true,
                ProfileeArguments = args,
                ProfileeOptions = profileeOptions,
                EnviromentVariables = envVars
            };
        }
        else
        {
            var corerunPath = GetCorerunPath();
            var runtimeDirectory = RuntimeEnvironment.GetRuntimeDirectory();
            var clrPath = Environment.GetEnvironmentVariable("CORE_ROOT") ?? runtimeDirectory;
            var libraries = Environment.GetEnvironmentVariable("CORE_LIBRARIES") ?? runtimeDirectory;

            runner = new CorerunProfilerRunner(profileePath, profilerPath, profilerClsid, corerunPath)
            {
                CaptureProfileeOutput = true,
                ProfileeArguments = args,
                ProfileeOptions = profileeOptions,
                EnviromentVariables = envVars,
                ProfilerLogEnabled = true,
                ProfilerLogLevel = 3,
                ProfilerLogToConsole = true,
                ClrPath = clrPath,
                LibrariesPath = libraries
            };
        }

        var verifier = new ProfileeOutputVerifier();

        runner.OnOutuputReceived += (sender, data) =>
        {
            Console.WriteLine(data);

            if (data != null)
            {
                outputHelper?.WriteLine(data);
                verifier.WriteLine(data);
            }
        };

        var exitCode = runner.RunWithProfilerEnabled();
        
        // There are two conditions for profiler tests to pass, the output of the profiled program
        // must contain the phrase "PROFILER TEST PASSES" and the return code must be 100. This is
        // because lots of verification happen in the profiler code, where it is hard to change the
        // program return value.

        if (verifier.HasSkippedOutput)
        {
            throw new RuntimeNotSupportedException();
        }

        if (!verifier.HasPassingOutput)
        {
            FailFastWithMessage("Profiler tests are expected to contain the text \'" + verifier.SuccessPhrase + "\' in the console output " +
                "of the profilee app to indicate a passing test. Usually it is printed from the Shutdown() method of the profiler implementation. This " +
                "text was not found in the output above.");
        }

        if (exitCode != 100)
        {
            FailFastWithMessage($"Profilee returned exit code {exitCode} instead of expected exit code 100.");
        }

        return 100;

    }

    /// <summary>
    /// Verifies that console output from a profiler test has the output we expect for a passing test
    /// </summary>
    class ProfileeOutputVerifier
    {
        public string SuccessPhrase = "PROFILER TEST PASSES";

        public string SkipPhrase = "PROFILER TEST SKIPPED";

        public bool HasPassingOutput { get; private set; }

        public bool HasSkippedOutput { get; private set; }

        public void WriteLine(string message)
        {
            if (message != null)
            {
                if (message.Contains(SuccessPhrase))
                {
                    HasPassingOutput = true;
                }
                else if (message.Contains(SkipPhrase))
                {
                    HasSkippedOutput = true;
                }
            }
        }

        public void WriteLine(string format, params object[] args)
        {
            if (string.Format(format, args).Contains(SuccessPhrase))
            {
                HasPassingOutput = true;
            }
        }
    }
}
