namespace CorProf.Bindings
{
    public partial struct _IMAGE_DATA_DIRECTORY
    {
        [NativeTypeName("uint32_t")]
        public uint VirtualAddress;

        [NativeTypeName("uint32_t")]
        public uint Size;
    }
}
