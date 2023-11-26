using CorProf.Bindings;
using System.Runtime.InteropServices;
using System.Text;

namespace Tests.Common
{
    // TODO: refac and bring it to main lib
    public unsafe static class EnterLeaveHooks3WithInfo
    {
        public static IntPtr EnterNaked3WithInfo;
        public static IntPtr LeaveNaked3WithInfo;
        public static IntPtr TailcallNaked3WithInfo;
        private static IntPtr HooksLib;
        public static EnterLeaveCallbacks3WithInfo* EnterLeaveCallbacks =
            (EnterLeaveCallbacks3WithInfo*) NativeMemory.Alloc((nuint)sizeof(EnterLeaveCallbacks3WithInfo));

        private static delegate*<EnterLeaveCallbacks3WithInfo*, void> _setUserCallbacks;

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct EnterLeaveCallbacks3WithInfo
        {
            public delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void> Enter;
            public delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void> Leave;
            public delegate* unmanaged[Stdcall]<FunctionIDOrClientID, ulong, void> Tailcall;
        }

        private static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            public static extern IntPtr LoadLibrary(string dllToLoad);

            [DllImport("kernel32.dll")]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

            [DllImport("kernel32.dll")]
            public static extern bool FreeLibrary(IntPtr hModule);
        }

        public static void SetCallbacks(EnterLeaveCallbacks3WithInfo* callbacks)
        {
            _setUserCallbacks(callbacks);
        }

        public static void Initialize(string hooksLibPath)
        {
            HooksLib = NativeMethods.LoadLibrary(hooksLibPath);

            if (HooksLib == IntPtr.Zero)
            {
                throw new Exception($"Failed to load library: {hooksLibPath}");
            }

            Console.WriteLine($"HooksLib 0x{HooksLib:X8}");

            var enterHookAddr = NativeMethods.GetProcAddress(HooksLib, "EnterNaked3WithInfo");
            var leaveHookAddr = NativeMethods.GetProcAddress(HooksLib, "LeaveNaked3WithInfo");
            var tailCallHookAddr = NativeMethods.GetProcAddress(HooksLib, "TailcallNaked3WithInfo");

            var setUserCallbacks = NativeMethods.GetProcAddress(HooksLib, "SetUserCallbacks");

            _setUserCallbacks = (delegate*<EnterLeaveCallbacks3WithInfo*, void>)setUserCallbacks;

            EnterNaked3WithInfo = enterHookAddr;
            LeaveNaked3WithInfo = leaveHookAddr;
            TailcallNaked3WithInfo = tailCallHookAddr;

            Console.WriteLine($"SetUserCallbacks 0x{setUserCallbacks:X8}");
            Console.WriteLine($"EnterHook 0x{EnterNaked3WithInfo:X8}");
            Console.WriteLine($"LeaveHook 0x{LeaveNaked3WithInfo:X8}");
            Console.WriteLine($"TailCallHook 0x{LeaveNaked3WithInfo:X8}");
        }

        public static void Cleanup()
        {
            Console.WriteLine("FreeLibrary");
            NativeMethods.FreeLibrary(HooksLib);
            Console.WriteLine("Free > EnterLeaveCallbacks");
            NativeMemory.Free(EnterLeaveCallbacks);
        }
    }
}
