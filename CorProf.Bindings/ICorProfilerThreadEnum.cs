using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    [Guid("571194F7-25ED-419F-AA8B-7016B3159701")]
    [NativeTypeName("struct ICorProfilerThreadEnum : IUnknown")]
    public unsafe partial struct ICorProfilerThreadEnum
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerThreadEnum*, Guid*, void**, int>)(lpVtbl[0]))((ICorProfilerThreadEnum*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerThreadEnum*, uint>)(lpVtbl[1]))((ICorProfilerThreadEnum*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerThreadEnum*, uint>)(lpVtbl[2]))((ICorProfilerThreadEnum*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int Skip([NativeTypeName("ULONG")] uint celt)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerThreadEnum*, uint, int>)(lpVtbl[3]))((ICorProfilerThreadEnum*)Unsafe.AsPointer(ref this), celt);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int Reset()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerThreadEnum*, int>)(lpVtbl[4]))((ICorProfilerThreadEnum*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int Clone(ICorProfilerThreadEnum** ppEnum)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerThreadEnum*, ICorProfilerThreadEnum**, int>)(lpVtbl[5]))((ICorProfilerThreadEnum*)Unsafe.AsPointer(ref this), ppEnum);
        }

        [VtblIndex(6)]
        [return: NativeTypeName("HRESULT")]
        public int GetCount([NativeTypeName("ULONG *")] uint* pcelt)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerThreadEnum*, uint*, int>)(lpVtbl[6]))((ICorProfilerThreadEnum*)Unsafe.AsPointer(ref this), pcelt);
        }

        [VtblIndex(7)]
        [return: NativeTypeName("HRESULT")]
        public int Next([NativeTypeName("ULONG")] uint celt, [NativeTypeName("ThreadID[]")] ulong* ids, [NativeTypeName("ULONG *")] uint* pceltFetched)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerThreadEnum*, uint, ulong*, uint*, int>)(lpVtbl[7]))((ICorProfilerThreadEnum*)Unsafe.AsPointer(ref this), celt, ids, pceltFetched);
        }
    }
}
