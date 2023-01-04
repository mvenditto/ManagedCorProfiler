using System;
using System.Runtime.CompilerServices;

namespace CorProf.Bindings
{
    [NativeTypeName("struct IMetaDataFilter : IUnknown")]
    public unsafe partial struct IMetaDataFilter
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataFilter*, Guid*, void**, int>)(lpVtbl[0]))((IMetaDataFilter*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataFilter*, uint>)(lpVtbl[1]))((IMetaDataFilter*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataFilter*, uint>)(lpVtbl[2]))((IMetaDataFilter*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int UnmarkAll()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataFilter*, int>)(lpVtbl[3]))((IMetaDataFilter*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int MarkToken([NativeTypeName("mdToken")] uint tk)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataFilter*, uint, int>)(lpVtbl[4]))((IMetaDataFilter*)Unsafe.AsPointer(ref this), tk);
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int IsTokenMarked([NativeTypeName("mdToken")] uint tk, [NativeTypeName("BOOL *")] int* pIsMarked)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataFilter*, uint, int*, int>)(lpVtbl[5]))((IMetaDataFilter*)Unsafe.AsPointer(ref this), tk, pIsMarked);
        }
    }
}
