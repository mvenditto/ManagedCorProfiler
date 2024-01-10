using ClrProfiling.Core;
using ClrProfiling.Core.Helpers;
using ClrProfiling.Helpers;
using ClrProfiling.Hooks;
using ClrProfiling.Shared;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Tests.Common;

using Windows.Win32.Foundation;
using Windows.Win32.System.Com;
using Windows.Win32.System.Diagnostics.ClrProfiling;
using static Windows.Win32.System.Diagnostics.ClrProfiling.COR_PRF_MONITOR;

namespace TestProfilers
{
    [ProfilerCallback("DDADC0CB-21C8-4E53-9A6C-7C65EE5800CE")]
    internal unsafe class InliningProfiler : TestProfilerBase
    {
        private static int _failures;

        // BOOL actually
        private static int _sawInlineeCall;
        private static int _inInlining;
        private static int _inBlockInlining;
        private static int _inNoResponse;

        private static ICorProfilerInfo2* _sProfilerInfo;

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static void EnterStub(FunctionIDOrClientID functionOrClientId, nuint eltInfo)
        {
            if (ShutdownGuard.HasShutdownStarted())
            {
                return;
            }

            int hr = ProfilerInfoHelpers.GetFunctionIDName(
                _sProfilerInfo,
                functionOrClientId.functionID,
                out string functionName);

            if (hr < 0)
            {
                Console.WriteLine($"GetFunctionIDFullyQualifiedName failed for 0x{functionOrClientId.functionID:x8} with hr 0x{hr:x8}");
                return;
            }

            if (functionName == "Inlining")
            {
                Console.WriteLine($"ENTER: {functionName}");
                Interlocked.Exchange(ref _inInlining, 1);
            }
            else if (functionName == "BlockInlining")
            {
                Console.WriteLine($"ENTER: {functionName}");
                Interlocked.Exchange(ref _inBlockInlining, 1);
            }
            else if (functionName == "NoResponse")
            {
                Console.WriteLine($"ENTER: {functionName}");
                Interlocked.Exchange(ref _inNoResponse, 1);
            }
            else if (functionName == "Inlinee")
            {
                Console.WriteLine($"ENTER: {functionName}");
                if (Interlocked.CompareExchange(ref _inInlining, 0, 0) == 1
                 || Interlocked.CompareExchange(ref _inNoResponse, 0, 0) == 1)
                {
                    Interlocked.Increment(ref _failures);
                    Console.WriteLine("Saw Inlinee as a real method call instead of inlined.");
                }

                if (Interlocked.CompareExchange(ref _inBlockInlining, 0, 0) == 1)
                {
                    Interlocked.Exchange(ref _sawInlineeCall, 1);
                }
            }
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static void LeaveStub(FunctionIDOrClientID functionOrClientId, nuint eltInfo)
        {
            if (ShutdownGuard.HasShutdownStarted())
            {
                return;
            }

            int hr = ProfilerInfoHelpers.GetFunctionIDName(
                _sProfilerInfo, 
                functionOrClientId.functionID, 
                out string functionName);

            if (hr < 0)
            {
                Console.WriteLine($"GetFunctionIDFullyQualifiedName failed for 0x{functionOrClientId.functionID:x8} with hr 0x{hr:x8}");
                return;
            }

            if (functionName == "Inlining")
            {
                Console.WriteLine($"LEAVE: {functionName}");
                Interlocked.Exchange(ref _inInlining, 0);
            }
            else if (functionName == "BlockInlining")
            {
                Console.WriteLine($"LEAVE: {functionName}");
                Interlocked.Exchange(ref _inBlockInlining, 0);
            }
            else if (functionName == "NoResponse")
            {
                Console.WriteLine($"LEAVE: {functionName}");
                Interlocked.Exchange(ref _inNoResponse, 0);
            }
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static void TailcallStub(FunctionIDOrClientID functionOrClientId, nuint eltInfo)
        {
            if (ShutdownGuard.HasShutdownStarted())
            {
                return;
            }
        }

        public override unsafe HRESULT Initialize(IUnknown* unknown)
        {
            base.Initialize(unknown);

            _sProfilerInfo = ProfilerInfo2;

            var hr = ProfilerInfo->SetEventMask2((uint)(COR_PRF_MONITOR_ENTERLEAVE
                                                    | COR_PRF_ENABLE_FUNCTION_ARGS
                                                    | COR_PRF_ENABLE_FUNCTION_RETVAL
                                                    | COR_PRF_ENABLE_FRAME_INFO
                                                    | COR_PRF_MONITOR_JIT_COMPILATION),
                                                    0);
            if (hr < 0)
            {
                Console.WriteLine($"FAIL: IpCorProfilerInfo::SetEventMask2() failed hr=0x{hr:x8}");
                _failures++;
                return hr;
            }

            var hooksLibPath = Path.GetFullPath(@"..\..\..\..\..\Profilers\bin\profiler\hooks.dll");

            Console.WriteLine(hooksLibPath);

            hr = EnterLeaveFunctionHooks3WithInfo.Initialize(hooksLibPath);

            if (hr.Failed)
            {
                Console.WriteLine($"FAIL EnterLeaveFunctionHooks3WithInfo::Initialize hr={hr}");
                EnterLeaveFunctionHooks3WithInfo.Cleanup();
                return HRESULT.E_FAIL;
            }

            hr = EnterLeaveFunctionHooks3WithInfo.Register(
                (ICorProfilerInfo10*)_sProfilerInfo,
                &EnterStub,
                &LeaveStub,
                &TailcallStub);

            if (hr.Failed)
            {
                Console.WriteLine($"FAIL SetEnterLeaveFunctionHooks3WithInfo::Register hr={hr}");
                EnterLeaveFunctionHooks3WithInfo.Cleanup();
                return HRESULT.E_FAIL;
            }

            Console.WriteLine($"{nameof(InliningProfiler)}::Initialize() -> OK");

            return HRESULT.S_OK;
        }

        public override unsafe HRESULT JITInlining(nuint callerId, nuint calleeId, BOOL* pfShouldInline)
        {
            using var shutdownGuard = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                Console.WriteLine("HasShutdownStarted: TRUE.");
                return HRESULT.S_OK;
            }

            Console.WriteLine("JITInlining");

            int hr = ProfilerInfoHelpers.GetFunctionIDName(
                ProfilerInfo2,
                calleeId,
                out string inlineeName);

            if (hr < 0)
            {
                Console.WriteLine($"Cannot GetFunctionIDFullyQualifiedName of JITInlining CALLEE, hr=0x{hr:x8}");
                return HRESULT.S_OK;
            }

            if (inlineeName == "Inlinee")
            {
                Console.WriteLine("JITInlining: Inlinee");
                hr = ProfilerInfoHelpers.GetFunctionIDName(
                    ProfilerInfo2,
                    callerId,
                    out string inlinerName);

                if (hr < 0)
                {
                    Console.WriteLine($"Cannot GetFunctionIDFullyQualifiedName of JITInlining CALLER, hr=0x{hr:x8}");
                    return HRESULT.S_OK;
                }

                if (inlinerName == "Inlining")
                {
                    Console.WriteLine("JIT: Inlining");
                    *pfShouldInline = true;
                }
                else if (inlinerName == "BlockInlining")
                {
                    Console.WriteLine("JIT: BlockInlining");
                    *pfShouldInline = false;
                }
            }
            return HRESULT.S_OK;
        }

        public override HRESULT Shutdown()
        {
            base.Shutdown();

            if (Interlocked.CompareExchange(ref _failures, 0, 0) == 0 &&
                Interlocked.CompareExchange(ref _sawInlineeCall, 0, 0) == 1)
            {
                Console.WriteLine("PROFILER TEST PASSES");
            }
            else
            {
                var failures = Interlocked.CompareExchange(ref _failures, 0, 0);
                var sawInlineeCall = Interlocked.CompareExchange(ref _sawInlineeCall, 0, 0);
                Console.WriteLine($"TEST FAILED failures={failures} sawInlineeCall={sawInlineeCall}");
            }

            Console.Out.Flush();

            EnterLeaveFunctionHooks3WithInfo.Cleanup();

            return HRESULT.S_OK;
        }
    }
}