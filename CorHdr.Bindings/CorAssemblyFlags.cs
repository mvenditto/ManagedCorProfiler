namespace CorProf.Bindings
{
    public enum CorAssemblyFlags
    {
        afPublicKey = 0x0001,
        afPA_None = 0x0000,
        afPA_MSIL = 0x0010,
        afPA_x86 = 0x0020,
        afPA_IA64 = 0x0030,
        afPA_AMD64 = 0x0040,
        afPA_ARM = 0x0050,
        afPA_ARM64 = 0x0060,
        afPA_NoPlatform = 0x0070,
        afPA_Specified = 0x0080,
        afPA_Mask = 0x0070,
        afPA_FullMask = 0x00F0,
        afPA_Shift = 0x0004,
        afEnableJITcompileTracking = 0x8000,
        afDisableJITcompileOptimizer = 0x4000,
        afDebuggableAttributeMask = 0xc000,
        afRetargetable = 0x0100,
        afContentType_Default = 0x0000,
        afContentType_WindowsRuntime = 0x0200,
        afContentType_Mask = 0x0E00,
    }
}
