using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace CorProf.Bindings
{
    public partial struct COR_PRF_FUNCTION_ARGUMENT_INFO
    {
        [NativeTypeName("ULONG")]
        public uint numRanges;

        [NativeTypeName("ULONG")]
        public uint totalArgumentSize;

        [NativeTypeName("COR_PRF_FUNCTION_ARGUMENT_RANGE[1]")]
        public _ranges_e__FixedBuffer ranges;

        public partial struct _ranges_e__FixedBuffer
        {
            public COR_PRF_FUNCTION_ARGUMENT_RANGE e0;

            [UnscopedRef]
            public ref COR_PRF_FUNCTION_ARGUMENT_RANGE this[int index]
            {
                get
                {
                    return ref AsSpan(int.MaxValue)[index];
                }
            }

            [UnscopedRef]
            public Span<COR_PRF_FUNCTION_ARGUMENT_RANGE> AsSpan(int length) => MemoryMarshal.CreateSpan(ref e0, length);
        }
    }
}
