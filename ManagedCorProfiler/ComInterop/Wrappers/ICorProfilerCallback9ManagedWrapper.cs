using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.ComWrappers;
using ICorProfilerCallback9 = ManagedCorProfiler.ComInterop.Interfaces.ICorProfilerCallback9;

namespace ManagedCorProfiler.ComInterop.Wrappers
{
    public unsafe static class ICorProfilerCallback9ManagedWrapper
    {
        [UnmanagedCallersOnly]
        public static unsafe int DynamicMethodUnloaded(IntPtr _this, ulong functionId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback9>((ComInterfaceDispatch*)_this)
                    .DynamicMethodUnloaded(functionId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }
    }
}
