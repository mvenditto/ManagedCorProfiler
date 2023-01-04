namespace CorProf.Bindings
{
    public partial struct COR_IL_MAP
    {
        [NativeTypeName("ULONG32")]
        public uint oldOffset;

        [NativeTypeName("ULONG32")]
        public uint newOffset;

        [NativeTypeName("BOOL")]
        public int fAccurate;
    }
}
