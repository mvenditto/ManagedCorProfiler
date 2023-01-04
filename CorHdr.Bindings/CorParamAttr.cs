namespace CorProf.Bindings
{
    public enum CorParamAttr
    {
        pdIn = 0x0001,
        pdOut = 0x0002,
        pdOptional = 0x0010,
        pdReservedMask = 0xf000,
        pdHasDefault = 0x1000,
        pdHasFieldMarshal = 0x2000,
        pdUnused = 0xcfe0,
    }
}
