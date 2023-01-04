namespace CorProf.Bindings
{
    public enum CorAttributeTargets
    {
        catAssembly = 0x0001,
        catModule = 0x0002,
        catClass = 0x0004,
        catStruct = 0x0008,
        catEnum = 0x0010,
        catConstructor = 0x0020,
        catMethod = 0x0040,
        catProperty = 0x0080,
        catField = 0x0100,
        catEvent = 0x0200,
        catInterface = 0x0400,
        catParameter = 0x0800,
        catDelegate = 0x1000,
        catGenericParameter = 0x4000,
        catAll = catAssembly | catModule | catClass | catStruct | catEnum | catConstructor | catMethod | catProperty | catField | catEvent | catInterface | catParameter | catDelegate | catGenericParameter,
        catClassMembers = catClass | catStruct | catEnum | catConstructor | catMethod | catProperty | catField | catEvent | catDelegate | catInterface,
    }
}
