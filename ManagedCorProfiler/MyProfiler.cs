using CorProf.Bindings;
using ManagedCorProfiler.Utilities;
using Microsoft.Diagnostics.Runtime.Utilities;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using ICorProfilerCallback = ManagedCorProfiler.ComInterop.Interfaces.ICorProfilerCallback;
using ICorProfilerCallback2 = ManagedCorProfiler.ComInterop.Interfaces.ICorProfilerCallback2;

namespace ManagedCorProfiler
{
    internal unsafe class MyProfiler : ICorProfilerCallback2
    {
        private ICorProfilerInfo2* _profilerInfo;

        [StructLayout(LayoutKind.Sequential)]
        private unsafe struct EnterLeavelCallbacks2
        {
            public delegate* unmanaged[Stdcall]<ulong, ulong, ulong, COR_PRF_FUNCTION_ARGUMENT_INFO*, void> Enter;
            public delegate* unmanaged[Stdcall]<ulong, ulong, ulong, COR_PRF_FUNCTION_ARGUMENT_RANGE*, void> Leave;
            public delegate* unmanaged[Stdcall]<ulong, ulong, ulong, void> Tailcall;
            public void* ProfilerInfo;
        }

        private static EnterLeavelCallbacks2* EnterLeaveCallbacks = 
            (EnterLeavelCallbacks2*)NativeMemory.Alloc((nuint)sizeof(EnterLeavelCallbacks2));

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static ulong FunctionIDMapper(ulong functionId, int* pbHookFunction)
        {
            *pbHookFunction = Bool.TRUE;
            return (ulong) EnterLeaveCallbacks; 
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static void EnterStub(ulong functionId, ulong clientData, ulong func, COR_PRF_FUNCTION_ARGUMENT_INFO* f)
        {
            var profInfo = (ICorProfilerInfo2*)((EnterLeavelCallbacks2*) clientData)->ProfilerInfo;

            ulong classId = 0;
            ulong moduleId = 0;
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

            var ptr = (CorProf.Bindings.IUnknown*) NativeMemory.Alloc((nuint)sizeof(nint));

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

            var szName = (ushort*)NativeMemory.Alloc(sizeof(ushort) * 300);

            metadataImport->GetMethodProps(
                (uint)token, null, szName, 300, null, null, null, null, null, null);

            if (hr < 0)
            {
                Console.WriteLine($"Error GetMethodProps hr={hr}");
            }
            else
            {
                var funcName = Marshal.PtrToStringUni((nint)szName);

                Console.WriteLine($"=> {funcName}()");
            }

            NativeMemory.Free(szName);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static void LeaveStub(ulong functionId, ulong clientData, ulong func, COR_PRF_FUNCTION_ARGUMENT_RANGE* f)
        {
            //Console.WriteLine("LEAVE");
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static void TailcallStub(ulong functionId, ulong clientData, ulong frameInfo)
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

        int ICorProfilerCallback.Initialize(CorProf.Bindings.IUnknown* unknown)
        {
            Console.Write("MyProfiler!Initialize");

            var guid_ = CorProfConsts.IID_ICorProfilerInfo2;

            var hr = Marshal.QueryInterface((nint)unknown, ref guid_, out var pinfo);

            Console.WriteLine($"ICorProfilerCallback!Initialize(): profInfo {pinfo:X8}");

            if (hr < 0)
            {
                Console.WriteLine($"Error hr=0x{hr:X8}");
                return HResult.E_FAIL;
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
                return HResult.E_FAIL;
            }

            InitHooks();

            EnterLeaveCallbacks->ProfilerInfo = (void*)pinfo;

            hr = _profilerInfo->SetFunctionIDMapper(&FunctionIDMapper);

            if (hr < 0)
            {
                Console.WriteLine($"Error SetFunctionIDMapper hr={hr}");
                return HResult.E_FAIL;
            }

            hr = _profilerInfo->SetEnterLeaveFunctionHooks2(
                (delegate* unmanaged[Stdcall]<ulong, ulong, ulong, COR_PRF_FUNCTION_ARGUMENT_INFO*, void>)EnterNaked2,
                (delegate* unmanaged[Stdcall]<ulong, ulong, ulong, COR_PRF_FUNCTION_ARGUMENT_RANGE*, void>)LeaveNaked2,
                (delegate* unmanaged[Stdcall]<ulong, ulong, ulong, void>)TailcallNaked2
            );

            if (hr < 0)
            {
                Console.WriteLine($"Error SetEnterLeaveFunctionHooks2 hr={hr}");
                return HResult.E_FAIL;
            }
            
            return HResult.S_OK;
        }

        int ICorProfilerCallback.Shutdown() 
        {
            NativeMemory.Free(EnterLeaveCallbacks);
            NativeMethods.FreeLibrary(HooksLib);
            return HResult.S_OK; 
        }

        int ICorProfilerCallback.ModuleLoadFinished(ulong moduleId, int hrStatus)
        {
            Console.WriteLine($"ICorProfilerCallback!ModuleLoadFinished(0x{moduleId:X8})");

            var pbBaseLoadAddr = (byte*)null;
            uint pcchName = 0;
            ulong assemblyId = 0;
            var szName = (ushort*)NativeMemory.Alloc(sizeof(ushort) * 300);

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
                return HResult.E_FAIL;
            }

            var module = Marshal.PtrToStringUni((nint)szName);

            Console.WriteLine($"Loaded Moudle -> '{module}'");

            NativeMemory.Free(szName);

            return HResult.S_OK;
        }
    }
}
