using Microsoft.Diagnostics.Runtime.Utilities;
using System.Runtime.InteropServices;
using ManagedCorProfiler.ComInterop;
using ManagedCorProfiler.Utilities;
using ManagedCorProfiler.ComInterop.Wrappers;
using System.Diagnostics;
using System;

namespace ManagedCorProfiler
{
    public static class DllMainExports
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
                var classFactory = new ClassFactoryImpl();

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

        private enum DllMainCallReason
        {
            DLL_PROCESS_DETACH = 0,
            DLL_PROCESS_ATTACH = 1,
            DLL_THREAD_ATTACH = 2,
            DLL_THREAD_DETACH = 3
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