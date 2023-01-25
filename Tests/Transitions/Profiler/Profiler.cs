  using Microsoft.Diagnostics.Runtime.Utilities;
using System.Runtime.InteropServices;
using Serilog;
using CorProf.Core;
using CorProf.Shared;
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
        public static void DoPInvoke()
        {
            Console.WriteLine("PINVOKE");
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

        public TransitionsProfiler()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();
        }

        int ICorProfilerCallback.Initialize(IUnknown* unknown)
        {
            Log.Information("INITIALIZE");

            var guid_ = CorProfConsts.IID_ICorProfilerInfo5;

            var hr = Marshal.QueryInterface((nint)unknown, ref guid_, out var pinfo);

            if (hr < 0)
            {
                Log.Error("Failed to get ICorProfilerInfo11 with hr=0x{hr:x8}", hr);
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
                Log.Error("SetEventMask2 failed with hr=0x{hr:x8}", hr);
                return HResult.E_FAIL;
            }

            uint bufferSize = 1024;
            uint envVarLen = 0;
            var envVar = (ushort*)NativeMemory.Alloc(sizeof(ushort) * bufferSize);
            var envVarName = Marshal.StringToHGlobalUni("PInvoke_Transition_Expected_Name");

            hr = _profilerInfo->GetEnvironmentVariableA(
                (ushort*)envVarName, 
                bufferSize, 
                &envVarLen, 
                envVar);

            if (hr < 0)
            {
                Log.Error("GetEnvironmentVariableA failed with hr=0x{hr:x8}", hr);
                NativeMemory.Free(envVar);
                return HResult.E_FAIL;
            }

            _expectedPinvokeName = Marshal.PtrToStringUni((nint)envVar, (int)envVarLen);

            
            envVarName = Marshal.StringToHGlobalUni("ReversePInvoke_Transition_Expected_Name");

            hr = _profilerInfo->GetEnvironmentVariableA(
                (ushort*)envVarName,
                bufferSize,
                &envVarLen,
                envVar);


            _expectedReversePInvokeName = Marshal.PtrToStringUni((nint)envVar, (int)envVarLen);

            if (hr < 0)
            {
                Log.Error("GetEnvironmentVariableA failed with hr=0x{hr:x8}", hr);
                NativeMemory.Free(envVar);
                return HResult.E_FAIL;
            }

            Log.Information("{A} {B}", _expectedPinvokeName, _expectedReversePInvokeName);

            NativeMemory.Free(envVar);
            return HResult.S_OK;
        }

        int ICorProfilerCallback.ManagedToUnmanagedTransition(ulong functionId, COR_PRF_TRANSITION_REASON reason)
        {
            var _ = new ShutdownGuard();

            int hr = 0;
            string funcName = "";

            if (ShutdownGuard.HasShutdownStarted())
            {
                Log.Information("ShutdownGuard::HasShutdownStarted");
                return HResult.S_OK;
            }

            hr = _profilerInfoHelpers.GetFunctionIDName(functionId, out funcName);

            if (hr < 0)
            {
                Log.Error("Error 0x{HR:x8}", hr);
            }
            else
            {
                Log.Information("M => N : {FuncName}", funcName);
            }

            return HResult.S_OK;
        }

        int ICorProfilerCallback.UnmanagedToManagedTransition(ulong functionId, COR_PRF_TRANSITION_REASON reason)
        {
            using var _ = new ShutdownGuard();

            if (ShutdownGuard.HasShutdownStarted())
            {
                Log.Information("ShutdownGuard::HasShutdownStarted");
                return HResult.S_OK;
            }

            int hr = _profilerInfoHelpers.GetFunctionIDName(functionId, out var funcName);

            if (hr < 0)
            {
                Log.Error("Error 0x{HR:x8}", hr);
            }
            else
            {
                Log.Information("U => M : {FuncName}", funcName);
            }

            return HResult.S_OK;
        }

        int ICorProfilerCallback.Shutdown() 
        {
            Log.Information("Shutdown.");

            return HResult.S_OK; 
        }
    }
}