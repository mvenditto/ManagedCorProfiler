using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    [Guid("FCCEE788-0088-454B-A811-C99F298D1942")]
    [NativeTypeName("struct ICorProfilerMethodEnum : IUnknown")]
    public unsafe partial struct ICorProfilerMethodEnum
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerMethodEnum*, Guid*, void**, int>)(lpVtbl[0]))((ICorProfilerMethodEnum*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerMethodEnum*, uint>)(lpVtbl[1]))((ICorProfilerMethodEnum*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerMethodEnum*, uint>)(lpVtbl[2]))((ICorProfilerMethodEnum*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int Skip([NativeTypeName("ULONG")] uint celt)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerMethodEnum*, uint, int>)(lpVtbl[3]))((ICorProfilerMethodEnum*)Unsafe.AsPointer(ref this), celt);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int Reset()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerMethodEnum*, int>)(lpVtbl[4]))((ICorProfilerMethodEnum*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int Clone(ICorProfilerMethodEnum** ppEnum)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerMethodEnum*, ICorProfilerMethodEnum**, int>)(lpVtbl[5]))((ICorProfilerMethodEnum*)Unsafe.AsPointer(ref this), ppEnum);
        }

        [VtblIndex(6)]
        [return: NativeTypeName("HRESULT")]
        public int GetCount([NativeTypeName("ULONG *")] uint* pcelt)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerMethodEnum*, uint*, int>)(lpVtbl[6]))((ICorProfilerMethodEnum*)Unsafe.AsPointer(ref this), pcelt);
        }

        [VtblIndex(7)]
        [return: NativeTypeName("HRESULT")]
        public int Next([NativeTypeName("ULONG")] uint celt, [NativeTypeName("COR_PRF_METHOD[]")] COR_PRF_METHOD* elements, [NativeTypeName("ULONG *")] uint* pceltFetched)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerMethodEnum*, uint, COR_PRF_METHOD*, uint*, int>)(lpVtbl[7]))((ICorProfilerMethodEnum*)Unsafe.AsPointer(ref this), celt, elements, pceltFetched);
        }
    }
}
