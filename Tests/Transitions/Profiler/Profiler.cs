using Microsoft.Diagnostics.Runtime.Utilities;
using System.Runtime.InteropServices;
using CorProf.Core;
using CorProf.Helpers;
using CorProf.Bindings;
using ICorProfilerCallback = CorProf.Core.Interfaces.ICorProfilerCallback;
using ICorProfilerCallback2 = CorProf.Core.Interfaces.ICorProfilerCallback2;

namespace Transitions
{
    [ProfilerCallback("090B7720-6605-462B-86A0-C4D4C444D3F5")]
    internal unsafe class TransitionsProfiler : ICorProfilerCallback2
    {
        private int _failures = 0;
        private ICorProfilerInfo11* _profilerInfo;
        private ICorProfilerInfoHelpers2 _profilerInfoHelpers;
        private string _expectedPinvokeName;
        private string _expectedReversePInvokeName;
        private const COR_PRF_TRANSITION_REASON NO_TRANSITION = (COR_PRF_TRANSITION_REASON)(-1);

        private const int ERROR_ENVVAR_NOT_FOUND = 0xCB;

        /// <summary>
        /// This can be PInvoked from the profiler application
        /// with DllImport("Profiler")
        /// </summary>
        [UnmanagedCallersOnly(EntryPoint = "DoPInvoke")]
        public static void DoPInvoke(delegate* unmanaged<int, int> callback, int i)
        {
            Console.WriteLine($"DoPInvoke: {callback(i)}");
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct TransitionInstance
        {
            public TransitionInstance()
            {
                UnmanagedToManaged = NO_TRANSITION;
                ManagedToUnmanaged = NO_TRANSITION;
            }

            public COR_PRF_TRANSITION_REASON UnmanagedToManaged;
            public COR_PRF_TRANSITION_REASON ManagedToUnmanaged;
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
                (ICorProfilerInfo2*) pinfo);

            var eventsLow = COR_PRF_MONITOR.COR_PRF_MONITOR_CODE_TRANSITIONS
                | COR_PRF_MONITOR.COR_PRF_DISABLE_INLINING;

            hr = _profilerInfo->SetEventMask2((uint) eventsLow, 0);

            if (hr < 0)
            {
                Console.WriteLine($"SetEventMask2 failed with hr=0x{hr:x8}");
                return HResult.E_FAIL;
            }

            // exploit the fact the we are actually inject in the profilee process
            _expectedPinvokeName = Environment.GetEnvironmentVariable(
                "PInvoke_Transition_Expected_Name",
                EnvironmentVariableTarget.Process)!;

            _expectedReversePInvokeName = Environment.GetEnvironmentVariable(
                "ReversePInvoke_Transition_Expected_Name",
                EnvironmentVariableTarget.Process)!;

            Console.WriteLine($"{_expectedPinvokeName} {_expectedReversePInvokeName}");

            return HResult.S_OK;
        }

        int ICorProfilerCallback.ManagedToUnmanagedTransition(ulong functionId, COR_PRF_TRANSITION_REASON reason)
        {/*
            var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                Console.WriteLine("ShutdownGuard::HasShutdownStarted");
                return HResult.S_OK;
            }

            int hr = _profilerInfoHelpers.GetFunctionIDName(functionId, out string funcName);

            if (hr < 0)
            {
                Console.WriteLine($"Error 0x{hr:x8}");
            }
            else
            {
                Console.WriteLine($"M => N : {funcName}");
            }*/

            return HResult.S_OK;
        }

        int ICorProfilerCallback.UnmanagedToManagedTransition(ulong functionId, COR_PRF_TRANSITION_REASON reason)
        {/*
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                Console.WriteLine("ShutdownGuard::HasShutdownStarted");
                return HResult.S_OK;
            }

            int hr = _profilerInfoHelpers.GetFunctionIDName(functionId, out var funcName);

            if (hr < 0)
            {
                Console.WriteLine($"Error 0x{hr:x8}");
            }
            else
            {
                Console.WriteLine($"U => M : {funcName}");
            }*/

            return HResult.S_OK;
        }

        int ICorProfilerCallback.Shutdown() 
        {
            Console.WriteLine("PROFILER TEST PASSES");

            return HResult.S_OK; 
        }
    }
}