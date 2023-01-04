using System;
using System.Runtime.CompilerServices;

namespace CorProf.Bindings
{
    [NativeTypeName("struct IMetaDataDispenserEx : IMetaDataDispenser")]
    public unsafe partial struct IMetaDataDispenserEx
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenserEx*, Guid*, void**, int>)(lpVtbl[0]))((IMetaDataDispenserEx*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenserEx*, uint>)(lpVtbl[1]))((IMetaDataDispenserEx*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenserEx*, uint>)(lpVtbl[2]))((IMetaDataDispenserEx*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int DefineScope([NativeTypeName("const IID &")] Guid* rclsid, [NativeTypeName("DWORD")] uint dwCreateFlags, [NativeTypeName("const IID &")] Guid* riid, IUnknown** ppIUnk)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenserEx*, Guid*, uint, Guid*, IUnknown**, int>)(lpVtbl[3]))((IMetaDataDispenserEx*)Unsafe.AsPointer(ref this), rclsid, dwCreateFlags, riid, ppIUnk);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int OpenScope([NativeTypeName("LPCWSTR")] ushort* szScope, [NativeTypeName("DWORD")] uint dwOpenFlags, [NativeTypeName("const IID &")] Guid* riid, IUnknown** ppIUnk)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenserEx*, ushort*, uint, Guid*, IUnknown**, int>)(lpVtbl[4]))((IMetaDataDispenserEx*)Unsafe.AsPointer(ref this), szScope, dwOpenFlags, riid, ppIUnk);
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int OpenScopeOnMemory([NativeTypeName("LPCVOID")] void* pData, [NativeTypeName("ULONG")] uint cbData, [NativeTypeName("DWORD")] uint dwOpenFlags, [NativeTypeName("const IID &")] Guid* riid, IUnknown** ppIUnk)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenserEx*, void*, uint, uint, Guid*, IUnknown**, int>)(lpVtbl[5]))((IMetaDataDispenserEx*)Unsafe.AsPointer(ref this), pData, cbData, dwOpenFlags, riid, ppIUnk);
        }

        [VtblIndex(6)]
        [return: NativeTypeName("HRESULT")]
        public int SetOption([NativeTypeName("const GUID &")] Guid* optionid, [NativeTypeName("const VARIANT *")] IntPtr* value)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenserEx*, Guid*, IntPtr*, int>)(lpVtbl[6]))((IMetaDataDispenserEx*)Unsafe.AsPointer(ref this), optionid, value);
        }

        [VtblIndex(7)]
        [return: NativeTypeName("HRESULT")]
        public int GetOption([NativeTypeName("const GUID &")] Guid* optionid, [NativeTypeName("VARIANT *")] IntPtr* pvalue)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenserEx*, Guid*, IntPtr*, int>)(lpVtbl[7]))((IMetaDataDispenserEx*)Unsafe.AsPointer(ref this), optionid, pvalue);
        }

        [VtblIndex(8)]
        [return: NativeTypeName("HRESULT")]
        public int OpenScopeOnITypeInfo([NativeTypeName("ITypeInfo *")] IntPtr* pITI, [NativeTypeName("DWORD")] uint dwOpenFlags, [NativeTypeName("const IID &")] Guid* riid, IUnknown** ppIUnk)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenserEx*, IntPtr*, uint, Guid*, IUnknown**, int>)(lpVtbl[8]))((IMetaDataDispenserEx*)Unsafe.AsPointer(ref this), pITI, dwOpenFlags, riid, ppIUnk);
        }

        [VtblIndex(9)]
        [return: NativeTypeName("HRESULT")]
        public int GetCORSystemDirectory([NativeTypeName("LPWSTR")] ushort* szBuffer, [NativeTypeName("DWORD")] uint cchBuffer, [NativeTypeName("DWORD *")] uint* pchBuffer)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenserEx*, ushort*, uint, uint*, int>)(lpVtbl[9]))((IMetaDataDispenserEx*)Unsafe.AsPointer(ref this), szBuffer, cchBuffer, pchBuffer);
        }

        [VtblIndex(10)]
        [return: NativeTypeName("HRESULT")]
        public int FindAssembly([NativeTypeName("LPCWSTR")] ushort* szAppBase, [NativeTypeName("LPCWSTR")] ushort* szPrivateBin, [NativeTypeName("LPCWSTR")] ushort* szGlobalBin, [NativeTypeName("LPCWSTR")] ushort* szAssemblyName, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pcName)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenserEx*, ushort*, ushort*, ushort*, ushort*, ushort*, uint, uint*, int>)(lpVtbl[10]))((IMetaDataDispenserEx*)Unsafe.AsPointer(ref this), szAppBase, szPrivateBin, szGlobalBin, szAssemblyName, szName, cchName, pcName);
        }

        [VtblIndex(11)]
        [return: NativeTypeName("HRESULT")]
        public int FindAssemblyModule([NativeTypeName("LPCWSTR")] ushort* szAppBase, [NativeTypeName("LPCWSTR")] ushort* szPrivateBin, [NativeTypeName("LPCWSTR")] ushort* szGlobalBin, [NativeTypeName("LPCWSTR")] ushort* szAssemblyName, [NativeTypeName("LPCWSTR")] ushort* szModuleName, [NativeTypeName("LPWSTR")] ushort* szName, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pcName)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataDispenserEx*, ushort*, ushort*, ushort*, ushort*, ushort*, ushort*, uint, uint*, int>)(lpVtbl[11]))((IMetaDataDispenserEx*)Unsafe.AsPointer(ref this), szAppBase, szPrivateBin, szGlobalBin, szAssemblyName, szModuleName, szName, cchName, pcName);
        }
    }
}
