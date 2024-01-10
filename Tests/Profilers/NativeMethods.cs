using System.Runtime.InteropServices;
using Windows.Win32.Foundation;

namespace Tests.Profilers;

internal static class NativeMethods
{
    [DllImport("KERNEL32.dll", ExactSpelling = true, EntryPoint = "DuplicateHandle", SetLastError = true)]
    public static extern unsafe int DuplicateHandle(HANDLE hSourceProcessHandle, HANDLE hSourceHandle, HANDLE hTargetProcessHandle, HANDLE* lpTargetHandle, uint dwDesiredAccess, BOOL bInheritHandle, uint dwOptions);
}
