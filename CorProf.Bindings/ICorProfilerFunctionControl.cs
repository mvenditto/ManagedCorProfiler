using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    [Guid("F0963021-E1EA-4732-8581-E01B0BD3C0C6")]
    [NativeTypeName("struct ICorProfilerFunctionControl : IUnknown")]
    public unsafe partial struct ICorProfilerFunctionControl
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerFunctionControl*, Guid*, void**, int>)(lpVtbl[0]))((ICorProfilerFunctionControl*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerFunctionControl*, uint>)(lpVtbl[1]))((ICorProfilerFunctionControl*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerFunctionControl*, uint>)(lpVtbl[2]))((ICorProfilerFunctionControl*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int SetCodegenFlags([NativeTypeName("DWORD")] uint flags)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerFunctionControl*, uint, int>)(lpVtbl[3]))((ICorProfilerFunctionControl*)Unsafe.AsPointer(ref this), flags);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int SetILFunctionBody([NativeTypeName("ULONG")] uint cbNewILMethodHeader, [NativeTypeName("LPCBYTE")] byte* pbNewILMethodHeader)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerFunctionControl*, uint, byte*, int>)(lpVtbl[4]))((ICorProfilerFunctionControl*)Unsafe.AsPointer(ref this), cbNewILMethodHeader, pbNewILMethodHeader);
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int SetILInstrumentedCodeMap([NativeTypeName("ULONG")] uint cILMapEntries, [NativeTypeName("COR_IL_MAP[]")] COR_IL_MAP* rgILMapEntries)
        {
            return ((delegate* unmanaged[Stdcall]<ICorProfilerFunctionControl*, uint, COR_IL_MAP*, int>)(lpVtbl[5]))((ICorProfilerFunctionControl*)Unsafe.AsPointer(ref this), cILMapEntries, rgILMapEntries);
        }
    }
}
