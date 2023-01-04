using System;
using System.Runtime.CompilerServices;

namespace CorProf.Bindings
{
    [NativeTypeName("struct IMetaDataError : IUnknown")]
    public unsafe partial struct IMetaDataError
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataError*, Guid*, void**, int>)(lpVtbl[0]))((IMetaDataError*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataError*, uint>)(lpVtbl[1]))((IMetaDataError*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataError*, uint>)(lpVtbl[2]))((IMetaDataError*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int OnError([NativeTypeName("HRESULT")] int hrError, [NativeTypeName("mdToken")] uint token)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataError*, int, uint, int>)(lpVtbl[3]))((IMetaDataError*)Unsafe.AsPointer(ref this), hrError, token);
        }
    }
}
