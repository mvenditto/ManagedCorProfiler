using System;
using System.Runtime.CompilerServices;

namespace CorProf.Bindings
{
    [NativeTypeName("struct IMapToken : IUnknown")]
    public unsafe partial struct IMapToken
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IMapToken*, Guid*, void**, int>)(lpVtbl[0]))((IMapToken*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IMapToken*, uint>)(lpVtbl[1]))((IMapToken*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IMapToken*, uint>)(lpVtbl[2]))((IMapToken*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int Map([NativeTypeName("mdToken")] uint tkImp, [NativeTypeName("mdToken")] uint tkEmit)
        {
            return ((delegate* unmanaged[Stdcall]<IMapToken*, uint, uint, int>)(lpVtbl[3]))((IMapToken*)Unsafe.AsPointer(ref this), tkImp, tkEmit);
        }
    }
}
