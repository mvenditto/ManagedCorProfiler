using System.Collections;
using System.Collections.Frozen;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.System.Com;
using Windows.Win32.System.Diagnostics.ClrProfiling;

namespace Windows.Win32
{
    static unsafe partial class ComHelpers
    {
        static partial void PopulateIUnknownImpl<TComInterface>(IUnknown.Vtbl* vtable) where TComInterface : unmanaged
        {
            Console.WriteLine($"PopulateIUnknownImpl -> {typeof(TComInterface)}");

            // Get system provided IUnknown implementation.
            ComWrappers.GetIUnknownImpl(
                out IntPtr fpQueryInterface,
                out IntPtr fpAddRef,
                out IntPtr fpRelease);

            // IUnknown
            vtable->QueryInterface_1 = (delegate* unmanaged[Stdcall]<IUnknown*, Guid*, void**, Foundation.HRESULT>)fpQueryInterface;
            vtable->AddRef_2 = (delegate* unmanaged[Stdcall]<IUnknown*, uint>)fpAddRef;
            vtable->Release_3 = (delegate* unmanaged[Stdcall]<IUnknown*, uint>)fpRelease;
        }
    }
}

namespace ClrProfiling.ComInterop.Wrappers
{
    internal unsafe class CorProfilerComWrappers : ComWrappers
    {
        readonly delegate*<IntPtr, object?> _createIfSupported;

        public CorProfilerComWrappers()
        {
            _createIfSupported = &CorProfilerDynamicWrapper.CreateIfSupported;

            Console.WriteLine("CTOR CorProfilerComWrappers");
        }

        private static nint GetICorProfilerCallbackVTable()
        {
            return (nint)get_ICorProfilerCallbackVTable(null);

            [UnsafeAccessor(UnsafeAccessorKind.StaticMethod, Name = "CreateVTable")]
            static extern ICorProfilerCallback.Vtbl* get_ICorProfilerCallbackVTable(IVTable<ICorProfilerCallback, ICorProfilerCallback.Vtbl> c);
        }

        private static nint GetICorProfilerCallback2VTable()
        {
            return (nint)get_ICorProfilerCallback2VTable(null);

            [UnsafeAccessor(UnsafeAccessorKind.StaticMethod, Name = "CreateVTable")]
            static extern ICorProfilerCallback2.Vtbl* get_ICorProfilerCallback2VTable(IVTable<ICorProfilerCallback2, ICorProfilerCallback2.Vtbl> c);
        }

        private static nint GetICorProfilerCallback3VTable()
        {
            return (nint)get_ICorProfilerCallback3VTable(null);

            [UnsafeAccessor(UnsafeAccessorKind.StaticMethod, Name = "CreateVTable")]
            static extern IUnknown.Vtbl* get_ICorProfilerCallback3VTable(IVTable<ICorProfilerCallback3, ICorProfilerCallback3.Vtbl> c);
        }

        private static nint GetICorProfilerCallback4VTable()
        {
            return (nint)get_ICorProfilerCallback4VTable(null);

            [UnsafeAccessor(UnsafeAccessorKind.StaticMethod, Name = "CreateVTable")]
            static extern IUnknown.Vtbl* get_ICorProfilerCallback4VTable(IVTable<ICorProfilerCallback4, ICorProfilerCallback4.Vtbl> c);
        }

        private static nint GetICorProfilerCallback5VTable()
        {
            return (nint)get_ICorProfilerCallback5VTable(null);

            [UnsafeAccessor(UnsafeAccessorKind.StaticMethod, Name = "CreateVTable")]
            static extern IUnknown.Vtbl* get_ICorProfilerCallback5VTable(IVTable<ICorProfilerCallback5, ICorProfilerCallback5.Vtbl> c);
        }

        private static nint GetICorProfilerCallback6VTable()
        {
            return (nint)get_ICorProfilerCallback6VTable(null);

            [UnsafeAccessor(UnsafeAccessorKind.StaticMethod, Name = "CreateVTable")]
            static extern IUnknown.Vtbl* get_ICorProfilerCallback6VTable(IVTable<ICorProfilerCallback6, ICorProfilerCallback6.Vtbl> c);
        }

        private static nint GetICorProfilerCallback7VTable()
        {
            return (nint)get_ICorProfilerCallback7VTable(null);

            [UnsafeAccessor(UnsafeAccessorKind.StaticMethod, Name = "CreateVTable")]
            static extern IUnknown.Vtbl* get_ICorProfilerCallback7VTable(IVTable<ICorProfilerCallback7, ICorProfilerCallback7.Vtbl> c);
        }

        private static nint GetICorProfilerCallback8VTable()
        {
            return (nint)get_ICorProfilerCallback8VTable(null);

            [UnsafeAccessor(UnsafeAccessorKind.StaticMethod, Name = "CreateVTable")]
            static extern IUnknown.Vtbl* get_ICorProfilerCallback8VTable(IVTable<ICorProfilerCallback8, ICorProfilerCallback8.Vtbl> c);
        }

        private static nint GetICorProfilerCallback9VTable()
        {
            return (nint)get_ICorProfilerCallback9VTable(null);

            [UnsafeAccessor(UnsafeAccessorKind.StaticMethod, Name = "CreateVTable")]
            static extern IUnknown.Vtbl* get_ICorProfilerCallback9VTable(IVTable<ICorProfilerCallback9, ICorProfilerCallback9.Vtbl> c);
        }

