
namespace ClrProfiling.Backend.Windows.Stack;

internal static unsafe partial class NtDllNativeMethods
{
    /*
    internal static class CONTEXT_FLAGS
    {
        public const uint CONTEXT_i386 = 0x10000;
        public const uint CONTEXT_i486 = 0x10000; //  same as i386
        public const uint CONTEXT_CONTROL = CONTEXT_i386 | 0x01; // SS:SP, CS:IP, FLAGS, BP
        public const uint CONTEXT_INTEGER = CONTEXT_i386 | 0x02; // AX, BX, CX, DX, SI, DI
        public const uint CONTEXT_SEGMENTS = CONTEXT_i386 | 0x04; // DS, ES, FS, GS
        public const uint CONTEXT_FLOATING_POINT = CONTEXT_i386 | 0x08; // 387 state
        public const uint CONTEXT_DEBUG_REGISTERS = CONTEXT_i386 | 0x10; // DB 0-3,6,7
        public const uint CONTEXT_EXTENDED_REGISTERS = CONTEXT_i386 | 0x20; // cpu specific extensions
        public const uint CONTEXT_FULL = CONTEXT_CONTROL | CONTEXT_INTEGER | CONTEXT_SEGMENTS;
        public const uint CONTEXT_ALL = CONTEXT_CONTROL | CONTEXT_INTEGER | CONTEXT_SEGMENTS | CONTEXT_FLOATING_POINT | CONTEXT_DEBUG_REGISTERS | CONTEXT_EXTENDED_REGISTERS;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 16)]
    internal struct M128A
    {
        public long Low;
        public ulong High;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 16)]
    internal struct M256
    {
        public M128A Low;
        public M128A High;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 16)]
    internal struct M512
    {
        public M256 Low;
        public M256 High;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct XMM_SAVE_AREA32
    {
        WORD ControlWord;
        WORD StatusWord;
        BYTE TagWord;
        BYTE Reserved1;
        WORD ErrorOpcode;
        DWORD ErrorOffset;
        WORD ErrorSelector;
        WORD Reserved2;
        DWORD DataOffset;
        WORD DataSelector;
        WORD Reserved3;
        DWORD MxCsr;
        DWORD MxCsr_Mask;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        M128A[] FloatRegisters;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        M128A[] XmmRegisters;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
        BYTE Reserved4;
    }

    /// <summary>
    /// x64
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 16)]
    internal struct XSAVE_FORMAT64
    {
        public ushort ControlWord;
        public ushort StatusWord;
        public byte TagWord;
        public byte Reserved1;
        public ushort ErrorOpcode;
        public uint ErrorOffset;
        public ushort ErrorSelector;
        public ushort Reserved2;
        public uint DataOffset;
        public ushort DataSelector;
        public ushort Reserved3;
        public uint MxCsr;
        public uint MxCsr_Mask;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public M128A[] FloatRegisters;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public M128A[] XmmRegisters;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
        public byte[] Reserved4;
    }

    /// <summary>
    /// x64
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 16)]
    internal struct CONTEXT
    {
        public ulong P1Home;
        public ulong P2Home;
        public ulong P3Home;
        public ulong P4Home;
        public ulong P5Home;
        public ulong P6Home;

        // Control flags.
        public DWORD ContextFlags;
        public uint MxCsr;

        // Segment Registers and processor flags.
        public ushort SegCs;
        public ushort SegDs;
        public ushort SegEs;
        public ushort SegFs;
        public ushort SegGs;
        public ushort SegSs;
        public uint EFlags;

        // Debug registers
        public ulong Dr0;
        public ulong Dr1;
        public ulong Dr2;
        public ulong Dr3;
        public ulong Dr6;
        public ulong Dr7;

        // Integer registers.
        public ulong Rax;
        public ulong Rcx;
        public ulong Rdx;
        public ulong Rbx;
        public ulong Rsp;
        public ulong Rbp;
        public ulong Rsi;
        public ulong Rdi;
        public ulong R8;
        public ulong R9;
        public ulong R10;
        public ulong R11;
        public ulong R12;
        public ulong R13;
        public ulong R14;
        public ulong R15;

        // Program counter.
        public ulong Rip;

        // Floating point state
        public XSAVE_FORMAT64 DUMMYUNIONNAME;

        // Vector registers.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 26)]
        public M128A[] VectorRegister;
        public ulong VectorControl;

        // Special debug control registers.
        public ulong DebugControl;
        public ulong LastBranchToRip;
        public ulong LastBranchFromRip;
        public ulong LastExceptionToRip;
        public ulong LastExceptionFromRip;

        // XSTATE
        public DWORD64 XStateFeaturesMask;
        public DWORD64 XStateReserved0;

        // XSTATE_AVX
        public M128A Ymm0H;
        public M128A Ymm1H;
        public M128A Ymm2H;
        public M128A Ymm3H;
        public M128A Ymm4H;
        public M128A Ymm5H;
        public M128A Ymm6H;
        public M128A Ymm7H;
        public M128A Ymm8H;
        public M128A Ymm9H;
        public M128A Ymm10H;
        public M128A Ymm11H;
        public M128A Ymm12H;
        public M128A Ymm13H;
        public M128A Ymm14H;
        public M128A Ymm15H;

        // XSTATE_AVX512_KMASK
        public DWORD64 KMask0;
        public DWORD64 KMask1;
        public DWORD64 KMask2;
        public DWORD64 KMask3;
        public DWORD64 KMask4;
        public DWORD64 KMask5;
        public DWORD64 KMask6;
        public DWORD64 KMask7;

        // XSTATE_AVX512_ZMM_H
        public M256 Zmm0H;
        public M256 Zmm1H;
        public M256 Zmm2H;
        public M256 Zmm3H;
        public M256 Zmm4H;
        public M256 Zmm5H;
        public M256 Zmm6H;
        public M256 Zmm7H;
        public M256 Zmm8H;
        public M256 Zmm9H;
        public M256 Zmm10H;
        public M256 Zmm11H;
        public M256 Zmm12H;
        public M256 Zmm13H;
        public M256 Zmm14H;
        public M256 Zmm15H;

        // XSTATE_AVX512_ZMM
        public M512 Zmm16;
        public M512 Zmm17;
        public M512 Zmm18;
        public M512 Zmm19;
        public M512 Zmm20;
        public M512 Zmm21;
        public M512 Zmm22;
        public M512 Zmm23;
        public M512 Zmm24;
        public M512 Zmm25;
        public M512 Zmm26;
        public M512 Zmm27;
        public M512 Zmm28;
        public M512 Zmm29;
        public M512 Zmm30;
        public M512 Zmm31;
    }

    [LibraryImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static unsafe partial bool GetThreadContext(
        nint threadHandle,
        CONTEXT* context);
    */
}
