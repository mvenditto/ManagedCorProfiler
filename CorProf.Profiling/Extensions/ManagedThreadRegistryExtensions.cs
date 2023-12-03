using CorProf.Profiling.Threading;
using System.Runtime.CompilerServices;

namespace CorProf.Profiling.Extensions;

public static class ManagedThreadRegistryExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool RegisterThread(this ManagedThreadRegistry threadRegistry, ThreadID clrThreadId)
    {
        return threadRegistry.RegisterThread(new ManagedThreadInfo(clrThreadId));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetOSThreadInfo(this ManagedThreadRegistry threadRegistry, ThreadID clrThreadId, uint osThreadId, HANDLE osThreadHandle)
    {
        threadRegistry.GetOrRegister(clrThreadId).SetOSThreadInfo(osThreadId, osThreadHandle);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetThreadName(this ManagedThreadRegistry threadRegistry, ThreadID clrThreadId, string threadName)
    {
        threadRegistry.GetOrRegister(clrThreadId).SetThreadName(threadName);
    }
}