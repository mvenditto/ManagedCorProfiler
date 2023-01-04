namespace CorProf.Bindings
{
    public enum CorFieldAttr
    {
        fdFieldAccessMask = 0x0007,
        fdPrivateScope = 0x0000,
        fdPrivate = 0x0001,
        fdFamANDAssem = 0x0002,
        fdAssembly = 0x0003,
        fdFamily = 0x0004,
        fdFamORAssem = 0x0005,
        fdPublic = 0x0006,
        fdStatic = 0x0010,
        fdInitOnly = 0x0020,
        fdLiteral = 0x0040,
        fdNotSerialized = 0x0080,
        fdSpecialName = 0x0200,
        fdPinvokeImpl = 0x2000,
        fdReservedMask = 0x9500,
        fdRTSpecialName = 0x0400,
        fdHasFieldMarshal = 0x1000,
        fdHasDefault = 0x8000,
        fdHasFieldRVA = 0x0100,
    }
}
