using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    public partial struct IMAGE_COR_ILMETHOD_SECT_EH_CLAUSE_SMALL
    {
        public int _bitfield1;

        [NativeTypeName("CorExceptionFlag : 16")]
        public CorExceptionFlag Flags
        {
            get
            {
                return (CorExceptionFlag)(_bitfield1 & 0xFFFF);
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~0xFFFF) | ((int)(value) & 0xFFFF);
            }
        }

        [NativeTypeName("unsigned int : 16")]
        public uint TryOffset
        {
            get
            {
                return (uint)((_bitfield1 >> 16) & 0xFFFF);
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0xFFFF << 16)) | (int)((value & 0xFFFFu) << 16);
            }
        }

        public uint _bitfield2;

        [NativeTypeName("unsigned int : 8")]
        public uint TryLength
        {
            get
            {
                return _bitfield2 & 0xFFu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~0xFFu) | (value & 0xFFu);
            }
        }

        [NativeTypeName("unsigned int : 16")]
        public uint HandlerOffset
        {
            get
            {
                return (_bitfield2 >> 8) & 0xFFFFu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0xFFFFu << 8)) | ((value & 0xFFFFu) << 8);
            }
        }

        [NativeTypeName("unsigned int : 8")]
        public uint HandlerLength
        {
            get
            {
                return (_bitfield2 >> 24) & 0xFFu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0xFFu << 24)) | ((value & 0xFFu) << 24);
            }
        }

        [NativeTypeName("IMAGE_COR_ILMETHOD_SECT_EH_CLAUSE_SMALL::(anonymous union at ./include/corhdr.h:1186:5)")]
        public _Anonymous_e__Union Anonymous;

        [UnscopedRef]
        public ref uint ClassToken
        {
            get
            {
                return ref Anonymous.ClassToken;
            }
        }

        [UnscopedRef]
        public ref uint FilterOffset
        {
            get
            {
                return ref Anonymous.FilterOffset;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("uint32_t")]
            public uint ClassToken;

            [FieldOffset(0)]
            [NativeTypeName("uint32_t")]
            public uint FilterOffset;
        }
    }
}
