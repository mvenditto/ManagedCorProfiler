using System.Collections.Concurrent;

namespace CorProf.Profiling.Threading;

public unsafe sealed class ManagedThreadRegistry
{
    private readonly ConcurrentDictionary<ThreadID, ManagedThreadInfo> _managedThreads;

    public ManagedThreadRegistry()
    {
        // default capacity and concurrency should be respectively Environment.ProcessorCount and 32 initial capacity.
        _managedThreads = new();
    }

    public bool RegisterThread(ManagedThreadInfo threadInfo)
    {
        return _managedThreads.TryAdd(threadInfo.CLRThreadId, threadInfo);
    }

    public bool TryUnregisterThread(ThreadID clrThreadId, out ManagedThreadInfo? threadInfo)
    {
        return _managedThreads.TryRemove(clrThreadId, out threadInfo);
    }

    public IEnumerable<KeyValuePair<ThreadID, ManagedThreadInfo>> AsEnumerable()
    {
        return _managedThreads.AsEnumerable();
    }
}
