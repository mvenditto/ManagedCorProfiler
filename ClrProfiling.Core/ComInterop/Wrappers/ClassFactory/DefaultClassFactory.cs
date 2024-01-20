using Microsoft.Diagnostics.Runtime.Utilities;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrProfiling.ComInterop.Wrappers
{
    public class DefaultClassFactory : IClassFactory
    {
        private readonly object _profiler;

        public DefaultClassFactory(object profilerInstance)
        {
            _profiler = profilerInstance;
        }

        public unsafe int CreateInstance(nint outer, Guid* guid, nint* instance)
        {
            if (outer != IntPtr.Zero)
            {
                *instance = 0;
                return -2147221232; // E_NO_AGGREGATE
            }

            var guid_ = *guid;

            var cw = new CorProfilerComWrappers();

            IntPtr ccwUnknown = cw.GetOrCreateComInterfaceForObject(
                    _profiler,
                    CreateComInterfaceFlags.None);

            var hr = Marshal.QueryInterface(ccwUnknown, ref guid_, out var ptr);

            Debug.Assert(hr == 0);

            *instance = ptr;

            return HResult.S_OK;

            // var queryInterface = (delegate* unmanaged<IntPtr, Guid*, void**, int>)&ICorProfilerCallback_.QueryInterface;
            //return queryInterface(IntPtr.Zero, guid, (void**)instance);
        }

        public int LockServers(bool @lock)
        {
            return HResult.S_OK;
        }
    }
}
