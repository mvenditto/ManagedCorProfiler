namespace CorProf.Bindings
{
    public enum CorOpenFlags
    {
        ofRead = 0x00000000,
        ofWrite = 0x00000001,
        ofReadWriteMask = 0x00000001,
        ofCopyMemory = 0x00000002,
        ofReadOnly = 0x00000010,
        ofTakeOwnership = 0x00000020,
        ofNoTypeLib = 0x00000080,
        ofNoTransform = 0x00001000,
        ofReserved1 = 0x00000100,
        ofReserved2 = 0x00000200,
        ofReserved3 = 0x00000400,
        ofReserved = unchecked((int)(0xffffef40)),
    }
}
