using CorProf.Bindings;
using CorProf.Core;
using CorProf.Profiling.Extensions;
using CorProf.Profiling.Threading;
using Microsoft.Diagnostics.Runtime.Utilities;
using Serilog;
using Windows.Win32.Foundation;
using Serilog.Extensions.Logging;
using Microsoft.Extensions.Logging;
using CorProf.Helpers;
using System.Buffers;

using CorProf.Profiling.Windows64;
using CorProf.Profiling.Abstractions;

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

    public override int Initialize(IUnknown* unknown)
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

        return hr;
    }

    public override int ThreadCreated(ulong threadId)
    {
        _threadRegistry.RegisterThread(threadId);
        Interlocked.Increment(ref _seenThreads);
        return HResult.S_OK;
    }

    public override int ThreadDestroyed(ulong threadId)
    {
        // _threadRegistry.TryUnregisterThread(threadId, out _);
        return HResult.S_OK;
    }

    public override int ThreadAssignedToOSThread(ulong managedThreadId, uint osThreadId)
    {
        var realThreadHandle = _threadManager.GetThreadHandle(managedThreadId);

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

        return HResult.S_OK;
    }

    public override int Shutdown()
    {
        base.Shutdown();

        _threadManager.Dispose();

        var threads = _threadRegistry.AsEnumerable().ToArray();

        Console.WriteLine(threads.Length);

        if (threads.Length < _seenThreads)
        {
            return HResult.S_OK;
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

        return HResult.S_OK;
    }
}
