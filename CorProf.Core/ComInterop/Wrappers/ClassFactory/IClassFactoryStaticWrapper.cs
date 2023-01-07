using Microsoft.Diagnostics.Runtime.Utilities;
using System.Runtime.InteropServices;

namespace CorProf.ComInterop.Wrappers
{
    internal class IClassFactoryStaticWrapper : IClassFactory
    {
        private bool _isDisposed = false;

        public IntPtr IClassFactoryInst { get; init; }

        private IClassFactoryStaticWrapper() { }

        public static IClassFactoryStaticWrapper? CreateIfSupported(IntPtr ptr)
        {
            int hr = Marshal.QueryInterface(ptr, ref IClassFactory.IID_IClassFactory, out IntPtr instance);

            if (hr != HResult.S_OK)
            {
                return default;
            }

            Console.WriteLine("CreateIfSupported");

            return new IClassFactoryStaticWrapper()
            {
                IClassFactoryInst = instance,
            };
        }

        ~IClassFactoryStaticWrapper()
        {
            DisposeInternal();
        }

        public void Dispose()
        {
            DisposeInternal();
            GC.SuppressFinalize(this);
        }

        void DisposeInternal()
        {
            if (_isDisposed)
                return;

            // [WARNING] This is unsafe for COM objects that have specific thread affinity.
            Marshal.Release(IClassFactoryInst);

            _isDisposed = true;
        }

        public unsafe int CreateInstance(nint outer, Guid* guid, nint* instance)
        {
            Console.WriteLine("CreateInstance");
            return IClassFactoryNativeWrapper.CreateInstance(outer, guid, instance);
        }

        public int LockServers(bool @lock)
        {
            Console.WriteLine("LockServers");
            return IClassFactoryNativeWrapper.LockServers(@lock);
        }
    }
}
