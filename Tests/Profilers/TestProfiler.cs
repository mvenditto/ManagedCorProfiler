using Windows.Win32.System.Diagnostics.ClrProfiling;
using Windows.Win32.System.Com;
using Windows.Win32.Foundation;
using ClrProfiling.Core.Abstractions;
using ClrProfiling.Shared;

namespace TestProfilers
{
    internal abstract unsafe class TestProfilerBase : CorProfilerCallback2
    {
        protected ICorProfilerInfo13* ProfilerInfo;
        protected ICorProfilerInfo2* ProfilerInfo2;

        public override HRESULT Initialize(IUnknown* unknown)
        {
            ShutdownGuard.Initialize();

            Console.WriteLine("Profiler.dll!Profiler::Initialize");
            Console.Out.Flush();

            var hr = unknown->QueryInterface(ICorProfilerInfo13.IID_Guid, out var pinfo);

            if (hr.Failed)
            {
                Console.WriteLine("Profiler.dll!Profiler::Initialize failed to QI for ICorProfilerInfo.");
                ProfilerInfo = null;
                ProfilerInfo2 = null;
            }
            else
            {
                ProfilerInfo = (ICorProfilerInfo13*)pinfo;
                ProfilerInfo->AddRef();
                ProfilerInfo2 = (ICorProfilerInfo2*)pinfo;
            }

            return HRESULT.S_OK;
        }

        public override HRESULT Shutdown()
        {
            Console.WriteLine("Profiler.dll!Profiler::Shutdown");
            Console.Out.Flush();

            // Wait for any in progress profiler callbacks to finish.
            ShutdownGuard.WaitForInProgressHooks();

            ProfilerInfo->Release();

            return HRESULT.S_OK;
        }
    }
}
