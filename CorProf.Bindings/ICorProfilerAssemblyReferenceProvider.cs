using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    [Guid("66A78C24-2EEF-4F65-B45F-DD1D8038BF3C")]
    [NativeTypeName("struct ICorProfilerAssemblyReferenceProvider : IUnknown")]
    public unsafe partial struct ICorProfilerAssemblyReferenceProvider
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerAssemblyReferenceProvider*, Guid*, void**, int>)(lpVtbl[0]))((ICorProfilerAssemblyReferenceProvider*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerAssemblyReferenceProvider*, uint>)(lpVtbl[1]))((ICorProfilerAssemblyReferenceProvider*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerAssemblyReferenceProvider*, uint>)(lpVtbl[2]))((ICorProfilerAssemblyReferenceProvider*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int AddAssemblyReference([NativeTypeName("const COR_PRF_ASSEMBLY_REFERENCE_INFO *")] COR_PRF_ASSEMBLY_REFERENCE_INFO* pAssemblyRefInfo)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerAssemblyReferenceProvider*, COR_PRF_ASSEMBLY_REFERENCE_INFO*, int>)(lpVtbl[3]))((ICorProfilerAssemblyReferenceProvider*)Unsafe.AsPointer(ref this), pAssemblyRefInfo);
        }
    }
}
