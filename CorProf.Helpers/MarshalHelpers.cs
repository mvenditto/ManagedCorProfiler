using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CorProf.Helpers
{
    public static unsafe class MarshalHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string? PtrToStringUtf16(ushort* buff)
        {
            return Marshal.PtrToStringUni((nint)buff);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort* StringToPtrUtf16(string? str)
        {
            return (ushort*) Marshal.StringToCoTaskMemUni(str);
        }
    }
}
