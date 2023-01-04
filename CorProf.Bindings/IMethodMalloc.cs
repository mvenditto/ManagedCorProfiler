using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    [Guid("A0EFB28B-6EE2-4D7B-B983-A75EF7BEEDB8")]
    [NativeTypeName("struct IMethodMalloc : IUnknown")]
    public unsafe partial struct IMethodMalloc
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IMethodMalloc*, Guid*, void**, int>)(lpVtbl[0]))((IMethodMalloc*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IMethodMalloc*, uint>)(lpVtbl[1]))((IMethodMalloc*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IMethodMalloc*, uint>)(lpVtbl[2]))((IMethodMalloc*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("PVOID")]
        public void* Alloc([NativeTypeName("ULONG")] uint cb)
        {
            return ((delegate* unmanaged[Stdcall]<IMethodMalloc*, uint, void*>)(lpVtbl[3]))((IMethodMalloc*)Unsafe.AsPointer(ref this), cb);
        }
    }
}
