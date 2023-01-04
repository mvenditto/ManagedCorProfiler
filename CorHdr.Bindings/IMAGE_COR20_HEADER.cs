using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    public partial struct IMAGE_COR20_HEADER
    {
        [NativeTypeName("uint32_t")]
        public uint cb;

        [NativeTypeName("uint16_t")]
        public ushort MajorRuntimeVersion;

        [NativeTypeName("uint16_t")]
        public ushort MinorRuntimeVersion;

        [NativeTypeName("IMAGE_DATA_DIRECTORY")]
        public _IMAGE_DATA_DIRECTORY MetaData;

        [NativeTypeName("uint32_t")]
        public uint Flags;

        [NativeTypeName("IMAGE_COR20_HEADER::(anonymous union at ./include/corhdr.h:224:5)")]
        public _Anonymous_e__Union Anonymous;

        [NativeTypeName("IMAGE_DATA_DIRECTORY")]
        public _IMAGE_DATA_DIRECTORY Resources;

        [NativeTypeName("IMAGE_DATA_DIRECTORY")]
        public _IMAGE_DATA_DIRECTORY StrongNameSignature;

        [NativeTypeName("IMAGE_DATA_DIRECTORY")]
        public _IMAGE_DATA_DIRECTORY CodeManagerTable;

        [NativeTypeName("IMAGE_DATA_DIRECTORY")]
        public _IMAGE_DATA_DIRECTORY VTableFixups;

        [NativeTypeName("IMAGE_DATA_DIRECTORY")]
        public _IMAGE_DATA_DIRECTORY ExportAddressTableJumps;

        [NativeTypeName("IMAGE_DATA_DIRECTORY")]
        public _IMAGE_DATA_DIRECTORY ManagedNativeHeader;

        [UnscopedRef]
        public ref uint EntryPointToken
        {
            get
            {
                return ref Anonymous.EntryPointToken;
            }
        }

        [UnscopedRef]
        public ref uint EntryPointRVA
        {
            get
            {
                return ref Anonymous.EntryPointRVA;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("uint32_t")]
            public uint EntryPointToken;

            [FieldOffset(0)]
            [NativeTypeName("uint32_t")]
            public uint EntryPointRVA;
        }
    }
}
