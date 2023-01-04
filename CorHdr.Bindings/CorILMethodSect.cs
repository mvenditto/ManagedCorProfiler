namespace CorProf.Bindings
{
    public enum CorILMethodSect
    {
        CorILMethod_Sect_Reserved = 0,
        CorILMethod_Sect_EHTable = 1,
        CorILMethod_Sect_OptILTable = 2,
        CorILMethod_Sect_KindMask = 0x3F,
        CorILMethod_Sect_FatFormat = 0x40,
        CorILMethod_Sect_MoreSects = 0x80,
    }
}
