using CorProf.Bindings;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.ComWrappers;
using ICorProfilerCallback6 = ManagedCorProfiler.ComInterop.Interfaces.ICorProfilerCallback6;

namespace ManagedCorProfiler.ComInterop.Wrappers
{
    public unsafe static class ICorProfilerCallback6ManagedWrapper
    {
        [UnmanagedCallersOnly]
        public static unsafe int GetAssemblyReferences(IntPtr _this, ushort* wszAssemblyPath, ICorProfilerAssemblyReferenceProvider* pAsmRefProvider)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback6>((ComInterfaceDispatch*)_this)
                    .GetAssemblyReferences(wszAssemblyPath, pAsmRefProvider);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }


        public readonly static uint VtblCount = 91;
        public static void InitVtable(IntPtr* vtable)
        {

            ICorProfilerCallbackManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback2ManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback3ManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback4ManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback5ManagedWrapper.InitVtable(vtable);

            vtable[90] = (IntPtr)(delegate* unmanaged<IntPtr, ushort*, ICorProfilerAssemblyReferenceProvider*, int>)&GetAssemblyReferences;
        }
    }
}
