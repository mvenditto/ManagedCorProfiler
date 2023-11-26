using CorProf.Profiling.Threading;

namespace CorProf.Profiling.Extensions;

public static class ManagedThreadRegistryExtensions
{
    public static bool RegisterThread(this ManagedThreadRegistry threadRegistry, ThreadID clrThreadId)
    {
        var threadInfo = new ManagedThreadInfo(clrThreadId);
        return threadRegistry.RegisterThread(threadInfo);
    }

    public static void SetOSThreadInfo(this ManagedThreadRegistry threadRegistry, ThreadID clrThreadId, uint osThreadId, HANDLE osThreadHandle)
    {
        threadRegistry.GetOrRegister(clrThreadId).SetOSThreadInfo(osThreadId, osThreadHandle);
    }

    public static void SetThreadName(this ManagedThreadRegistry threadRegistry, ThreadID clrThreadId, string threadName)
    {
        threadRegistry.GetOrRegister(clrThreadId).SetThreadName(threadName);
    }
}
