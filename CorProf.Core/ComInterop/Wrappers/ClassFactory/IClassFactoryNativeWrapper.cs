using Microsoft.Diagnostics.Runtime.Utilities;
using System.Runtime.InteropServices;

namespace ManagedCorProfiler.ComInterop.Wrappers
{
    /// <summary>
    /// managed --> native
    /// </summary>
    [DynamicInterfaceCastableImplementation]
    internal unsafe interface IClassFactoryNativeWrapper : IClassFactory
    {
        public static new unsafe int CreateInstance(nint outer, Guid* guid, nint* instance)
        {
            throw new NotImplementedException();
        }

        public static new int LockServers(bool @lock)
        {
            throw new NotImplementedException();
        }
    }
}
