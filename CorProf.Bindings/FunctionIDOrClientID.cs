using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    [StructLayout(LayoutKind.Explicit)]
    public partial struct FunctionIDOrClientID
    {
        [FieldOffset(0)]
        [NativeTypeName("FunctionID")]
        public ulong functionID;

        [FieldOffset(0)]
        [NativeTypeName("UINT_PTR")]
        public ulong clientID;
    }
}
