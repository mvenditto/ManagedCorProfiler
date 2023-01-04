using System;
using System.Runtime.CompilerServices;

namespace CorProf.Bindings
{
    [NativeTypeName("struct IHostFilter : IUnknown")]
    public unsafe partial struct IHostFilter
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IHostFilter*, Guid*, void**, int>)(lpVtbl[0]))((IHostFilter*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IHostFilter*, uint>)(lpVtbl[1]))((IHostFilter*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IHostFilter*, uint>)(lpVtbl[2]))((IHostFilter*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int MarkToken([NativeTypeName("mdToken")] uint tk)
        {
            return ((delegate* unmanaged[Stdcall]<IHostFilter*, uint, int>)(lpVtbl[3]))((IHostFilter*)Unsafe.AsPointer(ref this), tk);
        }
    }
}
