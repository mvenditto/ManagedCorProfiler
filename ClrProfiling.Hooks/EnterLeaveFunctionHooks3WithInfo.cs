using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.System.Diagnostics.ClrProfiling;

namespace ClrProfiling.Hooks
{
    public static unsafe class EnterLeaveFunctionHooks3WithInfo
    {
        private static IntPtr HooksLib;
        private static IntPtr EnterNaked3WithInfo;
        private static IntPtr LeaveNaked3WithInfo;
        private static IntPtr TailcallNaked3WithInfo;
        private static delegate*<EnterLeaveCallbacks3WithInfo*, void> SetCallbacks3WithInfo;
        private static EnterLeaveCallbacks3WithInfo* Callbacks3WithInfo;

        [StructLayout(LayoutKind.Sequential)]
        private unsafe struct EnterLeaveCallbacks3WithInfo
        {
            public delegate* unmanaged[Stdcall]<FunctionIDOrClientID, nuint, void> Enter;
            public delegate* unmanaged[Stdcall]<FunctionIDOrClientID, nuint, void> Leave;
            public delegate* unmanaged[Stdcall]<FunctionIDOrClientID, nuint, void> Tailcall;
        }

        private static HRESULT TryGetProcAddress(string functionName, out IntPtr procAddr)
        {
            procAddr = NativeMethods.GetProcAddress(HooksLib, functionName);

            return procAddr == IntPtr.Zero ? HRESULT.E_FAIL : HRESULT.S_OK;
        }

        public static HRESULT Initialize(string hooksLib = "hooks.dll")
        {
            if (File.Exists(hooksLib) == false)
            {
                Console.WriteLine($"hooks lib not found: {hooksLib}.");
                return HRESULT.E_FAIL;
            }

            HooksLib = NativeMethods.LoadLibrary(hooksLib);
        
            if (HooksLib == IntPtr.Zero) 
            {
                Console.WriteLine($"hooks lib failed to load: {hooksLib}.");
                return HRESULT.E_FAIL;
            }

            var hr = TryGetProcAddress("EnterNaked3WithInfo", out EnterNaked3WithInfo);

            if (hr.Failed)
            {
                Console.WriteLine($"Failed to get procedure address for: EnterNaked3WithInfo");
                return hr;
            }

            hr = TryGetProcAddress("LeaveNaked3WithInfo", out LeaveNaked3WithInfo);

            if (hr.Failed)
            {
                Console.WriteLine($"Failed to get procedure address for: LeaveNaked3WithInfo");
                return hr;
            }

            hr = TryGetProcAddress("TailcallNaked3WithInfo", out TailcallNaked3WithInfo);

            if (hr.Failed)
            {
                Console.WriteLine($"Failed to get procedure address for: TailcallNaked3WithInfo");
                return hr;
            }

            hr = TryGetProcAddress("SetEnterLeaveCallbacks3WithInfo", out var setCallbacks3WithInfo);

            if (hr.Failed)
            {
                Console.WriteLine($"Failed to get procedure address for: SetEnterLeaveCallbacks3WithInfo");
                return hr;
            }

            SetCallbacks3WithInfo = (delegate*<EnterLeaveCallbacks3WithInfo*, void>)setCallbacks3WithInfo;

            Console.WriteLine($"HooksLib=0x{HooksLib:x8}");
            Console.WriteLine($"EnterNaked3WithInfo=0x{EnterNaked3WithInfo:x8}");
            Console.WriteLine($"LeaveNaked3WithInfo=0x{LeaveNaked3WithInfo:x8}");
            Console.WriteLine($"TailcallNaked3WithInfo=0x{TailcallNaked3WithInfo:x8}");
            Console.WriteLine($"SetEnterLeaveCallbacks3WithInfo=0x{setCallbacks3WithInfo:x8}");

            return HRESULT.S_OK;
        }

        public static HRESULT Register(
            ICorProfilerInfo10* profilerInfo,
            delegate* unmanaged[Stdcall]<FunctionIDOrClientID, nuint, void> enter,
            delegate* unmanaged[Stdcall]<FunctionIDOrClientID, nuint, void> leave,
            delegate* unmanaged[Stdcall]<FunctionIDOrClientID, nuint, void> tailcall)
        {
            Callbacks3WithInfo = (EnterLeaveCallbacks3WithInfo*)
                NativeMemory.Alloc((nuint)sizeof(EnterLeaveCallbacks3WithInfo));

            Callbacks3WithInfo->Enter = enter;
            Callbacks3WithInfo->Leave = leave;
            Callbacks3WithInfo->Tailcall = tailcall;

            SetCallbacks3WithInfo(Callbacks3WithInfo);

            return profilerInfo->SetEnterLeaveFunctionHooks3WithInfo(
                (delegate* unmanaged[Stdcall]<FunctionIDOrClientID, nuint, void>*)EnterNaked3WithInfo,
                (delegate* unmanaged[Stdcall]<FunctionIDOrClientID, nuint, void>*)LeaveNaked3WithInfo,
                (delegate* unmanaged[Stdcall]<FunctionIDOrClientID, nuint, void>*)TailcallNaked3WithInfo);
        }

        public static void Cleanup()
        {
            NativeMethods.FreeLibrary(HooksLib);
            NativeMemory.Free(Callbacks3WithInfo);
        }
    }
}