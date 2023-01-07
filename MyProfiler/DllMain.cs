using CorProf.Bindings;
using CorProf.Shared;
using ManagedCorProfiler.ComInterop.Wrappers;
using ManagedCorProfiler.Utilities;
using Microsoft.Diagnostics.Runtime.Utilities;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorProfiler
{
    public static class DllEntryPointExports
    {
        [UnmanagedCallersOnly(EntryPoint = "DllGetClassObject")]
        public static unsafe int DllGetClassObject(Guid* rclsid, Guid* riid, IntPtr* ppv)
        {
            Console.WriteLine("DllGetClassObject()");
            Console.WriteLine($"\tRCLSID = {*rclsid}");
            Console.WriteLine($"\tRIID   = {*riid}");

            var guid = *riid;

            if (guid == Guids.IID_IUnknown
             || guid == Guids.IID_IClassFactory)
            {

                var cw = new ClassFactoryComWrappers();

                var classFactory = new DefaultClassFactory(new MyProfiler());

                IntPtr ccwUnknown = cw.GetOrCreateComInterfaceForObject(
                    classFactory,
                    CreateComInterfaceFlags.None);

                var hr = Marshal.QueryInterface(ccwUnknown, ref guid, out var ptr);

                Debug.Assert(hr == 0);

                *ppv = ptr;

                return HResult.S_OK;
            }

            *ppv = IntPtr.Zero;
            return HResult.E_NOINTERFACE;
        }

        [UnmanagedCallersOnly(EntryPoint = "DllCanUnloadNow")]
        public static unsafe int DllCanUnloadNow()
        {
            return HResult.S_OK;
        }

        [UnmanagedCallersOnly(EntryPoint = "DllMain")]
        public static unsafe int DllMain(IntPtr hModule, int fwReason, IntPtr reserved)
        {
            var reason = (DllMainCallReason)fwReason;

            Console.WriteLine($"DllMain(reason={reason})");

            switch (reason)
            {
                case DllMainCallReason.DLL_PROCESS_ATTACH:
                case DllMainCallReason.DLL_THREAD_ATTACH:
                case DllMainCallReason.DLL_THREAD_DETACH:
                    break;
                case DllMainCallReason.DLL_PROCESS_DETACH:
                    break;
            }

            return Bool.TRUE;
        }
    }
}