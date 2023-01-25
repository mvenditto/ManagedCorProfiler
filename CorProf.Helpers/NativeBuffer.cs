using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CorProf.Helpers
{
    /// <summary>
     /// wraps an un-aligned block of native memory that gets freed
     /// while <see cref="NativeBuffer"/> goes out of scope or gets Disposed
     /// </summary>
    public readonly unsafe ref struct NativeBuffer
    {
        private readonly void* _address;
        private readonly nuint _byteCount;

        public readonly void* Pointer => _address;
        public readonly nuint ByteCount => _byteCount;

        public static implicit operator nint(NativeBuffer b) => (nint)b.Pointer;
        public static implicit operator void*(NativeBuffer b) => b.Pointer;

        private NativeBuffer(nuint byteCount)
        {
            _address = NativeMemory.Alloc(byteCount);
            _byteCount = byteCount;
        }
        private NativeBuffer(nuint elementCount, nuint elementSize)
        {
            _address = NativeMemory.Alloc(elementCount, elementSize);
            _byteCount = elementCount * elementSize;
        }

        public static NativeBuffer Alloc(nuint byteCount)
        {
            return new NativeBuffer(byteCount);
        }

        public static NativeBuffer Alloc(nuint elementCount, nuint elementSize)
        {
            return new NativeBuffer(elementCount, elementSize);
        }

        public void ZeroOut()
        {
            Unsafe.InitBlockUnaligned(_address, 0, (uint)_byteCount);
        }

        /// <summary>
        /// Free the underlying memory
        /// </summary>
        public void Dispose()
        {
            NativeMemory.Free(_address);
        }
    }

    /// <summary>
    /// wraps an un-aligned block of native memory that gets freed
    /// while <see cref="NativeBuffer"/> goes out of scope or gets Disposed
    /// </summary>
    public unsafe ref struct NativeBuffer<T> where T : unmanaged
    {
        private readonly T* _address;
        private readonly uint _length;
        private bool _freed = false;

        public readonly T* Pointer => _address;
        public readonly uint Length => _length;

        public static implicit operator nint(NativeBuffer<T> b) => (nint)b.Pointer;
        public static implicit operator T*(NativeBuffer<T> b) => b.Pointer;

        public T this[int index]
        {
            get
            {
                return _address[index];
            }
        }

        public T this[uint index]
        {
            get
            {
                return _address[index];
            }
        }

        private NativeBuffer(uint elementCount)
        {
            _address = (T*) NativeMemory.Alloc(elementCount, (nuint)sizeof(T));
            _length = elementCount;
        }

        public static NativeBuffer<T> Alloc(uint elementCount)
        {
            return new NativeBuffer<T>(elementCount);
        }

        public void ZeroOut()
        {
            Unsafe.InitBlockUnaligned(
                _address, 
                0, 
                (uint)(_length * sizeof(T)));
        }

        /// <summary>
        /// Free the underlying memory
        /// </summary>
        public void Dispose()
        {
            if (_freed) return;
            _freed = true;
            NativeMemory.Free(_address);
            Debug.WriteLine($"Free 0x{(nint)_address:x8} {_length * sizeof(T)}B.");
        }
    }
}
