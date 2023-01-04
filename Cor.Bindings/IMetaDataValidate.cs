using System;
using System.Runtime.CompilerServices;

namespace CorProf.Bindings
{
    [NativeTypeName("struct IMetaDataValidate : IUnknown")]
    public unsafe partial struct IMetaDataValidate
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataValidate*, Guid*, void**, int>)(lpVtbl[0]))((IMetaDataValidate*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataValidate*, uint>)(lpVtbl[1]))((IMetaDataValidate*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataValidate*, uint>)(lpVtbl[2]))((IMetaDataValidate*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int ValidatorInit([NativeTypeName("DWORD")] uint dwModuleType, IUnknown* pUnk)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataValidate*, uint, IUnknown*, int>)(lpVtbl[3]))((IMetaDataValidate*)Unsafe.AsPointer(ref this), dwModuleType, pUnk);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int ValidateMetaData()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataValidate*, int>)(lpVtbl[4]))((IMetaDataValidate*)Unsafe.AsPointer(ref this));
        }
    }
}
