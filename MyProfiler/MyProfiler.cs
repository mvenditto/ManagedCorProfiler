using Microsoft.Diagnostics.Runtime.Utilities;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ClrProfiling.Core;
using ClrProfiling.Core.Abstractions;
using Windows.Win32.Foundation;
using Windows.Win32.System.Com;
using Windows.Win32.System.WinRT.Metadata;
using Windows.Win32.System.Diagnostics.ClrProfiling;
using ClrProfiling.Helpers;

using ULONG32 = uint;

namespace MyProfiler
{
    [ProfilerCallback("cf0d821e-299b-5307-a3d8-b283c03916dd")]
    internal unsafe class MyProfiler : CorProfilerCallback2
    {
        private ICorProfilerInfo2* _profilerInfo;

        [StructLayout(LayoutKind.Sequential)]
        private unsafe struct EnterLeavelCallbacks2
        {
            public delegate* unmanaged[Stdcall]<nuint, nuint, nuint, COR_PRF_FUNCTION_ARGUMENT_INFO*, void> Enter;
            public delegate* unmanaged[Stdcall]<nuint, nuint, nuint, COR_PRF_FUNCTION_ARGUMENT_RANGE*, void> Leave;
            public delegate* unmanaged[Stdcall]<nuint, nuint, nuint, void> Tailcall;
            public void* ProfilerInfo;
        }

