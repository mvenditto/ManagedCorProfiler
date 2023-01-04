namespace CorProf.Bindings
{
    public struct COR_FIELD_OFFSET
    {
        [NativeTypeName("mdFieldDef")]
        public uint ridOfField;

        [NativeTypeName("uint32_t")]
        public uint ulOffset;
    }
}
