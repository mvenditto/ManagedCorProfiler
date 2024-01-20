using Tests.Common;

namespace Profiler.Tests
{
    public class ThreadTracking
    {
        static readonly Guid ThreadsSuspensionProfiler = new("1B0551A7-17A5-444F-BE02-88556934C0D1");

        public static int RunTest(String[] args)
        {
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            var e = new ManualResetEventSlim(false);

            var t = new Thread(async () =>
            {
                while(!cts.Token.IsCancellationRequested)
                {
                    await Task.Yield();
                    await Task.Delay(100);
                    // Console.WriteLine("TestTargetThread: Running");
                }

                Console.WriteLine("TestTargetThread: Done");
                e.Set();
            });

            t.Name = "TestTargetThread";

            t.Start();

            Thread.Sleep(1000);

            Console.WriteLine("TestTargetThread: Started.");

            Console.WriteLine("Test Passed");

            try
            {
                e.Wait(TimeSpan.FromSeconds(5), cts.Token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("TestTargetThread: Timed out.");
                return 101;
            }
            
            return 100;
        }

        public static int Main(string[] args)
        {
            if (args.Length > 0 && args[0].Equals("RunTest", StringComparison.OrdinalIgnoreCase))
            {
                return RunTest(args);
            }

            return ProfilerTestRunner.Run(profileePath: System.Reflection.Assembly.GetExecutingAssembly().Location,
                                          testName: "Threads.Suspension",
                                          profilerClsid: ThreadsSuspensionProfiler);
        }
    }
}