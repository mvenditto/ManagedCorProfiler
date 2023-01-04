namespace CorProf.Bindings
{
    public enum COR_PRF_STATIC_TYPE
    {
        COR_PRF_FIELD_NOT_A_STATIC = 0,
        COR_PRF_FIELD_APP_DOMAIN_STATIC = 0x1,
        COR_PRF_FIELD_THREAD_STATIC = 0x2,
        COR_PRF_FIELD_CONTEXT_STATIC = 0x4,
        COR_PRF_FIELD_RVA_STATIC = 0x8,
    }
}
