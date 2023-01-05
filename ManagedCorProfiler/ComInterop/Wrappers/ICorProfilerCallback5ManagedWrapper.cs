using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.ComWrappers;
using ICorProfilerCallback5 = ManagedCorProfiler.ComInterop.Interfaces.ICorProfilerCallback5;

namespace ManagedCorProfiler.ComInterop.Wrappers
{
    public unsafe static class ICorProfilerCallback5ManagedWrapper
    {
        [UnmanagedCallersOnly]
        public static unsafe int ConditionalWeakTableElementReferences(IntPtr _this, uint cRootRefs, ulong* keyRefIds, ulong* valueRefIds, ulong* rootIds)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback5>((ComInterfaceDispatch*)_this)
                    .ConditionalWeakTableElementReferences(cRootRefs, keyRefIds, valueRefIds, rootIds);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }
    }
}
