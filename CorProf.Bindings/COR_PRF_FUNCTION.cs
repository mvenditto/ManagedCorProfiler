namespace CorProf.Bindings
{
    public partial struct COR_PRF_FUNCTION
    {
        [NativeTypeName("FunctionID")]
        public ulong functionId;

        [NativeTypeName("ReJITID")]
        public ulong reJitId;
    }
}
