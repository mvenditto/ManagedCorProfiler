using System.Runtime.CompilerServices;
using Windows.Win32;
using Windows.Win32.Foundation;

namespace System.Runtime.InteropServices.ComTypes;


internal static class FILETIMEExtensions
{
    public static ulong ToMilliseconds2(this FILETIME filetime)
    {
        if (PInvoke_Windows.FileTimeToSystemTime(filetime, out var systemTime))
        {
            return systemTime.ToMilliseconds();
        }

        return 0;
    }
    
    public static ulong ToMilliseconds3(this FILETIME filetime)
    {
        var ticksSinceWindowsEpoch = ((long)filetime.dwHighDateTime << 32) + filetime.dwLowDateTime;
        var milliseconds = ticksSinceWindowsEpoch / 10000;
        return (ulong)milliseconds;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong ToMilliseconds(this FILETIME filetime)
    {
        var ticks = ((ulong)filetime.dwHighDateTime << 32) | (uint)filetime.dwLowDateTime;
        var dateTime = DateTime.FromFileTimeUtc((long)ticks);
        return (ulong)(dateTime.ToFileTimeUtc() / 10000);
    }
}
