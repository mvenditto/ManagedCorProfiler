using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    [Guid("B0266D75-2081-4493-AF7F-028BA34DB891")]
    [NativeTypeName("struct ICorProfilerModuleEnum : IUnknown")]
    public unsafe partial struct ICorProfilerModuleEnum
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerModuleEnum*, Guid*, void**, int>)(lpVtbl[0]))((ICorProfilerModuleEnum*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerModuleEnum*, uint>)(lpVtbl[1]))((ICorProfilerModuleEnum*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerModuleEnum*, uint>)(lpVtbl[2]))((ICorProfilerModuleEnum*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int Skip([NativeTypeName("ULONG")] uint celt)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerModuleEnum*, uint, int>)(lpVtbl[3]))((ICorProfilerModuleEnum*)Unsafe.AsPointer(ref this), celt);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int Reset()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerModuleEnum*, int>)(lpVtbl[4]))((ICorProfilerModuleEnum*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int Clone(ICorProfilerModuleEnum** ppEnum)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerModuleEnum*, ICorProfilerModuleEnum**, int>)(lpVtbl[5]))((ICorProfilerModuleEnum*)Unsafe.AsPointer(ref this), ppEnum);
        }

        [VtblIndex(6)]
        [return: NativeTypeName("HRESULT")]
        public int GetCount([NativeTypeName("ULONG *")] uint* pcelt)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerModuleEnum*, uint*, int>)(lpVtbl[6]))((ICorProfilerModuleEnum*)Unsafe.AsPointer(ref this), pcelt);
        }

        [VtblIndex(7)]
        [return: NativeTypeName("HRESULT")]
        public int Next([NativeTypeName("ULONG")] uint celt, [NativeTypeName("ModuleID[]")] ulong* ids, [NativeTypeName("ULONG *")] uint* pceltFetched)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerModuleEnum*, uint, ulong*, uint*, int>)(lpVtbl[7]))((ICorProfilerModuleEnum*)Unsafe.AsPointer(ref this), celt, ids, pceltFetched);
        }
    }
}
