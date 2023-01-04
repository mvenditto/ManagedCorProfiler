namespace CorProf.Bindings
{
    public unsafe partial struct COR_PRF_EVENTPIPE_PROVIDER_CONFIG
    {
        [NativeTypeName("const WCHAR *")]
        public ushort* providerName;

        [NativeTypeName("UINT64")]
        public ulong keywords;

        [NativeTypeName("UINT32")]
        public uint loggingLevel;

        [NativeTypeName("const WCHAR *")]
        public ushort* filterData;
    }
}
