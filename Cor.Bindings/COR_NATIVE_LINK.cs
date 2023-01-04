using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct COR_NATIVE_LINK
    {
        public byte m_linkType;

        public byte m_flags;

        [NativeTypeName("mdMemberRef")]
        public uint m_entryPoint;
    }
}
