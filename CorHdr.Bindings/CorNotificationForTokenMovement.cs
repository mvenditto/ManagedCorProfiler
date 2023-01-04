namespace CorProf.Bindings
{
    public enum CorNotificationForTokenMovement
    {
        MDNotifyDefault = 0x0000000f,
        MDNotifyAll = unchecked((int)(0xffffffff)),
        MDNotifyNone = 0x00000000,
        MDNotifyMethodDef = 0x00000001,
        MDNotifyMemberRef = 0x00000002,
        MDNotifyFieldDef = 0x00000004,
        MDNotifyTypeRef = 0x00000008,
        MDNotifyTypeDef = 0x00000010,
        MDNotifyParamDef = 0x00000020,
        MDNotifyInterfaceImpl = 0x00000040,
        MDNotifyProperty = 0x00000080,
        MDNotifyEvent = 0x00000100,
        MDNotifySignature = 0x00000200,
        MDNotifyTypeSpec = 0x00000400,
        MDNotifyCustomAttribute = 0x00000800,
        MDNotifySecurityValue = 0x00001000,
        MDNotifyPermission = 0x00002000,
        MDNotifyModuleRef = 0x00004000,
        MDNotifyNameSpace = 0x00008000,
        MDNotifyAssemblyRef = 0x01000000,
        MDNotifyFile = 0x02000000,
        MDNotifyExportedType = 0x04000000,
        MDNotifyResource = 0x08000000,
    }
}
