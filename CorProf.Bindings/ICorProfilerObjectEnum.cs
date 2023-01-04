using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    [Guid("2C6269BD-2D13-4321-AE12-6686365FD6AF")]
    [NativeTypeName("struct ICorProfilerObjectEnum : IUnknown")]
    public unsafe partial struct ICorProfilerObjectEnum
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerObjectEnum*, Guid*, void**, int>)(lpVtbl[0]))((ICorProfilerObjectEnum*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerObjectEnum*, uint>)(lpVtbl[1]))((ICorProfilerObjectEnum*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerObjectEnum*, uint>)(lpVtbl[2]))((ICorProfilerObjectEnum*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int Skip([NativeTypeName("ULONG")] uint celt)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerObjectEnum*, uint, int>)(lpVtbl[3]))((ICorProfilerObjectEnum*)Unsafe.AsPointer(ref this), celt);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int Reset()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerObjectEnum*, int>)(lpVtbl[4]))((ICorProfilerObjectEnum*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int Clone(ICorProfilerObjectEnum** ppEnum)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerObjectEnum*, ICorProfilerObjectEnum**, int>)(lpVtbl[5]))((ICorProfilerObjectEnum*)Unsafe.AsPointer(ref this), ppEnum);
        }

        [VtblIndex(6)]
        [return: NativeTypeName("HRESULT")]
        public int GetCount([NativeTypeName("ULONG *")] uint* pcelt)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerObjectEnum*, uint*, int>)(lpVtbl[6]))((ICorProfilerObjectEnum*)Unsafe.AsPointer(ref this), pcelt);
        }

        [VtblIndex(7)]
        [return: NativeTypeName("HRESULT")]
        public int Next([NativeTypeName("ULONG")] uint celt, [NativeTypeName("ObjectID[]")] ulong* objects, [NativeTypeName("ULONG *")] uint* pceltFetched)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerObjectEnum*, uint, ulong*, uint*, int>)(lpVtbl[7]))((ICorProfilerObjectEnum*)Unsafe.AsPointer(ref this), celt, objects, pceltFetched);
        }
    }
}
