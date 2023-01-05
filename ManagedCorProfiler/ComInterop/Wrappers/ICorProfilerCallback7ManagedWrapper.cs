using CorProf.Bindings;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.ComWrappers;
using ICorProfilerCallback7 = ManagedCorProfiler.ComInterop.Interfaces.ICorProfilerCallback7;

namespace ManagedCorProfiler.ComInterop.Wrappers
{
    public unsafe static class ICorProfilerCallback7ManagedWrapper
    {
        [UnmanagedCallersOnly]
        public static unsafe int ModuleInMemorySymbolsUpdated(IntPtr _this, ulong moduleId)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback7>((ComInterfaceDispatch*)_this)
                    .ModuleInMemorySymbolsUpdated(moduleId);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }
    }
}
