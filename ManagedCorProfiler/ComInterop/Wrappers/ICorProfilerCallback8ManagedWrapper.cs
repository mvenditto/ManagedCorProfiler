using CorProf.Bindings;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.ComWrappers;
using ICorProfilerCallback8 = ManagedCorProfiler.ComInterop.Interfaces.ICorProfilerCallback8;

namespace ManagedCorProfiler.ComInterop.Wrappers
{
    public unsafe static class ICorProfilerCallback8ManagedWrapper
    {
        [UnmanagedCallersOnly]
        public static unsafe int DynamicMethodJITCompilationStarted(IntPtr _this, ulong functionId, int fIsSafeToBlock, byte* pILHeader, uint cbILHeader)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback8>((ComInterfaceDispatch*)_this)
                    .DynamicMethodJITCompilationStarted(functionId, fIsSafeToBlock, pILHeader, cbILHeader);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }
        [UnmanagedCallersOnly]
        public static unsafe int DynamicMethodJITCompilationFinished(IntPtr _this, ulong functionId, int hrStatus, int fIsSafeToBlock)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback8>((ComInterfaceDispatch*)_this)
                    .DynamicMethodJITCompilationFinished(functionId, hrStatus, fIsSafeToBlock);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }
    }
}
