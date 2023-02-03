using CorProf.Bindings;
using CorProf.Core.Abstractions;
using CorProf.Helpers;
using CorProf.Shared;
using System.Runtime.InteropServices;

namespace TestProfilers
{
    internal abstract unsafe class TestProfiler: CorProfilerCallback2
    {
        protected ICorProfilerInfo11* _profilerInfo;
        protected ICorProfilerInfoHelpers2 _profilerInfoHelpers;

        public override int Initialize(IUnknown* unknown)
        {
            ShutdownGuard.Initialize();

            Console.WriteLine("Profiler.dll!Profiler::Initialize");
            Console.Out.Flush();

            var guid_ = CorProfConsts.IID_ICorProfilerInfo5;

            var hr = Marshal.QueryInterface((nint)unknown, ref guid_, out var pinfo);

            if (hr < 0)
            {
                Console.WriteLine("Profiler.dll!Profiler::Initialize failed to QI for ICorProfilerInfo.");
                _profilerInfo = null;
            }
            else
            {
                _profilerInfo = (ICorProfilerInfo11*)pinfo;

                _profilerInfoHelpers = new ICorProfilerInfoHelpers2(
                    (ICorProfilerInfo2*)pinfo);
            }

            return 0;
        }

        public override int Shutdown()
        {
            Console.WriteLine("Profiler.dll!Profiler::Shutdown");
            Console.Out.Flush();

            // Wait for any in progress profiler callbacks to finish.
            ShutdownGuard.WaitForInProgressHooks();

            return 0;
        }
    }
}
