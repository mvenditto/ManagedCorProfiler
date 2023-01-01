using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorProfiler.ComInterop.Wrappers
{
    sealed unsafe class ClassFactoryComWrappers : ComWrappers
    {
        /* function pointers to be called by the native side */
        static readonly IntPtr s_ClassFactoryCreateInstanceVtbl;
        static readonly IntPtr s_ClassFactoryLockServersVtbl;

        /* vtable definition */
        static readonly ComInterfaceEntry* s_ClassFactoryImplDefinition; // vtable pointer
        static readonly int s_ClassFactoryImplDefinitionLen; // num func pointers in the vtable

        readonly delegate*<IntPtr, object?> _createIfSupported;

        public ClassFactoryComWrappers(bool useDynamicNativeWrapper = false)
        {
            // Determine which wrapper create function to use.
            /*_createIfSupported = useDynamicNativeWrapper
                ? &ABI.DemoNativeDynamicWrapper.CreateIfSupported
                : &ABI.DemoNativeStaticWrapper.CreateIfSupported;*/

            _createIfSupported = &IClassFactoryStaticWrapper.CreateIfSupported;
        }

        /// <summary>
        /// Preallocate COM artifacts to avoid penalty during wrapper creation.
        /// </summary>
        static ClassFactoryComWrappers()
        {
            // Get system provided IUnknown implementation.
            GetIUnknownImpl(
                out IntPtr fpQueryInterface,
                out IntPtr fpAddRef,
                out IntPtr fpRelease);

            // Construct VTable(s) for supported interface(s)
            {
                int tableCount = 5;

                int idx = 0;

                var vtable = (IntPtr*)RuntimeHelpers.AllocateTypeAssociatedMemory(
                    typeof(ClassFactoryComWrappers),
                    IntPtr.Size * tableCount);

                // IUnknown
                vtable[idx++] = fpQueryInterface;
                vtable[idx++] = fpAddRef;
                vtable[idx++] = fpRelease;

                // IClassFactory
                vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, IntPtr, Guid*, IntPtr*, int>)&IClassFactoryManagedWrapper.CreateInstance;
                vtable[idx++] = (IntPtr)(delegate* unmanaged<IntPtr, bool, int>)&IClassFactoryManagedWrapper.LockServer;

                Debug.Assert(tableCount == idx);
                s_ClassFactoryCreateInstanceVtbl = (IntPtr)vtable;
            }

            // Construct entries for supported managed types
            {
                s_ClassFactoryImplDefinitionLen = 1;
                int idx = 0;
                var entries = (ComInterfaceEntry*)RuntimeHelpers.AllocateTypeAssociatedMemory(
                    typeof(ClassFactoryComWrappers),
                    sizeof(ComInterfaceEntry) * s_ClassFactoryImplDefinitionLen);
                entries[idx].IID = IClassFactory.IID_IClassFactory;
                entries[idx++].Vtable = s_ClassFactoryCreateInstanceVtbl;
                Debug.Assert(s_ClassFactoryImplDefinitionLen == idx);
                s_ClassFactoryImplDefinition = entries;
            }
        }

        protected override unsafe ComInterfaceEntry* ComputeVtables(object obj, CreateComInterfaceFlags flags, out int count)
        {
            Debug.Assert(flags is CreateComInterfaceFlags.None);

            if (obj is ClassFactoryImpl)
            {
                count = s_ClassFactoryImplDefinitionLen;
                return s_ClassFactoryImplDefinition;
            }

            // Note: this implementation does not handle cases where the passed in object implements
            // one or both of the supported interfaces but is not the expected .NET class.
            count = 0;

            return null;
        }

        protected override object? CreateObject(nint externalComObject, CreateObjectFlags flags)
        {
            // Assert use of the UniqueInstance flag since the returned Native Object Wrapper always
            // supports IDisposable and its Dispose will always release and suppress finalization.
            // If the wrapper doesn't always support IDisposable the assert can be relaxed.
            Debug.Assert(flags.HasFlag(CreateObjectFlags.UniqueInstance));

            // Throw an exception if the type is not supported by the implementation.
            // Null can be returned as well, but an ArgumentNullException will be thrown for
            // the consumer of this ComWrappers instance.
            return _createIfSupported(externalComObject) ?? throw new NotSupportedException();
        }

        protected override void ReleaseObjects(IEnumerable objects)
        {
            throw new NotImplementedException();
        }
    }
}
