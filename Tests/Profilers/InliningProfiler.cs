using CorProf.Bindings;
using CorProf.Core;
using CorProf.Helpers;
using CorProf.Shared;
using CorProf.Utilities;
using Microsoft.Diagnostics.Runtime.Utilities;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Tests.Common;
using static CorProf.Bindings.COR_PRF_MONITOR;

namespace TestProfilers
{
    [ProfilerCallback("DDADC0CB-21C8-4E53-9A6C-7C65EE5800CE")]
    internal unsafe class InliningProfiler: TestProfilerBase
    {
        private static int _failures;

        // bool actually
        private static int _sawInlineeCall;
        private static int _inInlining;
        private static int _inBlockInlining;
        private static int _inNoResponse;

        private static ICorProfilerInfo11* _sProfilerInfo;
        private static ICorProfilerInfoHelpers2 _sProfilerInfoHelpers;

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static void EnterStub(FunctionIDOrClientID functionOrClientId, ulong eltInfo)
        {
            // SHUTDOWNGUARD_RETVOID();
            if (ShutdownGuard.HasShutdownStarted())
            {
                return;
            }

            // Console.WriteLine($"> ENTER functionId=0x{functionOrClientId.functionID:x8} clientId=0x{functionOrClientId.clientID:x8}");

            int hr = _sProfilerInfoHelpers.GetFunctionFullyQualifiedName
                (functionOrClientId.functionID, 
                out string functionName);

            if (hr < 0)
            {
                Console.WriteLine($"GetFunctionIDFullyQualifiedName failed for 0x{functionOrClientId.functionID:x8} with hr 0x{hr:x8}");
                return;
            }

            if (functionName == "Inlining")
            {
                Console.WriteLine($">>> {functionName}");
                Interlocked.Exchange(ref _inInlining, Bool.TRUE);
            }
            else if (functionName == "BlockInlining")
            {
                Console.WriteLine($">>> {functionName}");
                Interlocked.Exchange(ref _inBlockInlining, Bool.TRUE);
            }
            else if (functionName =="NoResponse")
            {
                Console.WriteLine($">>> {functionName}");
                Interlocked.Exchange(ref _inNoResponse, Bool.TRUE);
            }
            else if (functionName == "Inlinee")
            {
                Console.WriteLine($">>> {functionName}");
                if (Interlocked.CompareExchange(ref _inInlining, 0, 0) == Bool.TRUE
                 || Interlocked.CompareExchange(ref _inNoResponse, 0, 0) == Bool.TRUE)
                {
                    Interlocked.Increment(ref _failures);
                    Console.WriteLine("Saw Inlinee as a real method call instead of inlined.");
                }

                if (Interlocked.CompareExchange(ref _inBlockInlining, 0, 0) == Bool.TRUE)
                {
                    Interlocked.Exchange(ref _sawInlineeCall, Bool.TRUE);
                }
            }

            // Console.WriteLine("<ENTER");
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static void LeaveStub(FunctionIDOrClientID functionOrClientId, ulong eltInfo)
        {
            if (ShutdownGuard.HasShutdownStarted())
            {
                return;
            }

            // Console.WriteLine(">LEAVE");

            int hr = _sProfilerInfoHelpers.GetFunctionIDName(functionOrClientId.functionID, out string functionName);

            if (hr < 0)
            {
                Console.WriteLine($"GetFunctionIDFullyQualifiedName failed for 0x{functionOrClientId.functionID:x8} with hr 0x{hr:x8}");
                return;
            }

            if (functionName == "Inlining")
            {
                Console.WriteLine($"<<< {functionName}");
                Interlocked.Exchange(ref _inInlining, Bool.FALSE);
            }
            else if (functionName == "BlockInlining")
            {
                Console.WriteLine($"<<< {functionName}");
                Interlocked.Exchange(ref _inBlockInlining, Bool.FALSE);
            }
            else if (functionName == "NoResponse")
            {
                Console.WriteLine($"<<< {functionName}");
                Interlocked.Exchange(ref _inNoResponse, Bool.FALSE);
            }

            // Console.WriteLine("<LEAVE");
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static void TailcallStub(FunctionIDOrClientID functionOrClientId, ulong eltInfo)
        {
            if (ShutdownGuard.HasShutdownStarted())
            {
                return;
            }
        }

        public override unsafe int Initialize(IUnknown* unknown)
        {
            base.Initialize(unknown);

            _sProfilerInfo = _profilerInfo;
            _sProfilerInfoHelpers = _profilerInfoHelpers;

            int hr = _profilerInfo->SetEventMask2((uint)(COR_PRF_MONITOR_ENTERLEAVE
                                                    | COR_PRF_ENABLE_FUNCTION_ARGS
                                                    | COR_PRF_ENABLE_FUNCTION_RETVAL
                                                    | COR_PRF_ENABLE_FRAME_INFO
                                                    | COR_PRF_MONITOR_JIT_COMPILATION), 
                                                    0);
            Console.WriteLine("LOAD HOOKS");
            if (hr < 0)
            {
                Console.WriteLine($"FAIL: IpCorProfilerInfo::SetEventMask2() failed hr=0x{hr:x8}");
                _failures++;
                return hr;
            }
            var hooksLibPath = Path.GetFullPath(@"..\..\..\..\Profilers\bin\profiler\hooks.dll");
            Console.WriteLine(hooksLibPath);
            EnterLeaveHooks3WithInfo.Initialize(hooksLibPath);

            EnterLeaveHooks3WithInfo.EnterLeaveCallbacks->Enter = &EnterStub;
            EnterLeaveHooks3WithInfo.EnterLeaveCallbacks->Leave = &LeaveStub;
            EnterLeaveHooks3WithInfo.EnterLeaveCallbacks->Tailcall = &TailcallStub;

            EnterLeaveHooks3WithInfo.SetCallbacks(EnterLeaveHooks3WithInfo.EnterLeaveCallbacks);

            hr = _profilerInfo->SetEnterLeaveFunctionHooks3WithInfo(
                (delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void>)EnterLeaveHooks3WithInfo.EnterNaked3WithInfo,
                (delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void>)EnterLeaveHooks3WithInfo.LeaveNaked3WithInfo,
                (delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void>)EnterLeaveHooks3WithInfo.TailcallNaked3WithInfo);

            if (hr < 0)
            {
                Console.WriteLine($"Error SetEnterLeaveFunctionHooks3WithInfo hr={hr}");
                return HResult.E_FAIL;
            }

            return HResult.S_OK;
        }

        public override unsafe int JITInlining(ulong callerId, ulong calleeId, int* pfShouldInline)
        {
            using var shutdownGuard = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                return HResult.S_OK;
            }

            Console.WriteLine("JITInlining");

            int hr = _profilerInfoHelpers.GetFunctionIDName(
                calleeId,
                out string inlineeName);

            if (hr < 0)
            {
                Console.WriteLine($"Cannot GetFunctionIDFullyQualifiedName of JITInlining CALLEE, hr=0x{hr:x8}");
                return HResult.S_OK;
            }

            if (inlineeName == "Inlinee")
            {
                Console.WriteLine("JITInlining: Inlinee");
                hr = _profilerInfoHelpers.GetFunctionIDName(
                    callerId,
                    out string inlinerName);

                if (hr < 0)
                {
                    Console.WriteLine($"Cannot GetFunctionIDFullyQualifiedName of JITInlining CALLER, hr=0x{hr:x8}");
                    return HResult.S_OK;
                }

                if (inlinerName == "Inlining")
                {
                    Console.WriteLine("JIT: Inlining");
                    *pfShouldInline = Bool.TRUE;
                }
                else if (inlinerName == "BlockInlining")
                {
                    Console.WriteLine("JIT: BlockInlining");
                    *pfShouldInline = Bool.FALSE;
                }
            }
            return HResult.S_OK;
        }

        public override int Shutdown()
        {
            base.Shutdown();

            if (Interlocked.CompareExchange(ref _failures, 0, 0) == 0 && 
                Interlocked.CompareExchange(ref _sawInlineeCall, 0, 0) == Bool.TRUE)
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

            // EnterLeaveHooks3WithInfo.Cleanup();

            return HResult.S_OK;
        }
    }
}
