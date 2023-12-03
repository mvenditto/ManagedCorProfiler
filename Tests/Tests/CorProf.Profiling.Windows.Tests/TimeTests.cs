using Xunit;
using System.Runtime.InteropServices.ComTypes;
using Windows.Win32;
using Windows.Win32.Foundation;

namespace CorProf.Profiling.Windows.Tests;

public class TimeTests
{
    private readonly static DateTime WindowsEpoch = new(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private readonly static DateTime UnixEpoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void FILETIME_ToMilliseconds()
    {
        var dateTime = new DateTime(2023, 1, 2, 3, 4, 5, DateTimeKind.Utc);

        var expectedMilliseconds = (ulong)(dateTime - WindowsEpoch).TotalMilliseconds;

        Assert.True(PInvoke.SystemTimeToFileTime((SYSTEMTIME)dateTime, out var fileTime));

        Assert.Equal(expectedMilliseconds, fileTime.ToMilliseconds3());
    }
}
