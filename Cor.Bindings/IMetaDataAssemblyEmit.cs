using System;
using System.Runtime.CompilerServices;

namespace CorProf.Bindings
{
    [NativeTypeName("struct IMetaDataAssemblyEmit : IUnknown")]
    public unsafe partial struct IMetaDataAssemblyEmit
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyEmit*, Guid*, void**, int>)(lpVtbl[0]))((IMetaDataAssemblyEmit*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyEmit*, uint>)(lpVtbl[1]))((IMetaDataAssemblyEmit*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyEmit*, uint>)(lpVtbl[2]))((IMetaDataAssemblyEmit*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int DefineAssembly([NativeTypeName("const void *")] void* pbPublicKey, [NativeTypeName("ULONG")] uint cbPublicKey, [NativeTypeName("ULONG")] uint ulHashAlgId, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("const ASSEMBLYMETADATA *")] ASSEMBLYMETADATA* pMetaData, [NativeTypeName("DWORD")] uint dwAssemblyFlags, [NativeTypeName("mdAssembly *")] uint* pma)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyEmit*, void*, uint, uint, ushort*, ASSEMBLYMETADATA*, uint, uint*, int>)(lpVtbl[3]))((IMetaDataAssemblyEmit*)Unsafe.AsPointer(ref this), pbPublicKey, cbPublicKey, ulHashAlgId, szName, pMetaData, dwAssemblyFlags, pma);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int DefineAssemblyRef([NativeTypeName("const void *")] void* pbPublicKeyOrToken, [NativeTypeName("ULONG")] uint cbPublicKeyOrToken, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("const ASSEMBLYMETADATA *")] ASSEMBLYMETADATA* pMetaData, [NativeTypeName("const void *")] void* pbHashValue, [NativeTypeName("ULONG")] uint cbHashValue, [NativeTypeName("DWORD")] uint dwAssemblyRefFlags, [NativeTypeName("mdAssemblyRef *")] uint* pmdar)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyEmit*, void*, uint, ushort*, ASSEMBLYMETADATA*, void*, uint, uint, uint*, int>)(lpVtbl[4]))((IMetaDataAssemblyEmit*)Unsafe.AsPointer(ref this), pbPublicKeyOrToken, cbPublicKeyOrToken, szName, pMetaData, pbHashValue, cbHashValue, dwAssemblyRefFlags, pmdar);
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int DefineFile([NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("const void *")] void* pbHashValue, [NativeTypeName("ULONG")] uint cbHashValue, [NativeTypeName("DWORD")] uint dwFileFlags, [NativeTypeName("mdFile *")] uint* pmdf)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyEmit*, ushort*, void*, uint, uint, uint*, int>)(lpVtbl[5]))((IMetaDataAssemblyEmit*)Unsafe.AsPointer(ref this), szName, pbHashValue, cbHashValue, dwFileFlags, pmdf);
        }

        [VtblIndex(6)]
        [return: NativeTypeName("HRESULT")]
        public int DefineExportedType([NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("mdToken")] uint tkImplementation, [NativeTypeName("mdTypeDef")] uint tkTypeDef, [NativeTypeName("DWORD")] uint dwExportedTypeFlags, [NativeTypeName("mdExportedType *")] uint* pmdct)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyEmit*, ushort*, uint, uint, uint, uint*, int>)(lpVtbl[6]))((IMetaDataAssemblyEmit*)Unsafe.AsPointer(ref this), szName, tkImplementation, tkTypeDef, dwExportedTypeFlags, pmdct);
        }

        [VtblIndex(7)]
        [return: NativeTypeName("HRESULT")]
        public int DefineManifestResource([NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("mdToken")] uint tkImplementation, [NativeTypeName("DWORD")] uint dwOffset, [NativeTypeName("DWORD")] uint dwResourceFlags, [NativeTypeName("mdManifestResource *")] uint* pmdmr)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyEmit*, ushort*, uint, uint, uint, uint*, int>)(lpVtbl[7]))((IMetaDataAssemblyEmit*)Unsafe.AsPointer(ref this), szName, tkImplementation, dwOffset, dwResourceFlags, pmdmr);
        }

        [VtblIndex(8)]
        [return: NativeTypeName("HRESULT")]
        public int SetAssemblyProps([NativeTypeName("mdAssembly")] uint pma, [NativeTypeName("const void *")] void* pbPublicKey, [NativeTypeName("ULONG")] uint cbPublicKey, [NativeTypeName("ULONG")] uint ulHashAlgId, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("const ASSEMBLYMETADATA *")] ASSEMBLYMETADATA* pMetaData, [NativeTypeName("DWORD")] uint dwAssemblyFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyEmit*, uint, void*, uint, uint, ushort*, ASSEMBLYMETADATA*, uint, int>)(lpVtbl[8]))((IMetaDataAssemblyEmit*)Unsafe.AsPointer(ref this), pma, pbPublicKey, cbPublicKey, ulHashAlgId, szName, pMetaData, dwAssemblyFlags);
        }

        [VtblIndex(9)]
        [return: NativeTypeName("HRESULT")]
        public int SetAssemblyRefProps([NativeTypeName("mdAssemblyRef")] uint ar, [NativeTypeName("const void *")] void* pbPublicKeyOrToken, [NativeTypeName("ULONG")] uint cbPublicKeyOrToken, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("const ASSEMBLYMETADATA *")] ASSEMBLYMETADATA* pMetaData, [NativeTypeName("const void *")] void* pbHashValue, [NativeTypeName("ULONG")] uint cbHashValue, [NativeTypeName("DWORD")] uint dwAssemblyRefFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyEmit*, uint, void*, uint, ushort*, ASSEMBLYMETADATA*, void*, uint, uint, int>)(lpVtbl[9]))((IMetaDataAssemblyEmit*)Unsafe.AsPointer(ref this), ar, pbPublicKeyOrToken, cbPublicKeyOrToken, szName, pMetaData, pbHashValue, cbHashValue, dwAssemblyRefFlags);
        }

        [VtblIndex(10)]
        [return: NativeTypeName("HRESULT")]
        public int SetFileProps([NativeTypeName("mdFile")] uint file, [NativeTypeName("const void *")] void* pbHashValue, [NativeTypeName("ULONG")] uint cbHashValue, [NativeTypeName("DWORD")] uint dwFileFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyEmit*, uint, void*, uint, uint, int>)(lpVtbl[10]))((IMetaDataAssemblyEmit*)Unsafe.AsPointer(ref this), file, pbHashValue, cbHashValue, dwFileFlags);
        }

        [VtblIndex(11)]
        [return: NativeTypeName("HRESULT")]
        public int SetExportedTypeProps([NativeTypeName("mdExportedType")] uint ct, [NativeTypeName("mdToken")] uint tkImplementation, [NativeTypeName("mdTypeDef")] uint tkTypeDef, [NativeTypeName("DWORD")] uint dwExportedTypeFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyEmit*, uint, uint, uint, uint, int>)(lpVtbl[11]))((IMetaDataAssemblyEmit*)Unsafe.AsPointer(ref this), ct, tkImplementation, tkTypeDef, dwExportedTypeFlags);
        }

        [VtblIndex(12)]
        [return: NativeTypeName("HRESULT")]
        public int SetManifestResourceProps([NativeTypeName("mdManifestResource")] uint mr, [NativeTypeName("mdToken")] uint tkImplementation, [NativeTypeName("DWORD")] uint dwOffset, [NativeTypeName("DWORD")] uint dwResourceFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyEmit*, uint, uint, uint, uint, int>)(lpVtbl[12]))((IMetaDataAssemblyEmit*)Unsafe.AsPointer(ref this), mr, tkImplementation, dwOffset, dwResourceFlags);
        }
    }
}
