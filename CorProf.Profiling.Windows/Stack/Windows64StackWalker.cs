using CorProf.Bindings;
using CorProf.Profiling.Abstractions;
using CorProf.Profiling.Threading;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.System.Diagnostics.Debug;


namespace CorProf.Profiling.Windows64.Stack;

public unsafe partial class Windows64StackWalker : IStackCrawler, IDisposable
{
    private readonly ICorProfilerInfo4* _profilerInfo;
    private readonly Windows64ThreadManager _threadManager;

    private HANDLE _osThreadHandle;
    private CONTEXT* _threadContext;
    private UNWIND_HISTORY_TABLE* _unwindHistoryTable;
    private readonly ulong[] _framePointers = new ulong[2048]; 
    private int _framePointerIndex = 0;

    public Windows64StackWalker(
        Windows64ThreadManager threadManager,
        ManagedThreadInfo threadInfo,
        ICorProfilerInfo4* profilerInfo)
    {
        _threadManager = threadManager;

        if (profilerInfo != null)
        {
            _profilerInfo = profilerInfo;
            _profilerInfo->AddRef();
        }

        Initialize(threadInfo);
    }

    private unsafe void Initialize(ManagedThreadInfo threadInfo)
    {
        // target thread handle
        _osThreadHandle = new HANDLE(threadInfo.OSThreadHandle);

        // thread context
        _threadContext = (CONTEXT*)NativeMemory.AlignedAlloc((nuint)sizeof(CONTEXT), 16);
        _threadContext->ContextFlags = CONTEXT_FLAGS.CONTEXT_FULL_AMD64;

        // unwind history table
        _unwindHistoryTable =  (UNWIND_HISTORY_TABLE*)NativeMemory.Alloc((nuint)sizeof(UNWIND_HISTORY_TABLE));
    }

    [DllImport("KERNEL32.dll", EntryPoint = "RtlZeroMemory")]
    private static unsafe extern BOOL RtlZeroMemory(void* destination, nuint length);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int IsFramePointerInsideStackBounds(ulong stackPointer, ulong stackBase, ulong stackLimit)
    {
        // check if the pointer is aligned
        if ((stackPointer & 0x7) != 0)
        {
            return 5;
        }

        // check if the pointer is in the stack bounds (the stack grows downwards on x64)
        if (stackPointer < stackLimit || stackPointer > stackBase)
        {
            File.WriteAllText("C:\\tmp\\test.txt", $"{stackPointer} < {stackLimit} || {stackPointer} > {stackBase}");
            // this may not be valid for kernel frames since the kernel stack can be expanded.
            return 6;
        }


        return 0;
    }

    public Span<ulong> Frames => _framePointers[0.._framePointerIndex];

    public int Unwind()
    {
        if(!PInvoke.GetThreadContext(_osThreadHandle, _threadContext)) // TODO
        {
            return 1;
        }

        // Retrieve the thread's stack limits
        var stackBase = 0UL;
        var stackLimit = 0UL;

        if (!_threadManager.GetThreadStackLimits(ref _osThreadHandle, ref stackLimit, ref stackBase))
        {
            return 2;
        }

        // Initialize the unwind history table
        if (!RtlZeroMemory(_unwindHistoryTable, (nuint)sizeof(UNWIND_HISTORY_TABLE)))
        {
            return 3;
        }

        _unwindHistoryTable->Search = 1; // TRUE
        _unwindHistoryTable->Count = 0;

        ulong imageBaseAddress = 0;
        ulong establisherFrame = 0;
        void* handlerData = null;

        KNONVOLATILE_CONTEXT_POINTERS contextPointers = default;
        void* exceptionRoutine = null;

        do
        {
            _framePointers[_framePointerIndex++] = _threadContext->Rip;
            // Lookup the function table entry using the point at which control left the procedure
            // TODO: RtlLookupFunctionEntry may try to acquire locks, we need to handle that case to avoid
            // deadlocks.
            IMAGE_RUNTIME_FUNCTION_ENTRY* functionEntry = PInvoke.RtlLookupFunctionEntry(
                _threadContext->Rip,
                &imageBaseAddress,
                _unwindHistoryTable);

            if (functionEntry == null)
            {
                // Set the point where control left the current function by
                // obtaining the return address from the top of the stack.
                _threadContext->Rip = *((ulong*)_threadContext->Rsp);
                // Perform a virtual stack pop adding 8 bytes (64 bit, pointer size on x64) to RSP.
                // NOTE: the stack grows downwards on x64.
                _threadContext->Rsp += 8;
            }
            else
            {
                // If there is a function table entry for the routine, then virtually
                // unwind to the caller of the current routine to obtain the virtual
                // frame pointer of the establisher and check if there is an exception
                // handler for the frame.
                // TODO: RtlVirtualUnwind may try to acquire locks, we need to handle that case to avoid
                _ = PInvoke.RtlVirtualUnwind(
                    RTL_VIRTUAL_UNWIND_HANDLER_TYPE.UNW_FLAG_NHANDLER, // The function has no handler
                    imageBaseAddress,
                    _threadContext->Rip,
                    *functionEntry,
                    ref *_threadContext,
                    out handlerData,
                    out establisherFrame,
                    &contextPointers);

                // validate pointer
                var pointerValid = IsFramePointerInsideStackBounds(_threadContext->Rsp, stackBase, stackLimit);
                
                if (pointerValid != 0)
                {
                    return pointerValid;
                }
            }
        }
        while (_threadContext->Rip != 0);
        
        return 0;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        if (_profilerInfo != null)
        {
            _profilerInfo->Release();
        }

        NativeMemory.Free(_unwindHistoryTable);
        NativeMemory.AlignedFree(_threadContext);
    }
}
