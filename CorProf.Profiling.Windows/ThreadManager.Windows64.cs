using Microsoft.Extensions.Logging;
using CorProf.Profiling.Abstractions;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging.Abstractions;
using CorProf.Profiling.Threading;
using static CorProf.Profiling.Windows64.Stack.NtDllNativeMethods;
using Microsoft.Diagnostics.Runtime.Utilities;
using Serilog;
using System.Diagnostics;
using CorProf.Bindings;
using Windows.Win32;
using Windows.Win32.System.Diagnostics.Debug;
using Windows.Win32.Foundation;
using Windows.Wdk.System.Threading;
using KAFFINITY = ulong;
using KPRIORITY = int;
using CorProf.Helpers;
using System.Reflection.Metadata.Ecma335; // LONG

namespace CorProf.Profiling.Windows64;

public class Windows64ThreadManager : IThreadManager, IDisposable
{
    private readonly ILogger<Windows64ThreadManager> _logger;
    private readonly unsafe ICorProfilerInfo4* _profilerInfo;
    
    private const uint SuspendThreadFailed = unchecked((uint)-1); // DWORD
    private const uint ResumeThreadFailed = unchecked((uint)-1); // DWORD

    private static unsafe delegate* unmanaged[Stdcall]<HANDLE, THREADINFOCLASS, void*, uint, uint*, NTSTATUS> QueryInformationThreadDelegate;

    public unsafe Windows64ThreadManager(ILogger<Windows64ThreadManager> logger, ICorProfilerInfo4* profilerInfo)
    {
        _logger = logger ?? NullLogger<Windows64ThreadManager>.Instance;

        if (profilerInfo != null)
        {
            profilerInfo->AddRef();
            _profilerInfo = profilerInfo;
        }

        InitQueryInformationThreadDelegate();
    }

    private static unsafe void InitQueryInformationThreadDelegate()
    {
        var ntdll = PInvoke.GetModuleHandle("ntdll.dll");

        if (ntdll == IntPtr.Zero)
        {
            ntdll = PInvoke.LoadLibrary("ntdll.dll");
        }

        QueryInformationThreadDelegate = (delegate* unmanaged[Stdcall]<HANDLE, THREADINFOCLASS, void*, uint, uint*, NTSTATUS>)PInvoke.GetProcAddress(ntdll, "NtQueryInformationThread").Value;
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
        context->ContextFlags = CONTEXT_FLAGS.CONTEXT_INTEGER_AMD64; // CONTEXT_INTEGER

        for (var i = 0; i < 10; i++)
        {
            var result = PInvoke.GetThreadContext(osThreadHandle, context);
            _logger.LogDebug("GetThreadContext(): {Result}", result);

            if (result)
            {

                NativeMemory.AlignedFree(context);
                return true;
            }
            
            if (Marshal.GetLastPInvokeError() == 5)
            {
                continue;
            }
        }

        if (context != null)
        {
            NativeMemory.AlignedFree(context);
        }

        throw new Exception(Marshal.GetLastPInvokeErrorMessage());

        return false;
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

    /*
    private struct CLIENT_ID
    {
        HANDLE UniqueProcess;
        HANDLE UniqueThread;
    };

    [StructLayout(LayoutKind.Sequential)]
    private unsafe struct THREAD_BASIC_INFORMATION
    {
        public NTSTATUS ExitStatus;      // 4
        public void* TebBaseAddress;     // 8
        public CLIENT_ID ClientId;       // 16
        public KAFFINITY AffinityMask;   // 8
        public KPRIORITY Priority;       // 4
        public KPRIORITY BasePriority;   // 4  
    }
    */

    [StructLayout(LayoutKind.Sequential)]
    public struct CLIENT_ID
    {
        public nint UniqueProcess;
        public nint UniqueThread;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct THREAD_BASIC_INFORMATION
    {
        public int ExitStatus;
        public nint TebBaseAddress;
        public CLIENT_ID ClientId;
        public nint AffinityMask;
        public int Priority;
        public int BasePriority;
    }

    private readonly unsafe struct _EXCEPTION_REGISTRATION_RECORD
    {
        public readonly _EXCEPTION_REGISTRATION_RECORD* Next;
        public readonly void* Handler;
    }

    private readonly unsafe struct NT_TIB
    {
        public readonly void* /*_EXCEPTION_REGISTRATION_RECORD**/ ExceptionList;
        public readonly void* StackBase;
        public readonly void* StackLimit;
        public readonly void* SubSystemTib;
        public readonly void* FiberData;
        public readonly void* ArbitraryUserPointer;
        public readonly NT_TIB* Self;
    }

    private static unsafe delegate* unmanaged[Stdcall]<HANDLE, THREADINFOCLASS, void*, uint, uint*> NtQueryInformationThreadDelegate;

    internal unsafe bool GetThreadStackLimits(ref HANDLE handle, ref ulong stackLimit, ref ulong stackBase)
    {
        var threadBasicInfo = (THREAD_BASIC_INFORMATION*)NativeMemory.Alloc((nuint)sizeof(THREAD_BASIC_INFORMATION));

        uint returnLength = 0;

        var result = QueryInformationThreadDelegate(
            handle,
            THREADINFOCLASS.ThreadBasicInformation,
            &threadBasicInfo[0],
            (uint)sizeof(THREAD_BASIC_INFORMATION),
            &returnLength);

        if (result.SeverityCode != NTSTATUS.Severity.Success)
        {
            _logger.LogWarning("FAIL NtQueryInformationThread() with hr=0x{hr:x8} {message}", result, result);
            NativeMemory.Free(threadBasicInfo);
            return false;
        }

        var hasThreadInfo = returnLength > 0 && returnLength <= sizeof(THREAD_BASIC_INFORMATION);

        if (!hasThreadInfo)
        {
            _logger.LogWarning("FAIL NtQueryInformationThread()");
            NativeMemory.Free(threadBasicInfo);
            return false;
        }

        var tib = (NT_TIB*)threadBasicInfo->TebBaseAddress;

        stackLimit = (ulong)tib->StackLimit;
        stackBase = (ulong)tib->StackBase;

        NativeMemory.Free(threadBasicInfo);
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
