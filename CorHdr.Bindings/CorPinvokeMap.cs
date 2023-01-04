namespace CorProf.Bindings
{
    public enum CorPinvokeMap
    {
        pmNoMangle = 0x0001,
        pmCharSetMask = 0x0006,
        pmCharSetNotSpec = 0x0000,
        pmCharSetAnsi = 0x0002,
        pmCharSetUnicode = 0x0004,
        pmCharSetAuto = 0x0006,
        pmBestFitUseAssem = 0x0000,
        pmBestFitEnabled = 0x0010,
        pmBestFitDisabled = 0x0020,
        pmBestFitMask = 0x0030,
        pmThrowOnUnmappableCharUseAssem = 0x0000,
        pmThrowOnUnmappableCharEnabled = 0x1000,
        pmThrowOnUnmappableCharDisabled = 0x2000,
        pmThrowOnUnmappableCharMask = 0x3000,
        pmSupportsLastError = 0x0040,
        pmCallConvMask = 0x0700,
        pmCallConvWinapi = 0x0100,
        pmCallConvCdecl = 0x0200,
        pmCallConvStdcall = 0x0300,
        pmCallConvThiscall = 0x0400,
        pmCallConvFastcall = 0x0500,
        pmMaxValue = 0xFFFF,
    }
}
