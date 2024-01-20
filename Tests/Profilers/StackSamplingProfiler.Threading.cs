using ClrProfiling.Core;
using ClrProfiling.Backend.Extensions;
using ClrProfiling.Backend.Threading;
using Microsoft.Extensions.Logging;
using ClrProfiling.Helpers;
using System.Buffers;
using Windows.Win32.Foundation;
using Windows.Win32.System.Com;
using Windows.Win32.System.Diagnostics.ClrProfiling;

using ClrProfiling.Backend.Windows;
using Serilog;
using Serilog.Extensions.Logging;

namespace TestProfilers;

[ProfilerCallback("1B0551A7-17A5-444F-BE02-88556934C0D1")]
internal unsafe class StackSamplingProfiler_Threading : TestProfilerBase
{
    private readonly ManagedThreadRegistry _threadRegistry;
    private readonly Windows64ThreadManager _threadManager;

    private int _seenThreads = 0;

    public StackSamplingProfiler_Threading()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console(outputTemplate: "[{Level:u3}] {Timestamp:dd/MM/yy HH:mm:ss.fff} {Message}{NewLine}{Exception}")
            .CreateLogger();

        var logger = new SerilogLoggerFactory(Log.Logger);

        _threadRegistry = new ManagedThreadRegistry(
            logger.CreateLogger<ManagedThreadRegistry>());

        _threadManager = new Windows64ThreadManager(
            logger.CreateLogger<Windows64ThreadManager>(),
            profilerInfo: (ICorProfilerInfo4*)ProfilerInfo);
    }

    public override HRESULT Initialize(IUnknown* unknown)
    {
        var hr = base.Initialize(unknown);

        if (hr.Failed)
        {
            return hr;
        }

        hr = ProfilerInfo->SetEventMask2((uint)COR_PRF_MONITOR.COR_PRF_MONITOR_THREADS, 0);

        if (hr.Failed)
        {
            Console.WriteLine($"SetEventMask2 failed with hr=0x{hr:x8}");
            return hr;
        }

        return hr;
    }

    public override HRESULT ThreadCreated(nuint threadId)
    {
        _threadRegistry.RegisterThread(threadId);
        Interlocked.Increment(ref _seenThreads);
        return HRESULT.S_OK;
    }

    public override HRESULT ThreadDestroyed(nuint threadId)
    {
        // _threadRegistry.TryUnregisterThread(threadId, out _);
        return HRESULT.S_OK;
    }

    public override HRESULT ThreadAssignedToOSThread(nuint managedThreadId, uint osThreadId)
    {
        var realThreadHandle = _threadManager.GetThreadHandle(managedThreadId);

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

        return HRESULT.S_OK;
    }

    public override HRESULT Shutdown()
    {
        base.Shutdown();

        _threadManager.Dispose();

        var threads = _threadRegistry.AsEnumerable().ToArray();

        Console.WriteLine(threads.Length);

        if (threads.Length < _seenThreads)
        {
            return HRESULT.S_OK;
        }

        var names = threads.Select(x => x.Value.ThreadName)
            .Where(x => x.StartsWith("TestThread-"))
            .ToArray();

        var seenAll = true;

        Console.WriteLine(names.Length);

        foreach (var name in names) 
        {
            Console.WriteLine($"NAME: {name}");
        }

        for (var i = 0; i < 10; i++)
        {
            if (!names.Contains("TestThread-" + i))
            {
                seenAll = false;
                break;
            }
        }

        if (seenAll)
        {
            Console.WriteLine("PROFILER TEST PASSES");
        }

        Console.Out.Flush();

        return HRESULT.S_OK;
    }
}
