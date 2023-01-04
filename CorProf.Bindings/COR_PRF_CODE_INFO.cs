namespace CorProf.Bindings
{
    public partial struct COR_PRF_CODE_INFO
    {
        [NativeTypeName("UINT_PTR")]
        public ulong startAddress;

        [NativeTypeName("SIZE_T")]
        public ulong size;
    }
}
