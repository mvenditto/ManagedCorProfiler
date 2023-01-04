namespace CorProf.Bindings
{
    public partial struct COR_PRF_EVENT_DATA
    {
        [NativeTypeName("UINT64")]
        public ulong ptr;

        [NativeTypeName("UINT32")]
        public uint size;

        [NativeTypeName("UINT32")]
        public uint reserved;
    }
}
