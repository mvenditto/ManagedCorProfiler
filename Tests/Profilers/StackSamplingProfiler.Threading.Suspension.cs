using CorProf.Bindings;
using CorProf.Core;
using CorProf.Profiling.Extensions;
using CorProf.Profiling.Threading;
using Microsoft.Diagnostics.Runtime.Utilities;
using Serilog;
using Serilog.Extensions.Logging;
using Microsoft.Extensions.Logging;
using CorProf.Helpers;
using CorProf.Profiling.Windows64;
using System.Diagnostics;
using Windows.Win32.Foundation;

namespace TestProfilers;

[ProfilerCallback("1B0551A7-17A5-444F-BE02-88556934C0D2")]
internal class StackSamplingProfiler_Threading_Suspension : TestProfilerBase
{
    private readonly ManagedThreadRegistry _threadRegistry;
    private bool _targetThreadFound = false;

    private readonly SerilogLoggerFactory _loggerFactory;
    private ulong _targetThreadId;

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
            var currThreadId = (ulong)0;
            ProfilerInfo->GetCurrentThreadID(&currThreadId);

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

    public unsafe override int Initialize(IUnknown* unknown)
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

    public override int ThreadCreated(ulong threadId)
    {
        _threadRegistry.RegisterThread(threadId);
        return HResult.S_OK;
    }

    public override int ThreadDestroyed(ulong threadId)
    {
        // _threadRegistry.TryUnregisterThread(threadId, out _);
        return HResult.S_OK;
    }

    public unsafe override int ThreadAssignedToOSThread(ulong managedThreadId, uint osThreadId)
    {
        Console.WriteLine($"Thread 0x{managedThreadId:x8} -> 0x{osThreadId:x8}");

        var osThreadHandle = IntPtr.Zero;

        var hr = ProfilerInfo->GetHandleFromThread(managedThreadId, (void**)&osThreadHandle);

        if (hr != HResult.S_OK)
        {
            Log.Warning("FAIL GetHandleFromThread() with hr=0x{hr:x8}", hr);
            return hr;
        }

        Log.Debug("GetHandleFromThread -> 0x{OsThreadHandle:x8}", osThreadHandle);

        var currProcess = Process.GetCurrentProcess();
        var processHandle = new HANDLE(currProcess.Handle);
        var threadHandle = new HANDLE(osThreadHandle);

        const uint THREAD_ALL_ACCESS = 0x1FFFFF;
        const DUPLICATE_HANDLE_OPTIONS DefaultDuplicateHandleOpts = 0;

        var realThreadHandle = HANDLE.Null;

        // acquire a real handle instead of a pseudo-handle.
        hr = Windows.Win32.PInvoke.DuplicateHandle(
            processHandle,
            threadHandle,
            processHandle,
            &realThreadHandle,
            THREAD_ALL_ACCESS,
            false,
            DefaultDuplicateHandleOpts
        );

        if (hr <= HResult.S_OK)
        {
            Log.Logger.Warning("FAIL Kernel32::DuplicateHandle() with hr=0x{hr:x8}", hr);
            return hr;
        }

        Console.WriteLine($"Thread 0x{managedThreadId:x8} ======> 0x{realThreadHandle:x8}");

        _threadRegistry.SetOSThreadInfo(managedThreadId, osThreadId, realThreadHandle);

        return HResult.S_OK;
    }

    // NOTE: It seems thread callbacks are not guaranteed to be ordered.
    // hence ThreadNameChanged() may be called before ThreadCreated().
    public override unsafe int ThreadNameChanged(ulong threadId, uint cchName, ushort* name)
    {
        var threadName = cchName == 0 
            ? string.Empty
            : MarshalHelpers.PtrToStringUtf16(name);

        _threadRegistry.SetThreadName(threadId, threadName);

        Log.Logger.Debug("ThreadNameChanged: 0x{ThreadId:x8} -> '{ThreadName}'", threadId, threadName);

        if (threadName == "TestTargetThread")
        {
            _targetThreadId = threadId;
            _targetThreadFound = true;
        }

        return HResult.S_OK;
    }

    public override int Shutdown()
    {
        base.Shutdown();

        _threadManager.Dispose();

        if (_threadSuspended && _threadResumed)
        {
            Console.WriteLine("PROFILER TEST PASSES");
        }

        Console.Out.Flush();

        return HResult.S_OK;
    }
}
