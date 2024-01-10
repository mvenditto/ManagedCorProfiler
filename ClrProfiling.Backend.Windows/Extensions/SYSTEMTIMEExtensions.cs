using System;

namespace Windows.Win32.Foundation;

internal static class SYSTEMTIMEExtensions
{
    private const ulong SecondsToMilliseconds = 1000;
    private const ulong MinutesToMilliseconds = 60 * SecondsToMilliseconds;
    private const ulong HoursToMilliseconds = 60 * MinutesToMilliseconds;
    private const ulong DaysToMilliseconds = 24 * HoursToMilliseconds;

    public static ulong ToMilliseconds(this SYSTEMTIME systemTime)
    {

        return systemTime.wMilliseconds
             + systemTime.wSecond * SecondsToMilliseconds
             + systemTime.wMinute * MinutesToMilliseconds
             + systemTime.wHour * HoursToMilliseconds
             + systemTime.wDay * DaysToMilliseconds;
    }
}
