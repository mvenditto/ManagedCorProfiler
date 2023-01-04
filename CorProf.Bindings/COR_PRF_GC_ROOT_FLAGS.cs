namespace CorProf.Bindings
{
    public enum COR_PRF_GC_ROOT_FLAGS
    {
        COR_PRF_GC_ROOT_PINNING = 0x1,
        COR_PRF_GC_ROOT_WEAKREF = 0x2,
        COR_PRF_GC_ROOT_INTERIOR = 0x4,
        COR_PRF_GC_ROOT_REFCOUNTED = 0x8,
    }
}
