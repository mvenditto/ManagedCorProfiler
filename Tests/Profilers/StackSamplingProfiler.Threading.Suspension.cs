﻿using ClrProfiling.Core;
using ClrProfiling.Backend.Extensions;
using ClrProfiling.Backend.Threading;
using Microsoft.Diagnostics.Runtime.Utilities;
using Serilog;
using Serilog.Extensions.Logging;
using Microsoft.Extensions.Logging;
using ClrProfiling.Helpers;
using ClrProfiling.Backend.Windows;
using System.Diagnostics;
using Windows.Win32.Foundation;
using Tests.Profilers;
using Windows.Win32.System.Com;
using Windows.Win32.System.Diagnostics.ClrProfiling;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace TestProfilers;

[ProfilerCallback("1B0551A7-17A5-444F-BE02-88556934C0D2")]
internal class StackSamplingProfiler_Threading_Suspension : TestProfilerBase
{
    private readonly ManagedThreadRegistry _threadRegistry;
    private bool _targetThreadFound = false;

    private readonly SerilogLoggerFactory _loggerFactory;
    private nuint _targetThreadId;

    private readonly Windows64ThreadManager _threadManager;

    private bool _threadSuspended;
    private bool _threadResumed;

    public unsafe StackSamplingProfiler_Threading_Suspension()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console(outputTemplate: "[{Level:u3}] {Timestamp:dd/MM/yy HH:mm:ss.fff} {Message}{NewLine}{Exception}")
            .CreateLogger();

        _loggerFactory = new SerilogLoggerFactory(Log.Logger);

        _threadRegistry = new ManagedThreadRegistry(
            _loggerFactory.CreateLogger<ManagedThreadRegistry>());

        _threadManager = new Windows64ThreadManager(
            _loggerFactory.CreateLogger<Windows64ThreadManager>(),
            profilerInfo: (ICorProfilerInfo4*)ProfilerInfo);
    }

    private unsafe void StartSamplingThread()
    {
        new Thread(() =>
        {
            ProfilerInfo->InitializeCurrentThread();

            ManagedThreadInfo targetThreadInfo;

            while (true)
            {
                if (_targetThreadFound)
                {
                    if (_threadRegistry.TryGetThreadInfo(_targetThreadId, out targetThreadInfo)
                      && targetThreadInfo?.OSThreadHandle != nint.Zero)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Thread not found: 0x{targetThreadInfo?.OSThreadHandle:x8}");
                    }
                }

                Thread.Sleep(100);
            }

            Console.WriteLine($"Start test: 0x{targetThreadInfo?.OSThreadHandle:x8}");

            _threadSuspended = _threadManager.TrySuspendThread(targetThreadInfo!);

            Log.Logger.Information("Thread suspended: {ThreadSuspended}", _threadSuspended);

            if (_threadSuspended)
            {
                _threadResumed = _threadManager.TryResumeThread(targetThreadInfo!);
                Log.Logger.Information("Thread resumed: {ThreadResumed}", _threadResumed);
            }
        }).Start();
    }

    public unsafe override HRESULT Initialize(IUnknown* unknown)
    {
        var hr = base.Initialize(unknown);

        if (hr != HResult.S_OK)
        {
            return hr;
        }

        hr = ProfilerInfo->SetEventMask2((uint)COR_PRF_MONITOR.COR_PRF_MONITOR_THREADS, 0);

        if (hr < 0)
        {
            Console.WriteLine($"SetEventMask2 failed with hr=0x{hr:x8}");
            return hr;
        }

        StartSamplingThread();

        return hr;
    }

    public override HRESULT ThreadCreated(nuint threadId)
    {
        _threadRegistry.RegisterThread(threadId);
        return HRESULT.S_OK;
    }

    public override HRESULT ThreadDestroyed(nuint threadId)
    {
        // _threadRegistry.TryUnregisterThread(threadId, out _);
        return HRESULT.S_OK;
    }

    public unsafe override HRESULT ThreadAssignedToOSThread(nuint managedThreadId, uint osThreadId)
    {
        Console.WriteLine($"Thread 0x{managedThreadId:x8} -> 0x{osThreadId:x8}");

        var osThreadHandle = HANDLE.Null;

        var hr = ProfilerInfo->GetHandleFromThread(managedThreadId, &osThreadHandle);

        if (hr != HResult.S_OK)
        {
            Log.Warning("FAIL GetHandleFromThread() with hr=0x{hr:x8}", hr);
            return hr;
        }

        Log.Debug("GetHandleFromThread -> 0x{OsThreadHandle:x8}", osThreadHandle);

        var currProcess = Process.GetCurrentProcess();
        var processHandle = new HANDLE(currProcess.Handle);

        const uint THREAD_ALL_ACCESS = 0x1FFFFF;

        var realThreadHandle = HANDLE.Null;

        // acquire a real handle instead of a pseudo-handle.
        var result = NativeMethods.DuplicateHandle(
            processHandle,
            osThreadHandle,
            processHandle,
            &realThreadHandle,
            THREAD_ALL_ACCESS,
            new BOOL(false),
            0
        );

        if (result == 0)
        {
            var err = Marshal.GetLastWin32Error();
            Log.Logger.Warning("FAIL Kernel32::DuplicateHandle() with res=0x{err:x8}: {Message}", err, new Win32Exception(err).Message);
            return hr;
        }

        Console.WriteLine($"Thread 0x{managedThreadId:x8} ======> 0x{realThreadHandle:x8}");

        _threadRegistry.SetOSThreadInfo(managedThreadId, osThreadId, realThreadHandle);

        return HRESULT.S_OK;
    }

    // NOTE: It seems thread callbacks are not guaranteed to be ordered.
    // hence ThreadNameChanged() may be called before ThreadCreated().
    public override unsafe HRESULT ThreadNameChanged(nuint threadId, uint cchName, PWSTR name)
    {
        var threadName = cchName == 0 
            ? string.Empty
            : MarshalHelpers.PtrToStringUtf16((ushort*)name.Value);

        _threadRegistry.SetThreadName(threadId, threadName);

        Log.Logger.Debug("ThreadNameChanged: 0x{ThreadId:x8} -> '{ThreadName}'", threadId, threadName);

        if (threadName == "TestTargetThread")
        {
            _targetThreadId = threadId;
            _targetThreadFound = true;
        }

        return HRESULT.S_OK;
    }

    public override HRESULT Shutdown()
    {
        base.Shutdown();

        _threadManager.Dispose();

        if (_threadSuspended && _threadResumed)
        {
            Console.WriteLine("PROFILER TEST PASSES");
        }

        Console.Out.Flush();

        return HRESULT.S_OK;
    }
}
