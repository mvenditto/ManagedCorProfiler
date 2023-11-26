// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Tests.Common;

namespace Profiler.Tests
{
    public class StackSampling
    {
        static readonly Guid StackSamplingProfilerGuid = new("1B0551A7-17A5-444F-BE02-88556934C0D1");

        public static int RunTest(String[] args)
        {
            const int numThreads = 10;
            
            var handles = new EventWaitHandle[numThreads];

            for (var i = 0; i < numThreads; i++)
            {
                var h = new EventWaitHandle(false, EventResetMode.ManualReset);
                
                var t = new Thread(() => 
                {
                    Thread.Sleep(100);
                    h.Set();
                });

                t.Name = "TestThread-" + i;

                handles[i] = h;

                t.Start();
            }

            WaitHandle.WaitAll(handles);

            Console.WriteLine("Test Passed");
            
            return 100;
        }

        public static int Main(string[] args)
        {
            if (args.Length > 0 && args[0].Equals("RunTest", StringComparison.OrdinalIgnoreCase))
            {
                return RunTest(args);
            }

            return ProfilerTestRunner.Run(profileePath: System.Reflection.Assembly.GetExecutingAssembly().Location,
                                          testName: "StackSampling",
                                          profilerClsid: StackSamplingProfilerGuid);
        }
    }
}