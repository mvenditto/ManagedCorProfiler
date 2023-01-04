namespace CorProf.Bindings
{
    public partial struct COR_PRF_METHOD
    {
        [NativeTypeName("ModuleID")]
        public ulong moduleId;

        [NativeTypeName("mdMethodDef")]
        public uint methodId;
    }
}
