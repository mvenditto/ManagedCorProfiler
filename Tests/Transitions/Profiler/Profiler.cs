using CorProf.Bindings;
using CorProf.Core;
using CorProf.Helpers;
using CorProf.Shared;
using Microsoft.Diagnostics.Runtime.Utilities;
using System.Runtime.InteropServices;

using ICorProfilerCallback = CorProf.Core.Interfaces.ICorProfilerCallback;
using ICorProfilerCallback2 = CorProf.Core.Interfaces.ICorProfilerCallback2;

using static CorProf.Bindings.COR_PRF_TRANSITION_REASON;

namespace Transitions
{
    [ProfilerCallback("090B7720-6605-462B-86A0-C4D4C444D3F5")]
    internal unsafe class TransitionsProfiler : ICorProfilerCallback2
    {
        private ICorProfilerInfo11* _profilerInfo;
        private ICorProfilerInfoHelpers2 _profilerInfoHelpers;

        private string _expectedPinvokeName;
        private string _expectedReversePInvokeName;

        private int _failures = 0;
        private readonly TransitionInstance _pinvoke = new();
        private readonly TransitionInstance _reversePinvoke = new();

        private const COR_PRF_TRANSITION_REASON NO_TRANSITION = (COR_PRF_TRANSITION_REASON)(-1);

        private class TransitionInstance
        {
            public TransitionInstance()
            {
                UnmanagedToManaged = NO_TRANSITION;
                ManagedToUnmanaged = NO_TRANSITION;
            }

            public COR_PRF_TRANSITION_REASON UnmanagedToManaged;
            public COR_PRF_TRANSITION_REASON ManagedToUnmanaged;
        }

        /// <summary>
        /// This can be PInvoked from the profiler application
        /// with DllImport("Profiler")
        /// </summary>
        [UnmanagedCallersOnly(EntryPoint = "DoPInvoke")]
        public static void DoPInvoke(delegate* unmanaged<int, int> callback, int i)
        {
            Console.WriteLine($"Profiler::DoPInvoke(): {callback(i)}");
        }

        int ICorProfilerCallback.Initialize(IUnknown* unknown)
        {
            var guid_ = CorProfConsts.IID_ICorProfilerInfo5;

            var hr = Marshal.QueryInterface((nint)unknown, ref guid_, out var pinfo);

            if (hr < 0)
            {
                Console.WriteLine($"Failed to get ICorProfilerInfo11 with hr=0x{hr:x8}");
                return HResult.E_FAIL;
            }

            _profilerInfo = (ICorProfilerInfo11*)pinfo;

            _profilerInfoHelpers = new ICorProfilerInfoHelpers2(
                (ICorProfilerInfo2*)pinfo);

            var eventsLow = COR_PRF_MONITOR.COR_PRF_MONITOR_CODE_TRANSITIONS
                | COR_PRF_MONITOR.COR_PRF_DISABLE_INLINING;

            hr = _profilerInfo->SetEventMask2((uint)eventsLow, 0);

            if (hr < 0)
            {
                Console.WriteLine($"SetEventMask2 failed with hr=0x{hr:x8}");
                return HResult.E_FAIL;
            }

            // exploit the fact the we are actually injected in the profilee process
            _expectedPinvokeName = Environment.GetEnvironmentVariable(
                "PInvoke_Transition_Expected_Name",
                EnvironmentVariableTarget.Process)!;

            _expectedReversePInvokeName = Environment.GetEnvironmentVariable(
                "ReversePInvoke_Transition_Expected_Name",
                EnvironmentVariableTarget.Process)!;

            return HResult.S_OK;
        }

        private bool FunctionIsTargetFunction(
            ulong functionId,
            out TransitionInstance? inst,
            out string funcName)
        {
            inst = null;
            int hr = _profilerInfoHelpers.GetFunctionIDName(functionId, out funcName);

            if (hr < 0)
            {
                Console.WriteLine($"GetFunctionIDName error 0x{hr:x8}");
            }
            else
            {
                if (funcName == _expectedPinvokeName)
                {
                    inst = _pinvoke;
                }
                else if (funcName == _expectedReversePInvokeName)
                {
                    inst = _reversePinvoke;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        int ICorProfilerCallback.ManagedToUnmanagedTransition(ulong functionId, COR_PRF_TRANSITION_REASON reason)
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                return HResult.S_OK;
            }

            if (FunctionIsTargetFunction(functionId, out TransitionInstance? inst, out string funcName) && inst != null)
            {
                if (inst.ManagedToUnmanaged != NO_TRANSITION)
                {
                    Console.WriteLine($"[M -> U] Duplicate transition: '{funcName}'");
                    _failures += 1;
                }
                Console.WriteLine($"[M -> U] '{funcName}'");
                inst.ManagedToUnmanaged = reason;
            }

            return HResult.S_OK;
        }

        int ICorProfilerCallback.UnmanagedToManagedTransition(ulong functionId, COR_PRF_TRANSITION_REASON reason)
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                return HResult.S_OK;
            }

            if (FunctionIsTargetFunction(functionId, out TransitionInstance? inst, out string funcName) && inst != null)
            {
                if (inst.UnmanagedToManaged != NO_TRANSITION)
                {
                    Console.WriteLine($"[U -> M] Duplicate transition: '{funcName}'");
                    _failures += 1;
                }
                Console.WriteLine($"[M -> U] '{funcName}'");
                inst.UnmanagedToManaged = reason;
            }

            return HResult.S_OK;
        }

        int ICorProfilerCallback.Shutdown()
        {
            bool successPinvoke = _pinvoke.ManagedToUnmanaged == COR_PRF_TRANSITION_CALL
                    && _pinvoke.UnmanagedToManaged == COR_PRF_TRANSITION_RETURN;

            bool successReversePinvoke = _reversePinvoke.ManagedToUnmanaged == COR_PRF_TRANSITION_RETURN
                            && _reversePinvoke.UnmanagedToManaged == COR_PRF_TRANSITION_CALL;

            if (_failures == 0 && successPinvoke && successReversePinvoke)
            {
                Console.WriteLine("PROFILER TEST PASSES");
            }
            else
            {
                Console.WriteLine($"Test failed _failures={_failures} _pinvoke={successPinvoke} _reversePinvoke={successReversePinvoke}");
            }

            return HResult.S_OK;
        }
    }
}