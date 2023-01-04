namespace CorProf.Bindings
{
    public partial struct OSINFO
    {
        [NativeTypeName("DWORD")]
        public uint dwOSPlatformId;

        [NativeTypeName("DWORD")]
        public uint dwOSMajorVersion;

        [NativeTypeName("DWORD")]
        public uint dwOSMinorVersion;
    }
}
