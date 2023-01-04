using System;
using System.Runtime.CompilerServices;

namespace CorProf.Bindings
{
    [NativeTypeName("struct IMetaDataDispenser : IUnknown")]
    public unsafe partial struct IMetaDataDispenser
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenser*, Guid*, void**, int>)(lpVtbl[0]))((IMetaDataDispenser*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenser*, uint>)(lpVtbl[1]))((IMetaDataDispenser*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenser*, uint>)(lpVtbl[2]))((IMetaDataDispenser*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int DefineScope([NativeTypeName("const IID &")] Guid* rclsid, [NativeTypeName("DWORD")] uint dwCreateFlags, [NativeTypeName("const IID &")] Guid* riid, IUnknown** ppIUnk)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenser*, Guid*, uint, Guid*, IUnknown**, int>)(lpVtbl[3]))((IMetaDataDispenser*)Unsafe.AsPointer(ref this), rclsid, dwCreateFlags, riid, ppIUnk);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int OpenScope([NativeTypeName("LPCWSTR")] ushort* szScope, [NativeTypeName("DWORD")] uint dwOpenFlags, [NativeTypeName("const IID &")] Guid* riid, IUnknown** ppIUnk)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenser*, ushort*, uint, Guid*, IUnknown**, int>)(lpVtbl[4]))((IMetaDataDispenser*)Unsafe.AsPointer(ref this), szScope, dwOpenFlags, riid, ppIUnk);
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int OpenScopeOnMemory([NativeTypeName("LPCVOID")] void* pData, [NativeTypeName("ULONG")] uint cbData, [NativeTypeName("DWORD")] uint dwOpenFlags, [NativeTypeName("const IID &")] Guid* riid, IUnknown** ppIUnk)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenser*, void*, uint, uint, Guid*, IUnknown**, int>)(lpVtbl[5]))((IMetaDataDispenser*)Unsafe.AsPointer(ref this), pData, cbData, dwOpenFlags, riid, ppIUnk);
        }
    }
}
