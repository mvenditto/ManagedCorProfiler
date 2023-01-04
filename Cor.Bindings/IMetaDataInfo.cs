using System;
using System.Runtime.CompilerServices;

namespace CorProf.Bindings
{
    [NativeTypeName("struct IMetaDataInfo : IUnknown")]
    public unsafe partial struct IMetaDataInfo
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataInfo*, Guid*, void**, int>)(lpVtbl[0]))((IMetaDataInfo*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataInfo*, uint>)(lpVtbl[1]))((IMetaDataInfo*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataInfo*, uint>)(lpVtbl[2]))((IMetaDataInfo*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int GetFileMapping([NativeTypeName("const void **")] void** ppvData, [NativeTypeName("ULONGLONG *")] ulong* pcbData, [NativeTypeName("DWORD *")] uint* pdwMappingType)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataInfo*, void**, ulong*, uint*, int>)(lpVtbl[3]))((IMetaDataInfo*)Unsafe.AsPointer(ref this), ppvData, pcbData, pdwMappingType);
        }
    }
}
