namespace CorProf.Bindings
{
    public enum CorCheckDuplicatesFor
    {
        MDDupAll = unchecked((int)(0xffffffff)),
        MDDupENC = MDDupAll,
        MDNoDupChecks = 0x00000000,
        MDDupTypeDef = 0x00000001,
        MDDupInterfaceImpl = 0x00000002,
        MDDupMethodDef = 0x00000004,
        MDDupTypeRef = 0x00000008,
        MDDupMemberRef = 0x00000010,
        MDDupCustomAttribute = 0x00000020,
        MDDupParamDef = 0x00000040,
        MDDupPermission = 0x00000080,
        MDDupProperty = 0x00000100,
        MDDupEvent = 0x00000200,
        MDDupFieldDef = 0x00000400,
        MDDupSignature = 0x00000800,
        MDDupModuleRef = 0x00001000,
        MDDupTypeSpec = 0x00002000,
        MDDupImplMap = 0x00004000,
        MDDupAssemblyRef = 0x00008000,
        MDDupFile = 0x00010000,
        MDDupExportedType = 0x00020000,
        MDDupManifestResource = 0x00040000,
        MDDupGenericParam = 0x00080000,
        MDDupMethodSpec = 0x00100000,
        MDDupGenericParamConstraint = 0x00200000,
        MDDupAssembly = 0x10000000,
        MDDupDefault = MDNoDupChecks | MDDupTypeRef | MDDupMemberRef | MDDupSignature | MDDupTypeSpec | MDDupMethodSpec,
    }
}
