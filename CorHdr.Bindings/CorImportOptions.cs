namespace CorProf.Bindings
{
    public enum CorImportOptions
    {
        MDImportOptionDefault = 0x00000000,
        MDImportOptionAll = unchecked((int)(0xFFFFFFFF)),
        MDImportOptionAllTypeDefs = 0x00000001,
        MDImportOptionAllMethodDefs = 0x00000002,
        MDImportOptionAllFieldDefs = 0x00000004,
        MDImportOptionAllProperties = 0x00000008,
        MDImportOptionAllEvents = 0x00000010,
        MDImportOptionAllCustomAttributes = 0x00000020,
        MDImportOptionAllExportedTypes = 0x00000040,
    }
}
