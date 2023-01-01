namespace ManagedCorProfiler.Utilities
{
    public enum COR_PRF_JIT_CACHE
    {
        COR_PRF_CACHED_FUNCTION_FOUND = 0,
        COR_PRF_CACHED_FUNCTION_NOT_FOUND = (COR_PRF_CACHED_FUNCTION_FOUND + 1)
    }

    public enum COR_PRF_TRANSITION_REASON
    {
        COR_PRF_TRANSITION_CALL = 0,
        COR_PRF_TRANSITION_RETURN = 1
    }

    public enum COR_PRF_SUSPEND_REASON
    {
        COR_PRF_SUSPEND_OTHER = 0x00,
        COR_PRF_SUSPEND_FOR_GC = 0x01,
        COR_PRF_SUSPEND_FOR_APPDOMAIN_SHUTDOWN = 0x02,
        COR_PRF_SUSPEND_FOR_CODE_PITCHING = 0x03,
        COR_PRF_SUSPEND_FOR_SHUTDOWN = 0x04,
        COR_PRF_SUSPEND_FOR_INPROC_DEBUGGER = 0x06,
        COR_PRF_SUSPEND_FOR_GC_PREP = 0x07, COR_PRF_SUSPEND_FOR_REJIT = 8
    }

    public enum COR_PRF_GC_REASON
    {
        COR_PRF_GC_GEN_0 = 0,
        COR_PRF_GC_GEN_1 = 1,
        COR_PRF_GC_GEN_2 = 2,
        COR_PRF_GC_LARGE_OBJECT_HEAP = 3,
        COR_PRF_GC_PINNED_OBJECT_HEAP = 4
    }

    public enum COR_PRF_GC_ROOT_KIND
    {
        COR_PRF_GC_ROOT_STACK = 1,
        COR_PRF_GC_ROOT_FINALIZER = 2,
        COR_PRF_GC_ROOT_HANDLE = 3,
        COR_PRF_GC_ROOT_OTHER = 0
    }

    public enum COR_PRF_GC_ROOT_FLAGS
    {
        COR_PRF_GC_ROOT_PINNING = 0x1,
        COR_PRF_GC_ROOT_WEAKREF = 0x2,
        COR_PRF_GC_ROOT_INTERIOR = 0x4,
        COR_PRF_GC_ROOT_REFCOUNTED = 0x8
    }

    public enum COR_PRF_MONITOR : uint
    {
        COR_PRF_MONITOR_NONE = 0x00000000,
        COR_PRF_MONITOR_FUNCTION_UNLOADS = 0x00000001,
        COR_PRF_MONITOR_CLASS_LOADS = 0x00000002,
        COR_PRF_MONITOR_MODULE_LOADS = 0x00000004,
        COR_PRF_MONITOR_ASSEMBLY_LOADS = 0x00000008,
        COR_PRF_MONITOR_APPDOMAIN_LOADS = 0x00000010,
        COR_PRF_MONITOR_JIT_COMPILATION = 0x00000020,
        COR_PRF_MONITOR_EXCEPTIONS = 0x00000040,
        COR_PRF_MONITOR_GC = 0x00000080,
        COR_PRF_MONITOR_OBJECT_ALLOCATED = 0x00000100,
        COR_PRF_MONITOR_THREADS = 0x00000200,
        COR_PRF_MONITOR_REMOTING = 0x00000400,
        COR_PRF_MONITOR_CODE_TRANSITIONS = 0x00000800,
        COR_PRF_MONITOR_ENTERLEAVE = 0x00001000,
        COR_PRF_MONITOR_CCW = 0x00002000,
        COR_PRF_MONITOR_REMOTING_COOKIE = 0x00004000 | COR_PRF_MONITOR_REMOTING,
        COR_PRF_MONITOR_REMOTING_ASYNC = 0x00008000 | COR_PRF_MONITOR_REMOTING,
        COR_PRF_MONITOR_SUSPENDS = 0x00010000,
        COR_PRF_MONITOR_CACHE_SEARCHES = 0x00020000,
        COR_PRF_ENABLE_REJIT = 0x00040000,
        COR_PRF_ENABLE_INPROC_DEBUGGING = 0x00080000,
        COR_PRF_ENABLE_JIT_MAPS = 0x00100000,
        COR_PRF_DISABLE_INLINING = 0x00200000,
        COR_PRF_DISABLE_OPTIMIZATIONS = 0x00400000,
        COR_PRF_ENABLE_OBJECT_ALLOCATED = 0x00800000,
        COR_PRF_MONITOR_CLR_EXCEPTIONS = 0x01000000,
        COR_PRF_MONITOR_ALL = 0x0107FFFF,
        COR_PRF_ENABLE_FUNCTION_ARGS = 0X02000000,
        COR_PRF_ENABLE_FUNCTION_RETVAL = 0X04000000,
        COR_PRF_ENABLE_FRAME_INFO = 0X08000000,
        COR_PRF_ENABLE_STACK_SNAPSHOT = 0X10000000,
        COR_PRF_USE_PROFILE_IMAGES = 0x20000000,
        COR_PRF_DISABLE_TRANSPARENCY_CHECKS_UNDER_FULL_TRUST = 0x40000000,
        COR_PRF_DISABLE_ALL_NGEN_IMAGES = 0x80000000,
        COR_PRF_ALL = 0x8FFFFFFF,
        COR_PRF_REQUIRE_PROFILE_IMAGE = COR_PRF_USE_PROFILE_IMAGES |
                                                COR_PRF_MONITOR_CODE_TRANSITIONS |
                                                COR_PRF_MONITOR_ENTERLEAVE,
        COR_PRF_ALLOWABLE_AFTER_ATTACH = COR_PRF_MONITOR_THREADS |
                                                COR_PRF_MONITOR_MODULE_LOADS |
                                                COR_PRF_MONITOR_ASSEMBLY_LOADS |
                                                COR_PRF_MONITOR_APPDOMAIN_LOADS |
                                                COR_PRF_ENABLE_STACK_SNAPSHOT |
                                                COR_PRF_MONITOR_GC |
                                                COR_PRF_MONITOR_SUSPENDS |
                                                COR_PRF_MONITOR_CLASS_LOADS |
                                                COR_PRF_MONITOR_JIT_COMPILATION,
        COR_PRF_MONITOR_IMMUTABLE = COR_PRF_MONITOR_CODE_TRANSITIONS |
                                                COR_PRF_MONITOR_REMOTING |
                                                COR_PRF_MONITOR_REMOTING_COOKIE |
                                                COR_PRF_MONITOR_REMOTING_ASYNC |
                                                COR_PRF_ENABLE_REJIT |
                                                COR_PRF_ENABLE_INPROC_DEBUGGING |
                                                COR_PRF_ENABLE_JIT_MAPS |
                                                COR_PRF_DISABLE_OPTIMIZATIONS |
                                                COR_PRF_DISABLE_INLINING |
                                                COR_PRF_ENABLE_OBJECT_ALLOCATED |
                                                COR_PRF_ENABLE_FUNCTION_ARGS |
                                                COR_PRF_ENABLE_FUNCTION_RETVAL |
                                                COR_PRF_ENABLE_FRAME_INFO |
                                                COR_PRF_USE_PROFILE_IMAGES |
                            COR_PRF_DISABLE_TRANSPARENCY_CHECKS_UNDER_FULL_TRUST |
                                                COR_PRF_DISABLE_ALL_NGEN_IMAGES
    };
}