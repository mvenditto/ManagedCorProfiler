using ClrProfiling.Core;
using ClrProfiling.Helpers;
using ClrProfiling.Shared;
using Microsoft.Diagnostics.Runtime.Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

using Windows.Win32.Foundation;
using Windows.Win32.System.Com;
using Windows.Win32.System.Diagnostics.ClrProfiling;

namespace TestProfilers
{
    [ProfilerCallback("090B7720-6605-462B-86A0-C4D4C444D3F5")]
    internal unsafe class TransitionsProfiler: TestProfilerBase
    {
        //private ICorProfilerInfo11* _profilerInfo;
        //private ICorProfilerInfoHelpers2 _profilerInfoHelpers;

        private string _expectedPinvokeName;
        private string _expectedReversePInvokeName;

        private int _failures = 0;
        private TransitionInstance _pinvoke;
        private TransitionInstance _reversePinvoke;

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
            Console.WriteLine($"PInvoke received i={callback(i)}");
        }

        public override HRESULT Initialize(IUnknown* unknown)
        {
            base.Initialize(unknown);

            var eventsLow = COR_PRF_MONITOR.COR_PRF_MONITOR_CODE_TRANSITIONS
                | COR_PRF_MONITOR.COR_PRF_DISABLE_INLINING;

            var hr = ProfilerInfo->SetEventMask2((uint)eventsLow, 0);

            if (hr.Failed)
            {
                Console.WriteLine($"SetEventMask2 failed with hr=0x{hr:x8}");
                return HRESULT.E_FAIL;
            }

            // exploit the fact the we are actually injected in the profilee process
            _expectedPinvokeName = Environment.GetEnvironmentVariable(
                "PInvoke_Transition_Expected_Name",
                EnvironmentVariableTarget.Process)!;

            _expectedReversePInvokeName = Environment.GetEnvironmentVariable(
                "ReversePInvoke_Transition_Expected_Name",
                EnvironmentVariableTarget.Process)!;

            _pinvoke = new TransitionInstance();
            _reversePinvoke = new TransitionInstance();

            return HRESULT.S_OK;
        }

        private bool FunctionIsTargetFunction(
            nuint functionId,
            [MaybeNull] out TransitionInstance inst,
            out string funcName)
        {
            inst = null;

            var hr = ProfilerInfoHelpers.GetFunctionFullyQualifiedName(ProfilerInfo2, functionId, out funcName);

            if (hr.Failed)
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

        public override HRESULT ManagedToUnmanagedTransition(nuint functionId, COR_PRF_TRANSITION_REASON reason)
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                Console.WriteLine("Shutting-down: abort callback...");
                return HRESULT.S_OK;
            }

            if (FunctionIsTargetFunction(functionId, out TransitionInstance? inst, out string funcName) && inst != null)
            {
                if (inst.ManagedToUnmanaged != NO_TRANSITION)
                {
                    Console.WriteLine($"M>>> Duplicate transition: '{funcName}' 0x{functionId:x8}");
                    _failures += 1;
                }
                else
                {
                    Console.WriteLine($"M>>> '{funcName}' 0x{functionId:x8} ({reason})");
                }
                inst.ManagedToUnmanaged = reason;
            }
            return HRESULT.S_OK;
        }

        public override HRESULT UnmanagedToManagedTransition(nuint functionId, COR_PRF_TRANSITION_REASON reason)
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                Console.WriteLine("Shutting-down: abort callback...");
                return HRESULT.S_OK;
            }

            if (FunctionIsTargetFunction(functionId, out TransitionInstance? inst, out string funcName) && inst != null)
            {
                if (inst.UnmanagedToManaged != NO_TRANSITION)
                {
                    Console.WriteLine($"<<<U Duplicate transition: '{funcName}' 0x{functionId:x8}");
                    _failures += 1;
                }
                else
                {
                    Console.WriteLine($"<<<U '{funcName}' 0x{functionId:x8} ({reason})");
                }
                inst.UnmanagedToManaged = reason;
            }

            return HRESULT.S_OK;
        }

        public override HRESULT Shutdown()
        {
            base.Shutdown();

            bool successPinvoke = _pinvoke.ManagedToUnmanaged == COR_PRF_TRANSITION_REASON.COR_PRF_TRANSITION_CALL
                    && _pinvoke.UnmanagedToManaged == COR_PRF_TRANSITION_REASON.COR_PRF_TRANSITION_RETURN;

            bool successReversePinvoke = _reversePinvoke.ManagedToUnmanaged == COR_PRF_TRANSITION_REASON.COR_PRF_TRANSITION_RETURN
                            && _reversePinvoke.UnmanagedToManaged == COR_PRF_TRANSITION_REASON.COR_PRF_TRANSITION_CALL;

            if (_failures == 0 && successPinvoke && successReversePinvoke)
            {
                Console.WriteLine("PROFILER TEST PASSES");
            }
            else
            {
                Console.WriteLine($"Test failed _failures={_failures} _pinvoke={successPinvoke} _reversePinvoke={successReversePinvoke}");
            }

            return HRESULT.S_OK;
        }
    }
}