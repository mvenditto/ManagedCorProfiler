namespace ManagedCorProfiler.Utilities
{
    public static class Guids
    {
        public readonly static Guid IID_IUnknown = Guid.Parse("00000000-0000-0000-C000-000000000046");
        public readonly static Guid IID_IClassFactory = Guid.Parse("00000001-0000-0000-C000-000000000046");

        public readonly static Guid IID_ICorProfilerCallback = Guid.Parse("176fbed1-a55c-4796-98ca-a9da0ef883e7");
        public readonly static Guid IID_ICorProfilerCallback2 = Guid.Parse("8a8cc829-ccf2-49fe-bbae-0f022228071a");

        public readonly static Guid IID_ICorProfilerInfo = Guid.Parse("28b5557d-3f3f-48b4-90b2-5f9eea2f6c48");
        public readonly static Guid IID_ICorProfilerInfo2 = Guid.Parse("cc0935cd-a518-487d-b0bb-a93214e65478");
    }
}