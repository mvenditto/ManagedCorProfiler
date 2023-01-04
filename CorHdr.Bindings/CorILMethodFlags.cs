namespace CorProf.Bindings
{
    public enum CorILMethodFlags
    {
        CorILMethod_InitLocals = 0x0010,
        CorILMethod_MoreSects = 0x0008,
        CorILMethod_CompressedIL = 0x0040,
        CorILMethod_FormatShift = 3,
        CorILMethod_FormatMask = ((1 << CorILMethod_FormatShift) - 1),
        CorILMethod_TinyFormat = 0x0002,
        CorILMethod_SmallFormat = 0x0000,
        CorILMethod_FatFormat = 0x0003,
        CorILMethod_TinyFormat1 = 0x0006,
    }
}
