namespace CorProf.Bindings
{
    public unsafe partial struct COR_PRF_EVENTPIPE_PARAM_DESC
    {
        [NativeTypeName("UINT32")]
        public uint type;

        [NativeTypeName("UINT32")]
        public uint elementType;

        [NativeTypeName("const WCHAR *")]
        public ushort* name;
    }
}
