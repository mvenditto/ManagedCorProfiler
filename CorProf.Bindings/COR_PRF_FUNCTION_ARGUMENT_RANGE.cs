namespace CorProf.Bindings
{
    public partial struct COR_PRF_FUNCTION_ARGUMENT_RANGE
    {
        [NativeTypeName("UINT_PTR")]
        public ulong startAddress;

        [NativeTypeName("ULONG")]
        public uint length;
    }
}
