﻿using Windows.Win32;
using Microsoft.Extensions.Logging.Abstractions;
using System.Diagnostics;
using Windows.Win32.Foundation;
using Xunit;
using Xunit.Abstractions;
using Windows.Win32.System.Threading;
using ClrProfiling.Backend.Threading;
using System.Runtime.InteropServices;
using ClrProfiling.Backend.Windows.Stack;

namespace ClrProfiling.Backend.Windows.Tests;

public class ThreadingTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ThreadingTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Windows64ThreadManager_GetThreadStackLimits()
    {
        var currProcess = Process.GetCurrentProcess();
        var targetThread = currProcess.Threads.OfType<ProcessThread>().First();

        unsafe
        {
            var tm = new Windows64ThreadManager(NullLogger<Windows64ThreadManager>.Instance, null);

            var osThreadHandleReal = HANDLE.Null;

            try
            {
                // Get a pseudo handle to the target thread
                var osThreadHandlePseudo = PInvoke_Windows.OpenThread(
                    THREAD_ACCESS_RIGHTS.THREAD_QUERY_INFORMATION,
                    false,
                    (uint)targetThread.Id);

                var processHandle = new HANDLE(Process.GetCurrentProcess().Handle);
                var threadHandle = new HANDLE(osThreadHandlePseudo);

                osThreadHandleReal = HANDLE.Null;

                // Acquire a "real" handle instead of a pseudo-handle.
                var res = PInvoke_Windows.DuplicateHandle(
                    processHandle,
                    threadHandle,
                    processHandle,
                    &osThreadHandleReal,
                    (uint)THREAD_ACCESS_RIGHTS.THREAD_QUERY_INFORMATION,
                    false,
                    0
                );

                if (res == 0)
                {
                    Assert.Fail($"FAIL Kernel32::DuplicateHandle() with hr={res:x8}");
                }

                var stackBase = 0UL;
                var stackLimit = 0UL;

                // Try get the thread's stack bounds.
                var stackLimits = tm.GetThreadStackLimits(ref osThreadHandleReal, ref stackLimit, ref stackBase);

                Assert.True(stackLimits);
                Assert.True(stackBase > 0);
                Assert.True(stackLimit > 0);

                _testOutputHelper.WriteLine($"stackBase=0x{stackBase:x8} stackLimit=0x{stackLimit:x8}");
            }
            catch
            {
                throw;
            }
            finally
            {
                // Close the duplicated handle.
                // NOTE: the pseudo handle do NOT need to be closed.
                if (osThreadHandleReal != HANDLE.Null)
                {
                    PInvoke.CloseHandle(osThreadHandleReal);
                }
            }
        }
    }


    [Fact]
    public void Windows64ThreadManager_ThreadSuspendResume()
    {
        var currProcess = Process.GetCurrentProcess();

        var e = new ManualResetEventSlim(false);

        var osThreadId = 0U;

        var t = new Thread(() =>
        {
            osThreadId = PInvoke_Windows.GetCurrentThreadId();
            e.Set();
            var i = 0;
            while (true)
            {
                i += 0;
            }
        });

        t.Start();

        e.Wait();

        var targetThread = currProcess.Threads
            .OfType<ProcessThread>()
            .Where(x => x.Id == osThreadId)
            .First();

        _testOutputHelper.WriteLine(currProcess.ProcessName);
        _testOutputHelper.WriteLine(targetThread.Id.ToString());

        unsafe
        {
            var tm = new Windows64ThreadManager(NullLogger<Windows64ThreadManager>.Instance, null);
            var osThreadHandleReal = HANDLE.Null;

            try
            {
                // Get a pseudo handle to the target thread
                var osThreadHandlePseudo = PInvoke_Windows.OpenThread(
                    THREAD_ACCESS_RIGHTS.THREAD_SUSPEND_RESUME | THREAD_ACCESS_RIGHTS.THREAD_GET_CONTEXT,
                    false,
                    (uint)targetThread.Id);

                var processHandle = new HANDLE(currProcess.Handle);
                var threadHandle = new HANDLE(osThreadHandlePseudo);

                osThreadHandleReal = HANDLE.Null;

                // Acquire a "real" handle instead of a pseudo-handle.
                var res = PInvoke_Windows.DuplicateHandle(
                    processHandle,
                    threadHandle,
                    processHandle,
                    &osThreadHandleReal,
                    (uint)(THREAD_ACCESS_RIGHTS.THREAD_SUSPEND_RESUME | THREAD_ACCESS_RIGHTS.THREAD_GET_CONTEXT),
                    false,
                    0
                );

                if (res.Value == 0)
                {
                    Assert.Fail($"FAIL Kernel32::DuplicateHandle() with hr={res:x8}");
                }

                var tInfo = new ManagedThreadInfo(0);
                tInfo.SetOSThreadInfo((uint)targetThread.Id, osThreadHandleReal);

                Assert.True(tm.TrySuspendThread(tInfo));
                Assert.True(tm.TryResumeThread(tInfo));

            }
            catch
            {
                throw;
            }
            finally
            {
                // Close the duplicated handle.
                // NOTE: the pseudo handle do NOT need to be closed.
                if (osThreadHandleReal != HANDLE.Null)
                {
                    PInvoke.CloseHandle(osThreadHandleReal);
                }
            }
        }
    }


    [Fact]
    public void Windows64ThreadManager_ThreadStackUnwind()
    {
        var currProcess = Process.GetCurrentProcess();

        var e = new ManualResetEventSlim(false);

        var osThreadId = 0U;

        var t = new Thread(() =>
        {
            osThreadId = PInvoke_Windows.GetCurrentThreadId();
            e.Set();
            var i = 0;
            while (true)
            {
                i += 0;
            }
        });

        t.Start();

        e.Wait();

        var targetThread = currProcess.Threads
            .OfType<ProcessThread>()
            .Where(x => x.Id == osThreadId)
            .First();

        _testOutputHelper.WriteLine(currProcess.ProcessName);
        _testOutputHelper.WriteLine(targetThread.Id.ToString());

        unsafe
        {
            var tm = new Windows64ThreadManager(NullLogger<Windows64ThreadManager>.Instance, null);
            var osThreadHandleReal = HANDLE.Null;

            try
            {
                // Get a pseudo handle to the target thread
                var osThreadHandlePseudo = PInvoke_Windows.OpenThread(
                    THREAD_ACCESS_RIGHTS.THREAD_ALL_ACCESS,
                    false,
                    (uint)targetThread.Id);

                var processHandle = new HANDLE(currProcess.Handle);
                var threadHandle = new HANDLE(osThreadHandlePseudo);

                osThreadHandleReal = HANDLE.Null;

                // Acquire a "real" handle instead of a pseudo-handle.
                var res = PInvoke_Windows.DuplicateHandle(
                    processHandle,
                    threadHandle,
                    processHandle,
                    &osThreadHandleReal,
                    (uint)THREAD_ACCESS_RIGHTS.THREAD_ALL_ACCESS,
                    false,
                    0
                );

                if (res.Value == 0)
                {
                    Assert.Fail($"FAIL Kernel32::DuplicateHandle() with hr={res:x8}");
                }

                var tInfo = new ManagedThreadInfo(0);
                tInfo.SetOSThreadInfo((uint)targetThread.Id, osThreadHandleReal);

                var unwinder = new Windows64StackWalker(tm, tInfo, null);

                Assert.True(tm.TrySuspendThread(tInfo));

                var res2 = unwinder.Unwind();

                Assert.True(tm.TryResumeThread(tInfo));

                if (res2 != 0)
                {
                    var err = Marshal.GetLastPInvokeError();
                    var msg = Marshal.GetLastPInvokeErrorMessage();
                    Assert.Fail($"FAIL Unwind {res2} 0x{err:x8} {msg}");
                }

                foreach (var frame in unwinder.Frames)
                {
                    _testOutputHelper.WriteLine($"0x{frame:x8}");
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                // Close the duplicated handle.
                // NOTE: the pseudo handle do NOT need to be closed.
                if (osThreadHandleReal != HANDLE.Null)
                {
                    PInvoke.CloseHandle(osThreadHandleReal);
                }
            }
        }
    }
}
