namespace CorProf.Bindings
{
    public enum CorSetENC
    {
        MDSetENCOn = 0x00000001,
        MDSetENCOff = 0x00000002,
        MDUpdateENC = 0x00000001,
        MDUpdateFull = 0x00000002,
        MDUpdateExtension = 0x00000003,
        MDUpdateIncremental = 0x00000004,
        MDUpdateDelta = 0x00000005,
        MDUpdateMask = 0x00000007,
    }
}
