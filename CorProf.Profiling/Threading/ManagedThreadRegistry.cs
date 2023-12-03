using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace CorProf.Profiling.Threading;

public unsafe sealed class ManagedThreadRegistry
{
    private readonly ILogger<ManagedThreadRegistry> _logger;
    private readonly ConcurrentDictionary<ThreadID, ManagedThreadInfo> _managedThreads;

    private static readonly Action<ILogger, ThreadID, Exception> ThreadRegistered = LoggerMessage.Define<ThreadID>(
        LogLevel.Debug,
        new EventId(1, nameof(RegisterThread)),
        "Registered thread 0x{ThreadId:x8}");

    private static readonly Action<ILogger, ThreadID, Exception> ThreadUnregistered = LoggerMessage.Define<ThreadID>(
        LogLevel.Debug,
        new EventId(2, nameof(TryUnregisterThread)),
        "Unregistered thread 0x{ThreadId:x8}");

    public ManagedThreadRegistry(ILogger<ManagedThreadRegistry> logger)
    {
        _logger = logger;

        // default capacity and concurrency should be respectively Environment.ProcessorCount and 32 initial capacity.
        _managedThreads = new();
    }

    public bool TryGetThreadInfo(ThreadID clrThreadId, out ManagedThreadInfo managedThreadInfo)
    {
        return _managedThreads.TryGetValue(clrThreadId, out managedThreadInfo);
    }

    public ManagedThreadInfo GetOrRegister(ThreadID clrThreadId)
    {
        return _managedThreads.GetOrAdd(clrThreadId, ManagedThreadInfo.Create);
    }

    public bool RegisterThread(ManagedThreadInfo threadInfo)
    {
        ThreadRegistered(_logger, threadInfo.CLRThreadId, default!);
        return _managedThreads.TryAdd(threadInfo.CLRThreadId, threadInfo);
    }

    public bool TryUnregisterThread(ThreadID clrThreadId, out ManagedThreadInfo threadInfo)
    {
        ThreadUnregistered(_logger, clrThreadId, default!);
        return _managedThreads.TryRemove(clrThreadId, out threadInfo);
    }

    public IEnumerable<KeyValuePair<ThreadID, ManagedThreadInfo>> AsEnumerable()
    {
        return _managedThreads.AsEnumerable();
    }
}
