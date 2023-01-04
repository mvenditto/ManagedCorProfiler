namespace CorProf.Bindings
{
    public enum CorMethodAttr
    {
        mdMemberAccessMask = 0x0007,
        mdPrivateScope = 0x0000,
        mdPrivate = 0x0001,
        mdFamANDAssem = 0x0002,
        mdAssem = 0x0003,
        mdFamily = 0x0004,
        mdFamORAssem = 0x0005,
        mdPublic = 0x0006,
        mdStatic = 0x0010,
        mdFinal = 0x0020,
        mdVirtual = 0x0040,
        mdHideBySig = 0x0080,
        mdVtableLayoutMask = 0x0100,
        mdReuseSlot = 0x0000,
        mdNewSlot = 0x0100,
        mdCheckAccessOnOverride = 0x0200,
        mdAbstract = 0x0400,
        mdSpecialName = 0x0800,
        mdPinvokeImpl = 0x2000,
        mdUnmanagedExport = 0x0008,
        mdReservedMask = 0xd000,
        mdRTSpecialName = 0x1000,
        mdHasSecurity = 0x4000,
        mdRequireSecObject = 0x8000,
    }
}
