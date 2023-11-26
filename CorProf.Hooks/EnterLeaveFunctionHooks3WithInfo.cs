using CorProf.Bindings;
using System.Runtime.InteropServices;

namespace CorProf.Hooks
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
            public delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void> Enter;
            public delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void> Leave;
            public delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void> Tailcall;
        }

        private static IntPtr TryGetProcAddress(string functionName)
        {
            IntPtr addr = NativeMethods.GetProcAddress(HooksLib, functionName);

            if (addr == IntPtr.Zero)
            {
                throw new Exception($"Failed to get function '{functionName}'");
            }

            return addr;
        }

        public static void Initialize(string hooksLib = "hooks.dll")
        {
            if (File.Exists(hooksLib) == false)
            {
                throw new ArgumentException($"{hooksLib} does not exist.");
            }

            HooksLib = NativeMethods.LoadLibrary(hooksLib);
        
            if (HooksLib == IntPtr.Zero) 
            {
                throw new Exception("Failed to load hooks lib.");
            }

            EnterNaked3WithInfo = TryGetProcAddress("EnterNaked3WithInfo");

            LeaveNaked3WithInfo = TryGetProcAddress("LeaveNaked3WithInfo");

            TailcallNaked3WithInfo = TryGetProcAddress("TailcallNaked3WithInfo");
        
            SetCallbacks3WithInfo = (delegate*<EnterLeaveCallbacks3WithInfo*, void>)
                TryGetProcAddress("SetEnterLeaveCallbacks3WithInfo");
        }

        public static int Register(
            ICorProfilerInfo10* profilerInfo,
            delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void> Enter,
            delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void> Leave,
            delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void> Tailcall)
        {
            Callbacks3WithInfo = (EnterLeaveCallbacks3WithInfo*)
                NativeMemory.Alloc((nuint)sizeof(EnterLeaveCallbacks3WithInfo));

            Callbacks3WithInfo->Enter = Enter;
            Callbacks3WithInfo->Leave = Leave;
            Callbacks3WithInfo->Tailcall = Tailcall;

            SetCallbacks3WithInfo(Callbacks3WithInfo);

            return profilerInfo->SetEnterLeaveFunctionHooks3WithInfo(
                (delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void>)EnterNaked3WithInfo,
                (delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void>)LeaveNaked3WithInfo,
                (delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void>)TailcallNaked3WithInfo);
        }

        public static void Cleanup()
        {
            NativeMethods.FreeLibrary(HooksLib);
            NativeMemory.Free(Callbacks3WithInfo);
        }
    }
}