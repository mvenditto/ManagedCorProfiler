using ManagedCorProfiler.ComInterop.Interfaces;
using ManagedCorProfiler.Utilities;
using Microsoft.Diagnostics.Runtime.Utilities;
using System.Runtime.InteropServices;

namespace ManagedCorProfiler.ComInterop.Impl
{
    internal unsafe class MyProfiler: ICorProfilerCallback2
    {
        private ICorProfilerInfo2* _profilerInfo;

        int ICorProfilerCallback.Initialize(IUnknown* unknown)
        {
            Console.Write("MyProfiler!Initialize");

            var guid_ = Guids.IID_ICorProfilerInfo2;

            var hr = Marshal.QueryInterface((nint)unknown, ref guid_, out var pinfo);

            Console.WriteLine($"ICorProfilerCallback!Initialize(): profInfo {pinfo:X8}");

            if (hr < 0)
            {
                Console.WriteLine($"Error hr={hr}");
                return HResult.E_FAIL;
            }

            var eventMask = COR_PRF_MONITOR.COR_PRF_MONITOR_MODULE_LOADS
                 | COR_PRF_MONITOR.COR_PRF_MONITOR_ASSEMBLY_LOADS
                 | COR_PRF_MONITOR.COR_PRF_MONITOR_CLASS_LOADS;

            _profilerInfo = (ICorProfilerInfo2*) pinfo;

            hr = _profilerInfo->SetEventMask((uint)eventMask);

            if (hr < 0)
            {
                Console.WriteLine($"Error hr={hr}");
                return HResult.E_FAIL;
            }

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
