namespace CorProf.Shared
{
    public class ShutdownGuard: IDisposable
    {
        private static CountdownEvent _hooksInProgress = new(0);

        public static bool HasShutdownStarted()
        {
            return _hooksInProgress.CurrentCount == 0;
        }

        public static void WaitForInProgressHooks()
        {
            _hooksInProgress.Wait();
        }

        public static void Initialize()
        {
            _hooksInProgress.Reset();
        }

        public ShutdownGuard()
        {
            _hooksInProgress.AddCount(1);
        }

        public void Dispose()
        {
            _hooksInProgress.Signal(1);
        }
    }
}