        private static EnterLeavelCallbacks2* EnterLeaveCallbacks = 
            (EnterLeavelCallbacks2*)NativeMemory.Alloc((nuint)sizeof(EnterLeavelCallbacks2));

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static nuint FunctionIDMapper(nuint functionId, BOOL* pbHookFunction)
        {
            *pbHookFunction = new BOOL(1); // true
            return (nuint) EnterLeaveCallbacks; 
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static void EnterStub(nuint functionId, nuint clientData, nuint func, COR_PRF_FUNCTION_ARGUMENT_INFO* f)
        {
            var profInfo = (ICorProfilerInfo2*)((EnterLeavelCallbacks2*) clientData)->ProfilerInfo;

            nuint classId = 0;
            nuint moduleId = 0;
            uint token = 0;

            var hr = profInfo->GetFunctionInfo2(
                functionId,
                func,
                &classId,
                &moduleId,
                &token,
                0,
                null,
                null
            );

            if (hr < 0)
            {
                Console.WriteLine($"Error GetFunctionInfo2 hr={hr}");
            }

            var iMetaDataImportIID = new Guid(0x7dac8207, 0xd3ae, 0x4c75, 0x9b, 0x67, 0x92, 0x80, 0x1a, 0x49, 0x7d, 0x44);

            var ptr = (IUnknown*) NativeMemory.Alloc((nuint)sizeof(nint));

            hr = profInfo->GetModuleMetaData(
                moduleId,
                (uint)CorOpenFlags.ofRead,
                &iMetaDataImportIID,
                &ptr);

            if (hr < 0)
            {
                Console.WriteLine($"Error GetModuleMetaData hr={hr}");
            }

            var metadataImport = (IMetaDataImport*)ptr;

            using var buff = NativeBuffer<ushort>.Alloc(300);

            var szName = new PWSTR((char*)buff.Pointer);

            hr = metadataImport->GetMethodProps(
                token,
                (ULONG32*)0,
                szName,
                buff.Length,
                (ULONG32*)0,
                (ULONG32*)0,
                (byte**)0,
                (ULONG32*)0,
                (ULONG32*)0,
                (ULONG32*)0);

            if (hr < 0)
            {
                Console.WriteLine($"Error GetMethodProps hr={hr}");
            }
            else
            {
                var funcName = Marshal.PtrToStringUni(buff);

                Console.WriteLine($"=> {funcName}()");
            }

            NativeMemory.Free(szName);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static void LeaveStub(nuint functionId, nuint clientData, nuint func, COR_PRF_FUNCTION_ARGUMENT_RANGE* f)
        {
            //Console.WriteLine("LEAVE");
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static void TailcallStub(nuint functionId, nuint clientData, nuint frameInfo)
        {
            //Console.WriteLine("TAILCALL");
        }

        #region EnterLeaveHooks
        static IntPtr EnterNaked2;
        static IntPtr LeaveNaked2;
        static IntPtr TailcallNaked2;

        private static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            public static extern IntPtr LoadLibrary(string dllToLoad);

            [DllImport("kernel32.dll")]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

            [DllImport("kernel32.dll")]
            public static extern bool FreeLibrary(IntPtr hModule);
        }

        private static IntPtr HooksLib;

        private static void InitHooks()
        {
            var x = Assembly.GetEntryAssembly();

            var hooksDllPath = Path.Combine(
                Environment.CurrentDirectory,
                "hooks\\hooks.dll");

            Console.WriteLine(hooksDllPath);
            HooksLib = NativeMethods.LoadLibrary(hooksDllPath); 
            Console.WriteLine($"HooksLib 0x{((nint)HooksLib):X8}");
            var enterHookAddr = NativeMethods.GetProcAddress(HooksLib, "EnterNaked2");
            var leaveHookAddr = NativeMethods.GetProcAddress(HooksLib, "LeaveNaked2");
            var tailCallHookAddr = NativeMethods.GetProcAddress(HooksLib, "TailcallNaked2");
            EnterNaked2 = enterHookAddr;
            LeaveNaked2 = leaveHookAddr;
            TailcallNaked2 = tailCallHookAddr;
            Console.WriteLine($"EnterHook 0x{((nint)EnterNaked2):X8}");
            Console.WriteLine($"LeaveHook 0x{((nint)LeaveNaked2):X8}");
            Console.WriteLine($"TailCallHook 0x{((nint)LeaveNaked2):X8}");

            EnterLeaveCallbacks->Enter = &EnterStub;
            EnterLeaveCallbacks->Leave = &LeaveStub;
            EnterLeaveCallbacks->Tailcall = &TailcallStub;
        }
        #endregion

        public override HRESULT Initialize(IUnknown* unknown)
        {
            Console.Write("MyProfiler!Initialize");

            var guid_ = ICorProfilerInfo2.IID_Guid;

            var hr = Marshal.QueryInterface((nint)unknown, ref guid_, out var pinfo);

            Console.WriteLine($"ICorProfilerCallback!Initialize(): profInfo {pinfo:X8}");

            if (hr < 0)
            {
                Console.WriteLine($"Error hr=0x{hr:X8}");
                return HRESULT.E_FAIL;
            }

            // see https://learn.microsoft.com/en-us/dotnet/framework/unmanaged-api/profiling/cor-prf-monitor-enumeration
            var eventMask =
                COR_PRF_MONITOR.COR_PRF_MONITOR_CLASS_LOADS |
                COR_PRF_MONITOR.COR_PRF_MONITOR_MODULE_LOADS |
                COR_PRF_MONITOR.COR_PRF_MONITOR_ENTERLEAVE |        // needed by ICorProfilerCallback2::SetEnterLeaveFunctionHooks2
                COR_PRF_MONITOR.COR_PRF_ENABLE_FUNCTION_ARGS |      // otherwise COR_PRF_FUNCTION_ARGUMENT_INFO* will be NULL in EnterFunction2
                COR_PRF_MONITOR.COR_PRF_ENABLE_FRAME_INFO |         // otherwise COR_PRF_ENABLE_FRAME_INFO will be NULL in EnterFunction2
                COR_PRF_MONITOR.COR_PRF_ENABLE_FUNCTION_RETVAL |    // otherwise COR_PRF_FUNCTION_ARGUMENT_RANGE* will be NULL in LeaveFunction2
                COR_PRF_MONITOR.COR_PRF_MONITOR_JIT_COMPILATION |
                COR_PRF_MONITOR.COR_PRF_DISABLE_OPTIMIZATIONS |
                COR_PRF_MONITOR.COR_PRF_DISABLE_INLINING;
             
            /*
            var eventMask = 
                    COR_PRF_MONITOR.COR_PRF_MONITOR_MODULE_LOADS
                    | COR_PRF_MONITOR.COR_PRF_MONITOR_ASSEMBLY_LOADS
                    | COR_PRF_MONITOR.COR_PRF_MONITOR_CLASS_LOADS
                    | COR_PRF_MONITOR.COR_PRF_DISABLE_INLINING
                    | COR_PRF_MONITOR.COR_PRF_DISABLE_TRANSPARENCY_CHECKS_UNDER_FULL_TRUST;
            */
            _profilerInfo = (ICorProfilerInfo2*)pinfo;

            hr = _profilerInfo->SetEventMask((uint)eventMask);

            if (hr < 0)
            {
                Console.WriteLine($"Error hr={hr}");
                return HRESULT.E_FAIL;
            }

            InitHooks();

            EnterLeaveCallbacks->ProfilerInfo = (void*)pinfo;

            hr = _profilerInfo->SetFunctionIDMapper(&FunctionIDMapper);

            if (hr < 0)
            {
                Console.WriteLine($"Error SetFunctionIDMapper hr={hr}");
                return HRESULT.E_FAIL;
            }

            hr = _profilerInfo->SetEnterLeaveFunctionHooks2(
                (delegate* unmanaged[Stdcall]<nuint, nuint, nuint, COR_PRF_FUNCTION_ARGUMENT_INFO*, void>)EnterNaked2,
                (delegate* unmanaged[Stdcall]<nuint, nuint, nuint, COR_PRF_FUNCTION_ARGUMENT_RANGE*, void>)LeaveNaked2,
                (delegate* unmanaged[Stdcall]<nuint, nuint, nuint, void>)TailcallNaked2
            );

            if (hr < 0)
            {
                Console.WriteLine($"Error SetEnterLeaveFunctionHooks2 hr={hr}");
                return HRESULT.E_FAIL;
            }
            
            return HRESULT.S_OK;
        }

        public override HRESULT Shutdown() 
        {
            NativeMemory.Free(EnterLeaveCallbacks);
            NativeMethods.FreeLibrary(HooksLib);
            return HRESULT.S_OK;
        }

        public override HRESULT ModuleLoadFinished(nuint moduleId, HRESULT hrStatus)
        {
            Console.WriteLine($"ICorProfilerCallback!ModuleLoadFinished(0x{moduleId:X8})");

            var pbBaseLoadAddr = (byte*)null;
            uint pcchName = 0;
            nuint assemblyId = 0;


            using var buff = NativeBuffer<ushort>.Alloc(300);

            var szName = new PWSTR((char*)buff.Pointer);

            var hr = _profilerInfo->GetModuleInfo(
                moduleId,
                &pbBaseLoadAddr,
                300,
                &pcchName,
                szName,
                &assemblyId);

            if (hr < 0)
            {
                Console.WriteLine($"Error hr=0x{hr:X8}");
                return HRESULT.E_FAIL;
            }

            var module = Marshal.PtrToStringUni(buff);

            Console.WriteLine($"Loaded Moudle -> '{module}'");

            NativeMemory.Free(szName);

            return HRESULT.S_OK;
        }
    }
}