namespace CorProf.Bindings
{
    [NativeTypeName("unsigned int")]
    public enum CorInfoHFAElemType : uint
    {
        CORINFO_HFA_ELEM_NONE,
        CORINFO_HFA_ELEM_FLOAT,
        CORINFO_HFA_ELEM_DOUBLE,
        CORINFO_HFA_ELEM_VECTOR64,
        CORINFO_HFA_ELEM_VECTOR128,
    }
}
