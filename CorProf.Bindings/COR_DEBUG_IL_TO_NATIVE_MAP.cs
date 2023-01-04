namespace CorProf.Bindings
{
    public partial struct COR_DEBUG_IL_TO_NATIVE_MAP
    {
        [NativeTypeName("ULONG32")]
        public uint ilOffset;

        [NativeTypeName("ULONG32")]
        public uint nativeStartOffset;

        [NativeTypeName("ULONG32")]
        public uint nativeEndOffset;
    }
}
