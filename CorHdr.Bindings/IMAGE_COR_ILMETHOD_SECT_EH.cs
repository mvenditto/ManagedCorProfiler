using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    [StructLayout(LayoutKind.Explicit)]
    public partial struct IMAGE_COR_ILMETHOD_SECT_EH
    {
        [FieldOffset(0)]
        public IMAGE_COR_ILMETHOD_SECT_EH_SMALL Small;

        [FieldOffset(0)]
        public IMAGE_COR_ILMETHOD_SECT_EH_FAT Fat;
    }
}
