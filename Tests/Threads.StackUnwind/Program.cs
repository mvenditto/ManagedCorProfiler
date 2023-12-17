using System.Text;
using Tests.Common;

namespace Profiler.Tests
{
    public class StackSampling
    {
        static readonly Guid ThreadsStackUnwindProfiler = new("1B0551A7-17A5-444F-BE02-88556934C0D3");

        private static int A() => Random.Shared.Next();

        private static int B() => A() + 1;

        private static int C() => B() + 2;

        public static int RunTest(String[] args)
        {
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            var e = new ManualResetEventSlim(false);

            var t = new Thread(async () =>
            {
                var sb = new StringBuilder();

                var prev = Environment.TickCount64;

                while(!cts.Token.IsCancellationRequested)
                {
                    C();
                }

                Console.WriteLine("TestTargetThread: Done");
                e.Set();
            });

            t.Name = "TestTargetThread";

            t.Start();

            Console.WriteLine("TestTargetThread: Started.");

            Thread.Sleep(2000);

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
                                          testName: "Threads.StackUnwind",
                                          profilerClsid: ThreadsStackUnwindProfiler);
        }
    }
}