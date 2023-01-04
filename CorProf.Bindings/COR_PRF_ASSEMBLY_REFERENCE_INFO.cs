namespace CorProf.Bindings
{
    public unsafe partial struct COR_PRF_ASSEMBLY_REFERENCE_INFO
    {
        public void* pbPublicKeyOrToken;

        [NativeTypeName("ULONG")]
        public uint cbPublicKeyOrToken;

        [NativeTypeName("LPCWSTR")]
        public ushort* szName;

        public ASSEMBLYMETADATA* pMetaData;

        public void* pbHashValue;

        [NativeTypeName("ULONG")]
        public uint cbHashValue;

        [NativeTypeName("DWORD")]
        public uint dwAssemblyRefFlags;
    }
}
