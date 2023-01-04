namespace CorProf.Bindings
{
    public partial struct COR_PRF_GC_GENERATION_RANGE
    {
        public COR_PRF_GC_GENERATION generation;

        [NativeTypeName("ObjectID")]
        public ulong rangeStart;

        [NativeTypeName("UINT_PTR")]
        public ulong rangeLength;

        [NativeTypeName("UINT_PTR")]
        public ulong rangeLengthReserved;
    }
}
