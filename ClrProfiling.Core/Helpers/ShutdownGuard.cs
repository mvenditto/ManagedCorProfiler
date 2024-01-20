namespace ClrProfiling.Shared;

public class ShutdownGuard: IDisposable
{
    private static int _preventHooks = 0;
    private static int _hooksInProgress = 0;

    public static bool HasShutdownStarted()
    {
        return Interlocked.CompareExchange(ref _preventHooks, 0, 0) == 1;
    }

    public static void WaitForInProgressHooks()
    {
        Interlocked.Exchange(ref _preventHooks, 1);

        while (Interlocked.CompareExchange(ref _hooksInProgress, 0, 0) > 0)
        {
            Thread.Sleep(10);
        }
    }

    public static void Initialize()
    {
        Interlocked.Exchange(ref _preventHooks, 0);
        Interlocked.Exchange(ref _hooksInProgress, 0);
    }

    public ShutdownGuard()
    {
        Interlocked.Increment(ref _hooksInProgress);
    }

    public void Dispose()
    {
        Interlocked.Decrement(ref _hooksInProgress);
    }
}
