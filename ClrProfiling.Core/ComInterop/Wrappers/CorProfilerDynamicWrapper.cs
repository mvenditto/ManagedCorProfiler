using Microsoft.Diagnostics.Runtime.Utilities;
using System.Runtime.InteropServices;
using Windows.Win32.System.Diagnostics.ClrProfiling;

namespace ClrProfiling.ComInterop.Wrappers
{
    internal class CorProfilerDynamicWrapper : IDynamicInterfaceCastable, IDisposable
    {
        bool _isDisposed = false;

        public IntPtr ICorProfilerCallbackInst { get; init; }

        public IntPtr ICorProfilerCallback2Inst { get; init; }

        private CorProfilerDynamicWrapper() { }

        public static CorProfilerDynamicWrapper? CreateIfSupported(IntPtr ptr)
        {
            Console.WriteLine($"CALL CreateIfSupported 0x{ptr:x8}");

            var iid = ICorProfilerCallback.IID_Guid;

            int hr = Marshal.QueryInterface(ptr, ref iid, out IntPtr ICorProfilerCallbackInst);

            if (hr != HResult.S_OK)
            {
                return default;
            }

            iid = ICorProfilerCallback2.IID_Guid;
            hr = Marshal.QueryInterface(ptr, ref iid, out IntPtr ICorProfilerCallback2Inst);

            if (hr != HResult.S_OK)
            {
                Marshal.Release(ICorProfilerCallbackInst);
                return default;
            }

            return new CorProfilerDynamicWrapper()
            {
                ICorProfilerCallbackInst = ICorProfilerCallbackInst,
                ICorProfilerCallback2Inst = ICorProfilerCallback2Inst
            };
        }

        public RuntimeTypeHandle GetInterfaceImplementation(RuntimeTypeHandle interfaceType)
        {
            Console.WriteLine($"THROW GetInterfaceImplementation");
            throw new NotImplementedException();
        }

        public bool IsInterfaceImplemented(RuntimeTypeHandle interfaceType, bool throwIfNotImplemented)
        {
            Console.WriteLine($"THROW IsInterfaceImplemented");
            throw new NotImplementedException();
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
            Marshal.Release(ICorProfilerCallbackInst);
            Marshal.Release(ICorProfilerCallback2Inst);

            _isDisposed = true;
        }
    }
}
