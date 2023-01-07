using CorProf.Bindings;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.ComWrappers;
using ICorProfilerCallback3 = CorProf.Core.Interfaces.ICorProfilerCallback3;

namespace ManagedCorProfiler.ComInterop.Wrappers
{
    public unsafe static class ICorProfilerCallback3ManagedWrapper
    {
        [UnmanagedCallersOnly]
        public static unsafe int InitializeForAttach(IntPtr _this, IUnknown* pCorProfilerInfoUnk, void* pvClientData, uint cbClientData)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback3>((ComInterfaceDispatch*)_this)
                    .InitializeForAttach(pCorProfilerInfoUnk, pvClientData, cbClientData);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }
        [UnmanagedCallersOnly]
        public static unsafe int ProfilerAttachComplete(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback3>((ComInterfaceDispatch*)_this)
                    .ProfilerAttachComplete();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }
        [UnmanagedCallersOnly]
        public static unsafe int ProfilerDetachSucceeded(IntPtr _this)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback3>((ComInterfaceDispatch*)_this)
                    .ProfilerDetachSucceeded();

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }

        public readonly static uint VtblCount = 83;
        public static void InitVtable(IntPtr* vtable)
        {

            ICorProfilerCallbackManagedWrapper.InitVtable(vtable);
            ICorProfilerCallback2ManagedWrapper.InitVtable(vtable);

            vtable[80] = (IntPtr)(delegate* unmanaged<IntPtr, IUnknown*, void*, uint, int>)&InitializeForAttach;
            vtable[81] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ProfilerAttachComplete;
            vtable[82] = (IntPtr)(delegate* unmanaged<IntPtr, int>)&ProfilerDetachSucceeded;
        }
    }
}
