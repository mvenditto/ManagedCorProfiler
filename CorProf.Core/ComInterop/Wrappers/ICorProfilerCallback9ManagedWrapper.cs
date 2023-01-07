using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.ComWrappers;
using ICorProfilerCallback9 = CorProf.Core.Interfaces.ICorProfilerCallback9;

namespace CorProf.ComInterop.Wrappers
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


        public readonly static uint VtblCount = 95;

        public static void InitVtable(IntPtr* vtable)
        {

            ICorProfilerCallbackManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback2ManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback3ManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback4ManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback5ManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback6ManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback7ManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback8ManagedWrapper.InitVtable(vtable);

            vtable[94] = (IntPtr)(delegate* unmanaged<IntPtr, ulong, int>)&DynamicMethodUnloaded;
        }
    }
}
