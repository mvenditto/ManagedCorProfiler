using CorProf.Bindings;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.ComWrappers;
using ICorProfilerCallback7 = CorProf.Core.Interfaces.ICorProfilerCallback7;

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


        public readonly static uint VtblCount = 92;
        public static void InitVtable(IntPtr* vtable)
        {

            ICorProfilerCallbackManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback2ManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback3ManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback4ManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback5ManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback6ManagedWrapper.InitVtable(vtable);

            vtable[91] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&ModuleInMemorySymbolsUpdated;
        }
    }
}
