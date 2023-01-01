using System.Runtime.CompilerServices;

namespace ManagedCorProfiler.ComInterop
{
    public unsafe struct IUnknown
    {
        public void** lpVtbl;

        public int QueryInterface(Guid* riid, IntPtr* ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IUnknown*, Guid*, IntPtr*, int>)lpVtbl[0])((IUnknown*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IUnknown*, uint>)lpVtbl[1])((IUnknown*)Unsafe.AsPointer(ref this));
        }

        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IUnknown*, uint>)lpVtbl[2])((IUnknown*)Unsafe.AsPointer(ref this));
        }
    }
}