using CorProf.Bindings;
using CorProf.Profiling.Abstractions;
using CorProf.Profiling.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.System.Diagnostics.Debug;
using static CorProf.Profiling.Windows64.Stack.NtDllNativeMethods;


namespace CorProf.Profiling.Windows64.Stack;


public unsafe class Windows64StackCrawler : IStackCrawler, IDisposable
{
    private readonly ILogger<Windows64StackCrawler> _logger;
    private readonly ICorProfilerInfo4* _profilerInfo;
    private readonly Windows64ThreadManager _threadManager;

    public Windows64StackCrawler(
        ILogger<Windows64StackCrawler> logger, 
        Windows64ThreadManager threadManager,
        ICorProfilerInfo4* profilerInfo)
    {
        _logger = logger ?? NullLogger<Windows64StackCrawler>.Instance;
        _threadManager = threadManager;

        if (profilerInfo != null)
        {
            _profilerInfo = profilerInfo;
            _profilerInfo->AddRef();
        }
    }

    [DllImport("KERNEL32.dll", ExactSpelling = true, EntryPoint = "RtlZeroMemory")]
    private unsafe static extern bool RtlZeroMemory(void* destination, nuint length);

    public void Crawl(ManagedThreadInfo targetThread)
    {
        var osThreadHandle = new HANDLE(targetThread.OSThreadHandle);
        
        // Retrieve the context of the target thread
        var context = (CONTEXT*)NativeMemory.AlignedAlloc((nuint)sizeof(CONTEXT), 16);
        context->ContextFlags = CONTEXT_FLAGS.CONTEXT_FULL_AMD64;
        
        if(!PInvoke.GetThreadContext(osThreadHandle, context)) // TODO
        {
            _logger.LogWarning("FAIL GetThreadContext() with hr=0x{hr:x8}", Marshal.GetLastPInvokeError());
            return;
        }

        // Retrieve the thread's stack limits
        var stackBase = 0UL;
        var stackLimit = 0UL;

        if (!_threadManager.GetThreadStackLimits(ref osThreadHandle, ref stackBase, ref stackLimit))
        {
            _logger.LogWarning("FAIL GetThreadStackLimits()");
            return;
        }

        // Initialize the unwind history table
        var unwindHistoryTable = (UNWIND_HISTORY_TABLE*)NativeMemory.Alloc((nuint)sizeof(UNWIND_HISTORY_TABLE));

        if (!RtlZeroMemory(unwindHistoryTable, (nuint)sizeof(UNWIND_HISTORY_TABLE)))
        {
            _logger.LogWarning("FAIL RtlZeroMemory()");
            return;
        }

        unwindHistoryTable->Search = 1; // TRUE

        NativeMemory.Free(unwindHistoryTable);
        NativeMemory.AlignedFree(context);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        if (_profilerInfo != null)
        {
            _profilerInfo->Release();
        }
    }
}
