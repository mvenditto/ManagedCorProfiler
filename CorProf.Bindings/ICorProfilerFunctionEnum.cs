using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    [Guid("FF71301A-B994-429D-A10B-B345A65280EF")]
    [NativeTypeName("struct ICorProfilerFunctionEnum : IUnknown")]
    public unsafe partial struct ICorProfilerFunctionEnum
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerFunctionEnum*, Guid*, void**, int>)(lpVtbl[0]))((ICorProfilerFunctionEnum*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerFunctionEnum*, uint>)(lpVtbl[1]))((ICorProfilerFunctionEnum*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerFunctionEnum*, uint>)(lpVtbl[2]))((ICorProfilerFunctionEnum*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int Skip([NativeTypeName("ULONG")] uint celt)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerFunctionEnum*, uint, int>)(lpVtbl[3]))((ICorProfilerFunctionEnum*)Unsafe.AsPointer(ref this), celt);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int Reset()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerFunctionEnum*, int>)(lpVtbl[4]))((ICorProfilerFunctionEnum*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int Clone(ICorProfilerFunctionEnum** ppEnum)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerFunctionEnum*, ICorProfilerFunctionEnum**, int>)(lpVtbl[5]))((ICorProfilerFunctionEnum*)Unsafe.AsPointer(ref this), ppEnum);
        }

        [VtblIndex(6)]
        [return: NativeTypeName("HRESULT")]
        public int GetCount([NativeTypeName("ULONG *")] uint* pcelt)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerFunctionEnum*, uint*, int>)(lpVtbl[6]))((ICorProfilerFunctionEnum*)Unsafe.AsPointer(ref this), pcelt);
        }

        [VtblIndex(7)]
        [return: NativeTypeName("HRESULT")]
        public int Next([NativeTypeName("ULONG")] uint celt, [NativeTypeName("COR_PRF_FUNCTION[]")] COR_PRF_FUNCTION* ids, [NativeTypeName("ULONG *")] uint* pceltFetched)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerFunctionEnum*, uint, COR_PRF_FUNCTION*, uint*, int>)(lpVtbl[7]))((ICorProfilerFunctionEnum*)Unsafe.AsPointer(ref this), celt, ids, pceltFetched);
        }
    }
}
