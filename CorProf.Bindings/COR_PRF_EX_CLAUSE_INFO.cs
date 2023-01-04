namespace CorProf.Bindings
{
    public partial struct COR_PRF_EX_CLAUSE_INFO
    {
        public COR_PRF_CLAUSE_TYPE clauseType;

        [NativeTypeName("UINT_PTR")]
        public ulong programCounter;

        [NativeTypeName("UINT_PTR")]
        public ulong framePointer;

        [NativeTypeName("UINT_PTR")]
        public ulong shadowStackPointer;
    }
}
