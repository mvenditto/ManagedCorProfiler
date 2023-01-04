using CorProf.Bindings;
using ManagedCorProfiler.ComInterop.Interfaces;
using Microsoft.Diagnostics.Runtime.Utilities;
using System.Runtime.InteropServices;

namespace ManagedCorProfiler.ComInterop.Wrappers
{
    internal class CorProfilerDynamicWrapper : IDynamicInterfaceCastable, IDisposable
    {
        bool _isDisposed = false;

        public IntPtr ICorProfilerCallbackInst { get; init; }
        public IntPtr ICorProfilerCallback2Inst { get; init; }

        private CorProfilerDynamicWrapper() { }

        public static CorProfilerDynamicWrapper? CreateIfSupported(IntPtr ptr)
        {
            var iid = CorProfConsts.IID_ICorProfilerCallback;
            int hr = Marshal.QueryInterface(ptr, ref iid, out IntPtr ICorProfilerCallbackInst);

            if (hr != HResult.S_OK)
            {
                return default;
            }

            iid = CorProfConsts.IID_ICorProfilerCallback2;
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
            throw new NotImplementedException();

            /*
            if (interfaceType.Equals(typeof(ICorProfilerCallback).TypeHandle))
            {
                return typeof(IDemoGetTypeNativeWrapper).TypeHandle;
            }
            else if (interfaceType.Equals(typeof(ICorProfilerCallback2).TypeHandle))
            {
                return typeof(IDemoStoreTypeNativeWrapper).TypeHandle;
            }
            */

            return default;
        }

        public bool IsInterfaceImplemented(RuntimeTypeHandle interfaceType, bool throwIfNotImplemented)
        {
            if (interfaceType.Equals(typeof(Guids).TypeHandle)
                || interfaceType.Equals(typeof(Guids).TypeHandle))
            {
                return true;
            }

            if (throwIfNotImplemented)
                throw new InvalidCastException($"{nameof(CorProfilerDynamicWrapper)} doesn't support {interfaceType}");

            return false;
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
