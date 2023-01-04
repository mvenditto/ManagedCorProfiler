namespace CorProf.Bindings
{
    public partial struct IMAGE_COR_VTABLEFIXUP
    {
        [NativeTypeName("uint32_t")]
        public uint RVA;

        [NativeTypeName("uint16_t")]
        public ushort Count;

        [NativeTypeName("uint16_t")]
        public ushort Type;
    }
}
