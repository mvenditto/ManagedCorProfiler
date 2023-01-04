using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    public partial struct IMAGE_COR_ILMETHOD_SECT_EH_SMALL
    {
        public IMAGE_COR_ILMETHOD_SECT_SMALL SectSmall;

        [NativeTypeName("uint16_t")]
        public ushort Reserved;

        [NativeTypeName("IMAGE_COR_ILMETHOD_SECT_EH_CLAUSE_SMALL[1]")]
        public _Clauses_e__FixedBuffer Clauses;

        public partial struct _Clauses_e__FixedBuffer
        {
            public IMAGE_COR_ILMETHOD_SECT_EH_CLAUSE_SMALL e0;

            [UnscopedRef]
            public ref IMAGE_COR_ILMETHOD_SECT_EH_CLAUSE_SMALL this[int index]
            {
                get
                {
                    return ref AsSpan(int.MaxValue)[index];
                }
            }

            [UnscopedRef]
            public Span<IMAGE_COR_ILMETHOD_SECT_EH_CLAUSE_SMALL> AsSpan(int length) => MemoryMarshal.CreateSpan(ref e0, length);
        }
    }
}
