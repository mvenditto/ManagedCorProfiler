using System.Runtime.InteropServices;

while (true)
{
    NativeMethods.DoPInvoke();
    Thread.Sleep(50);
}

static class NativeMethods
{
    [DllImport("Profiler")]
    public static extern void DoPInvoke();
}