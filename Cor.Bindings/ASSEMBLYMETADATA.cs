namespace CorProf.Bindings
{
    public unsafe partial struct ASSEMBLYMETADATA
    {
        public ushort usMajorVersion;

        public ushort usMinorVersion;

        public ushort usBuildNumber;

        public ushort usRevisionNumber;

        [NativeTypeName("LPWSTR")]
        public ushort* szLocale;

        [NativeTypeName("ULONG")]
        public uint cbLocale;

        [NativeTypeName("DWORD *")]
        public uint* rProcessor;

        [NativeTypeName("ULONG")]
        public uint ulProcessor;

        public OSINFO* rOS;

        [NativeTypeName("ULONG")]
        public uint ulOS;
    }
}
