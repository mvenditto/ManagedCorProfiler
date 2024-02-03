// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Tests.Common;
using Xunit.Abstractions;

namespace Profiler.Tests
{
    public class ALCTests
    {
        static readonly Guid AssemblyProfilerGuid = new ("19A49007-9E58-4E31-B655-83EC3B924E7B");

        public static int RunTest(String[] args)
        {
            string currentAssemblyDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string testAssemblyFullPath = Path.Combine(currentAssemblyDirectory, "TestFile.dll");

            int exitCode = TestLibrary.Utilities.ExecuteAndUnload(testAssemblyFullPath, args);

            return exitCode;
        }

        public static int ExecuteTest(string[] args, IOutputHelper outputHelper = null)
        {
            if (args.Length > 0 && args[0].Equals("RunTest", StringComparison.OrdinalIgnoreCase))
            {
                return RunTest(args);
            }

            return ProfilerTestRunner.Run(profileePath: System.Reflection.Assembly.GetExecutingAssembly().Location,
                                          testName: "ALCTest",
                                          profilerClsid: AssemblyProfilerGuid,
                                          outputHelper: outputHelper);
        }

        public static int Main(string[] args)
        {
            return ExecuteTest(args);
        }
    }
}