        private readonly static FrozenDictionary<Type, Func<nint>> ICorProfilerCallbackVTableFactoryMap = new Dictionary<Type, Func<nint>>
        {
            [typeof(ICorProfilerCallback.Interface)] = GetICorProfilerCallbackVTable,
            [typeof(ICorProfilerCallback2.Interface)] = GetICorProfilerCallback2VTable,
            [typeof(ICorProfilerCallback3.Interface)] = GetICorProfilerCallback3VTable,
            [typeof(ICorProfilerCallback4.Interface)] = GetICorProfilerCallback4VTable,
            [typeof(ICorProfilerCallback5.Interface)] = GetICorProfilerCallback5VTable,
            [typeof(ICorProfilerCallback6.Interface)] = GetICorProfilerCallback6VTable,
            [typeof(ICorProfilerCallback7.Interface)] = GetICorProfilerCallback7VTable,
            [typeof(ICorProfilerCallback8.Interface)] = GetICorProfilerCallback8VTable,
            [typeof(ICorProfilerCallback9.Interface)] = GetICorProfilerCallback9VTable,
        }.ToFrozenDictionary();

        private readonly static FrozenDictionary<Type, Guid> ICorProfilerCallbackIIDMap = new Dictionary<Type, Guid>
        {
            [typeof(ICorProfilerCallback.Interface)] = ICorProfilerCallback.IID_Guid,
            [typeof(ICorProfilerCallback2.Interface)] = ICorProfilerCallback2.IID_Guid,
            [typeof(ICorProfilerCallback3.Interface)] = ICorProfilerCallback3.IID_Guid,
            [typeof(ICorProfilerCallback4.Interface)] = ICorProfilerCallback4.IID_Guid,
            [typeof(ICorProfilerCallback5.Interface)] = ICorProfilerCallback5.IID_Guid,
            [typeof(ICorProfilerCallback6.Interface)] = ICorProfilerCallback6.IID_Guid,
            [typeof(ICorProfilerCallback7.Interface)] = ICorProfilerCallback7.IID_Guid,
            [typeof(ICorProfilerCallback8.Interface)] = ICorProfilerCallback8.IID_Guid,
            [typeof(ICorProfilerCallback9.Interface)] = ICorProfilerCallback9.IID_Guid,
        }.ToFrozenDictionary();

        private const string ICorProfilerCallbackPrefix = "ICorProfilerCallback";
        private const string Interface = "Interface";

        private readonly static FrozenSet<Type> ICorProfilerCallbackInterfaces = new HashSet<Type>
        {
            typeof(ICorProfilerCallback.Interface),
            typeof(ICorProfilerCallback2.Interface),
            typeof(ICorProfilerCallback3.Interface),
            typeof(ICorProfilerCallback4.Interface),
            typeof(ICorProfilerCallback5.Interface),
            typeof(ICorProfilerCallback6.Interface),
            typeof(ICorProfilerCallback7.Interface),
            typeof(ICorProfilerCallback8.Interface),
            typeof(ICorProfilerCallback9.Interface),
        }.ToFrozenSet();
        
        protected override unsafe ComInterfaceEntry* ComputeVtables(object obj, CreateComInterfaceFlags flags, out int count)
        {
            Console.WriteLine($"CALL ComputeVtables {obj.GetType()}");

            Debug.Assert(flags is CreateComInterfaceFlags.None);

            var profilerCallbackIfaces = obj
                .GetType()
                .GetInterfaces()
                .Where(ICorProfilerCallbackInterfaces.Contains)
                .ToArray();

            Console.WriteLine($"Found {profilerCallbackIfaces.Length} ICorProfilerCallbackX interfaces.");

            foreach(var i in profilerCallbackIfaces)
            {
                Console.WriteLine($"IFACE {i.FullName}");
            }

            if (profilerCallbackIfaces.Length == 0)
            {
                throw new InvalidOperationException($"no ICorProfilerCallbackX interface found for type '{obj.GetType().FullName}'");
            }

            var implDefinitionLen = profilerCallbackIfaces.Length;

            Console.WriteLine($"Creating ComInterfaceEntry for {implDefinitionLen} implementations.");

            var implDef = (ComInterfaceEntry*)RuntimeHelpers.AllocateTypeAssociatedMemory(
                    typeof(CorProfilerComWrappers),
                    sizeof(ComInterfaceEntry) * implDefinitionLen);

            var idx = 0;

            for (var i = 0; i < implDefinitionLen; i++)
            {
                var iface = profilerCallbackIfaces[i];

                Console.WriteLine($"INIT impl {i} idx={idx} iface={iface.FullName}");

                implDef[idx].IID = ICorProfilerCallbackIIDMap[iface];

                Console.WriteLine($"INIT impl IID {iface.FullName} -> {implDef[idx].IID}");

                try
                {
                    implDef[idx++].Vtable = ICorProfilerCallbackVTableFactoryMap[iface]();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to pupulate the Vtable: {ex}");
                }

                Console.WriteLine($"INIT impl VTABLE{iface.FullName} -> 0x{implDef[idx].Vtable}:x8");
            }

            count = implDefinitionLen;

            return implDef;
        }

        protected override object? CreateObject(nint externalComObject, CreateObjectFlags flags)
        {
            Console.WriteLine($"CALL CreateObject 0x{externalComObject:x8}");

            Debug.Assert(flags.HasFlag(CreateObjectFlags.UniqueInstance));

            // Throw an exception if the type is not supported by the implementation.
            // Null can be returned as well, but an ArgumentNullException will be thrown for
            // the consumer of this ComWrappers instance.
            return _createIfSupported(externalComObject) ?? throw new NotSupportedException();
        }

        protected override void ReleaseObjects(IEnumerable objects)
        {
            Console.WriteLine($"THROW ReleaseObjects");
            throw new NotImplementedException();
        }
    }
}
