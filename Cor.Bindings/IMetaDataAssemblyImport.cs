using System;
using System.Runtime.CompilerServices;

namespace CorProf.Bindings
{
    [NativeTypeName("struct IMetaDataAssemblyImport : IUnknown")]
    public unsafe partial struct IMetaDataAssemblyImport
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, Guid*, void**, int>)(lpVtbl[0]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, uint>)(lpVtbl[1]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, uint>)(lpVtbl[2]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int GetAssemblyProps([NativeTypeName("mdAssembly")] uint mda, [NativeTypeName("const void **")] void** ppbPublicKey, [NativeTypeName("ULONG *")] uint* pcbPublicKey, [NativeTypeName("ULONG *")] uint* pulHashAlgId, [NativeTypeName("LPWSTR")] ushort* szName, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pchName, ASSEMBLYMETADATA* pMetaData, [NativeTypeName("DWORD *")] uint* pdwAssemblyFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, uint, void**, uint*, uint*, ushort*, uint, uint*, ASSEMBLYMETADATA*, uint*, int>)(lpVtbl[3]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this), mda, ppbPublicKey, pcbPublicKey, pulHashAlgId, szName, cchName, pchName, pMetaData, pdwAssemblyFlags);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int GetAssemblyRefProps([NativeTypeName("mdAssemblyRef")] uint mdar, [NativeTypeName("const void **")] void** ppbPublicKeyOrToken, [NativeTypeName("ULONG *")] uint* pcbPublicKeyOrToken, [NativeTypeName("LPWSTR")] ushort* szName, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pchName, ASSEMBLYMETADATA* pMetaData, [NativeTypeName("const void **")] void** ppbHashValue, [NativeTypeName("ULONG *")] uint* pcbHashValue, [NativeTypeName("DWORD *")] uint* pdwAssemblyRefFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, uint, void**, uint*, ushort*, uint, uint*, ASSEMBLYMETADATA*, void**, uint*, uint*, int>)(lpVtbl[4]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this), mdar, ppbPublicKeyOrToken, pcbPublicKeyOrToken, szName, cchName, pchName, pMetaData, ppbHashValue, pcbHashValue, pdwAssemblyRefFlags);
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int GetFileProps([NativeTypeName("mdFile")] uint mdf, [NativeTypeName("LPWSTR")] ushort* szName, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pchName, [NativeTypeName("const void **")] void** ppbHashValue, [NativeTypeName("ULONG *")] uint* pcbHashValue, [NativeTypeName("DWORD *")] uint* pdwFileFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, uint, ushort*, uint, uint*, void**, uint*, uint*, int>)(lpVtbl[5]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this), mdf, szName, cchName, pchName, ppbHashValue, pcbHashValue, pdwFileFlags);
        }

        [VtblIndex(6)]
        [return: NativeTypeName("HRESULT")]
        public int GetExportedTypeProps([NativeTypeName("mdExportedType")] uint mdct, [NativeTypeName("LPWSTR")] ushort* szName, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pchName, [NativeTypeName("mdToken *")] uint* ptkImplementation, [NativeTypeName("mdTypeDef *")] uint* ptkTypeDef, [NativeTypeName("DWORD *")] uint* pdwExportedTypeFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, uint, ushort*, uint, uint*, uint*, uint*, uint*, int>)(lpVtbl[6]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this), mdct, szName, cchName, pchName, ptkImplementation, ptkTypeDef, pdwExportedTypeFlags);
        }

        [VtblIndex(7)]
        [return: NativeTypeName("HRESULT")]
        public int GetManifestResourceProps([NativeTypeName("mdManifestResource")] uint mdmr, [NativeTypeName("LPWSTR")] ushort* szName, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pchName, [NativeTypeName("mdToken *")] uint* ptkImplementation, [NativeTypeName("DWORD *")] uint* pdwOffset, [NativeTypeName("DWORD *")] uint* pdwResourceFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, uint, ushort*, uint, uint*, uint*, uint*, uint*, int>)(lpVtbl[7]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this), mdmr, szName, cchName, pchName, ptkImplementation, pdwOffset, pdwResourceFlags);
        }

        [VtblIndex(8)]
        [return: NativeTypeName("HRESULT")]
        public int EnumAssemblyRefs([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdAssemblyRef[]")] uint* rAssemblyRefs, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTokens)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, void**, uint*, uint, uint*, int>)(lpVtbl[8]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this), phEnum, rAssemblyRefs, cMax, pcTokens);
        }

        [VtblIndex(9)]
        [return: NativeTypeName("HRESULT")]
        public int EnumFiles([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdFile[]")] uint* rFiles, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTokens)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, void**, uint*, uint, uint*, int>)(lpVtbl[9]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this), phEnum, rFiles, cMax, pcTokens);
        }

        [VtblIndex(10)]
        [return: NativeTypeName("HRESULT")]
        public int EnumExportedTypes([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdExportedType[]")] uint* rExportedTypes, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTokens)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, void**, uint*, uint, uint*, int>)(lpVtbl[10]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this), phEnum, rExportedTypes, cMax, pcTokens);
        }

        [VtblIndex(11)]
        [return: NativeTypeName("HRESULT")]
        public int EnumManifestResources([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdManifestResource[]")] uint* rManifestResources, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTokens)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, void**, uint*, uint, uint*, int>)(lpVtbl[11]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this), phEnum, rManifestResources, cMax, pcTokens);
        }

        [VtblIndex(12)]
        [return: NativeTypeName("HRESULT")]
        public int GetAssemblyFromScope([NativeTypeName("mdAssembly *")] uint* ptkAssembly)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, uint*, int>)(lpVtbl[12]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this), ptkAssembly);
        }

        [VtblIndex(13)]
        [return: NativeTypeName("HRESULT")]
        public int FindExportedTypeByName([NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("mdToken")] uint mdtExportedType, [NativeTypeName("mdExportedType *")] uint* ptkExportedType)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, ushort*, uint, uint*, int>)(lpVtbl[13]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this), szName, mdtExportedType, ptkExportedType);
        }

        [VtblIndex(14)]
        [return: NativeTypeName("HRESULT")]
        public int FindManifestResourceByName([NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("mdManifestResource *")] uint* ptkManifestResource)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, ushort*, uint*, int>)(lpVtbl[14]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this), szName, ptkManifestResource);
        }

        [VtblIndex(15)]
        public void CloseEnum([NativeTypeName("HCORENUM")] void* hEnum)
        {
            ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, void*, void>)(lpVtbl[15]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this), hEnum);
        }

        [VtblIndex(16)]
        [return: NativeTypeName("HRESULT")]
        public int FindAssembliesByName([NativeTypeName("LPCWSTR")] ushort* szAppBase, [NativeTypeName("LPCWSTR")] ushort* szPrivateBin, [NativeTypeName("LPCWSTR")] ushort* szAssemblyName, [NativeTypeName("IUnknown *[]")] IUnknown** ppIUnk, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcAssemblies)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataAssemblyImport*, ushort*, ushort*, ushort*, IUnknown**, uint, uint*, int>)(lpVtbl[16]))((IMetaDataAssemblyImport*)Unsafe.AsPointer(ref this), szAppBase, szPrivateBin, szAssemblyName, ppIUnk, cMax, pcAssemblies);
        }
    }
}
