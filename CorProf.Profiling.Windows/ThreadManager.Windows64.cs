using Microsoft.Extensions.Logging;
using CorProf.Profiling.Abstractions;
using Windows.Win32;
using Windows.Win32.Foundation;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging.Abstractions;
using CorProf.Profiling.Threading;
using static CorProf.Profiling.Windows.Stack.NtDllNativeMethods;
using Microsoft.Diagnostics.Runtime.Utilities;
using Serilog;
using System.Diagnostics;
using CorProf.Bindings;

namespace CorProf.Profiling.Windows;

public class Windows64ThreadManager : IThreadManager, IDisposable
{
    private readonly ILogger<Windows64ThreadManager> _logger;
    private readonly unsafe ICorProfilerInfo4* _profilerInfo;
    
    private const uint SuspendThreadFailed = unchecked((uint)-1); // DWORD
    private const uint ResumeThreadFailed = unchecked((uint)-1); // DWORD

    public unsafe Windows64ThreadManager(ILogger<Windows64ThreadManager> logger, ICorProfilerInfo4* profilerInfo)
    {
        _logger = logger ?? NullLogger<Windows64ThreadManager>.Instance;

        if (profilerInfo != null)
        {
            profilerInfo->AddRef();
            _profilerInfo = profilerInfo;
        }
    }

    public unsafe nint GetThreadHandle(ulong managedThreadId)
    {
        var osThreadHandle = IntPtr.Zero;

        var hr = _profilerInfo->GetHandleFromThread(managedThreadId, (void**)&osThreadHandle);

        if (hr != HResult.S_OK)
        {
            _logger.LogWarning("FAIL GetHandleFromThread() with hr=0x{hr:x8}", hr);
            return hr;
        }

        _logger.LogDebug("GetHandleFromThread -> 0x{OsThreadHandle:x8}", osThreadHandle);

        var currProcess = Process.GetCurrentProcess();
        var processHandle = new HANDLE(currProcess.Handle);
        var threadHandle = new HANDLE(osThreadHandle);

        const uint THREAD_ALL_ACCESS = 0x1FFFFF;
        const DUPLICATE_HANDLE_OPTIONS DefaultDuplicateHandleOpts = 0;

        var realThreadHandle = HANDLE.Null;

        // acquire a real handle instead of a pseudo-handle.
        hr = PInvoke.DuplicateHandle(
            processHandle,
            threadHandle,
            processHandle,
            &realThreadHandle,
            THREAD_ALL_ACCESS,
            false,
            DefaultDuplicateHandleOpts
        );

        if (hr <= HResult.S_OK)
        {
            Log.Logger.Warning("FAIL Kernel32::DuplicateHandle() with hr=0x{hr:x8}", hr);
            return hr;
        }

        return realThreadHandle;
    }

    public ulong GetThreadCpuTime(IThreadInfo threadInfo)
    {
        var threadHandle = new HANDLE(threadInfo.OSThreadHandle);

        var success = PInvoke.GetThreadTimes(
            threadHandle, out var _, out var _, out var kernelTime, out var userTime);

        if (success)
        {
            return kernelTime.ToMilliseconds() + userTime.ToMilliseconds();
        }

        var lastError = (uint) Marshal.GetLastPInvokeError();
        
        if (lastError != (uint) WIN32_ERROR.ERROR_INVALID_HANDLE)
        {
            _logger.LogWarning(
                "Failed to GetThreadTimes() for thread 0x{ThreadHandle:x8} with error code 0x{ErrorCode:x8}: {Message}", 
                threadInfo.OSThreadHandle, 
                lastError,
                lastError != 0 ? Marshal.GetLastPInvokeErrorMessage() : string.Empty);
        }
        return 0;
    }

    internal unsafe bool EnsureThreadIsSuspended(HANDLE osThreadHandle)
    {
        var context = (CONTEXT*)NativeMemory.AlignedAlloc((nuint)sizeof(CONTEXT), 16);
        context->ContextFlags = CONTEXT_FLAGS.CONTEXT_INTEGER;
        var result = GetThreadContext(osThreadHandle, context);
        _logger.LogDebug("GetThreadContext(): {Result}", result);
        //NativeMemory.Free(context);
        Console.WriteLine($"Free: 0x{((nint)context):x8}");
        return result;
    }

    public bool TrySuspendThread(ManagedThreadInfo clrThreadInfo)
    {
        var osThreadHandle = new HANDLE(clrThreadInfo.OSThreadHandle);
        var suspendCount = PInvoke.SuspendThread(osThreadHandle);

        if (suspendCount == SuspendThreadFailed)
        {
            var lastError = (uint)Marshal.GetLastPInvokeError();

            _logger.LogError(
                "Failed to SuspendThread() for thread 0x{ThreadHandle:x8} with error code 0x{ErrorCode:x8}: {Message}",
                clrThreadInfo.OSThreadHandle,
                lastError,
                lastError != 0 ? Marshal.GetLastPInvokeErrorMessage() : string.Empty);

            return false;
        }


        // ensure the thread is actually suspended.
        // SuspendThread() is asynchronous and the scheduler may not immediately suspend the thread.
        // see: https://devblogs.microsoft.com/oldnewthing/20150205-00/?p=44743
        if (EnsureThreadIsSuspended(osThreadHandle))
        {
            // do not allocate after the thread is suspend or it may deadlock!
            return true;
        }

        _logger.LogWarning("Unable to suspend thread 0x{OsThreadHandle:x8}", osThreadHandle);

        PInvoke.ResumeThread(osThreadHandle);

        return false;
    }

    public bool TryResumeThread(ManagedThreadInfo clrThreadInfo)
    {
        var osThreadHandle = new HANDLE(clrThreadInfo.OSThreadHandle);

        var suspendCount = PInvoke.ResumeThread(osThreadHandle);

        if (suspendCount == ResumeThreadFailed)
        {
            var lastError = (uint)Marshal.GetLastPInvokeError();

            _logger.LogError(
                "Failed to ResumeThread() for thread 0x{ThreadHandle:x8} with error code 0x{ErrorCode:x8}: {Message}",
                clrThreadInfo.OSThreadHandle,
                lastError,
                lastError != 0 ? Marshal.GetLastPInvokeErrorMessage() : string.Empty);

            return false;
        }

        return true;
    }

    public unsafe void Dispose()
    {
        GC.SuppressFinalize(this);

        if (_profilerInfo != null)
        {
            _profilerInfo->Release();
        }
    }
}
