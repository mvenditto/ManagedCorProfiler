using Windows.Win32.System.Diagnostics.ClrProfiling;
using Windows.Win32.System.Com;
using Windows.Win32.Foundation;
using ClrProfiling.Core.Abstractions;
using ClrProfiling.Shared;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;
using ClrProfiling.Helpers;
using Tests.Common.Utils;

namespace TestProfilers
{
    internal abstract unsafe class TestProfilerBase : CorProfilerCallback2
    {
        protected ICorProfilerInfo9* ProfilerInfo;
        protected ICorProfilerInfo2* ProfilerInfo2;
        protected RuntimeInformation Runtime;

        public override HRESULT Initialize(IUnknown* unknown)
        {
            ShutdownGuard.Initialize();

            Console.WriteLine("Profiler.dll!Profiler::Initialize");
            Console.Out.Flush();

            var corProfilerInfoIID = ICorProfilerInfo9.IID_Guid;

            var hr = unknown->QueryInterface(corProfilerInfoIID, out var pinfo);

            if (hr.Failed)
            {
                Console.WriteLine($"Profiler.dll!Profiler::Initialize failed to QI for ICorProfilerInfo ({corProfilerInfoIID}).");
                ProfilerInfo = null;
                ProfilerInfo2 = null;
            }
            else
            {
                ProfilerInfo = (ICorProfilerInfo9*)pinfo;
                ProfilerInfo->AddRef();
                ProfilerInfo2 = (ICorProfilerInfo2*)pinfo;
            }

            PrintRuntimeInfo();

            return HRESULT.S_OK;
        }

        [UnconditionalSuppressMessage("SingleFile", "IL3000:Avoid accessing Assembly file path when publishing as a single file", Justification = "<Pending>")]
        private void PrintRuntimeInfo()
        {
            using var versionStringBuff = NativeBuffer<char>.Alloc(32);
            var pVersionString = new PWSTR(versionStringBuff);

            var hr = ProfilerInfo->GetRuntimeInformation(
                out var clrInstanceId,
                out var runtimeType,
                out var majorVersion,
                out var minorVersion,
                out var buildNumber,
                out var qfeVersion,
                32,
                out var versionStringLength,
                pVersionString);

            Console.WriteLine("RuntimeInformation");


            var versionString = pVersionString.ToString();

            Runtime = new(majorVersion, minorVersion, buildNumber, versionString);

            if (hr.Succeeded)
            {
                Console.WriteLine($"  CLR InstanceID: {clrInstanceId}");
                Console.WriteLine($"  Runtime Type:   {runtimeType}");
                Console.WriteLine($"  Version:        {majorVersion}.{minorVersion}.{buildNumber} ({versionString})");
            }
            else
            {
                Console.WriteLine($"  FAIL GetRuntimeInformation hr=0x{hr}: Unable to retrieve runtime info.");
            }

            Console.WriteLine($"  Assembly:    {Assembly.GetExecutingAssembly()?.Location ?? "n/a"}");
            Console.WriteLine($"  Runtime Dir: {System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory()}");
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
