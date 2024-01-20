using ClrProfiling.Core;
using ClrProfiling.Core.Abstractions;
using ClrProfiling.Helpers;
using ClrProfiling.Hooks;
using ClrProfiling.Shared;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.System.Com;
using Windows.Win32.System.Diagnostics.ClrProfiling;
using static Windows.Win32.System.Diagnostics.ClrProfiling.COR_PRF_MONITOR;

namespace Elt3HooksProfiler;

[ProfilerCallback("cf0d821e-299b-5307-a3d8-b283c03916dd")]
internal unsafe class ELT3Profiler_StaticallyLinkedHooks : CorProfilerCallback2
{
    private ICorProfilerInfo5* _corProfilerInfo5;
    private static ICorProfilerInfo2* _sCorProfilerInfo2;

    [UnmanagedCallersOnly(EntryPoint = "EnterStub3WithInfo")]
    private static void EnterStub3WithInfo(FunctionIDOrClientID functionOrClientId, nuint eltInfo)
    {
        if (ShutdownGuard.HasShutdownStarted())
        {
            return;
        }

        var hr = ProfilerInfoHelpers.GetFunctionIDName(
            _sCorProfilerInfo2,
            functionOrClientId.functionID,
            out string functionName);

        if (hr.Failed)
        {
            Console.WriteLine($"GetFunctionIDName failed for 0x{functionOrClientId.functionID:x8} with hr 0x{hr:x8}");
            return;
        }

        Console.WriteLine($"> ENTER: {functionName}");
    }

    [UnmanagedCallersOnly(EntryPoint = "LeaveStub3WithInfo")]
    private static void LeaveStub3WithInfo(FunctionIDOrClientID functionOrClientId, nuint eltInfo)
    {
        if (ShutdownGuard.HasShutdownStarted())
        {
            return;
        }

        var hr = ProfilerInfoHelpers.GetFunctionIDName(
            _sCorProfilerInfo2,
            functionOrClientId.functionID,
            out string functionName);

        if (hr.Failed)
        {
            Console.WriteLine($"GetFunctionIDName failed for 0x{functionOrClientId.functionID:x8} with hr 0x{hr:x8}");
            return;
        }

        Console.WriteLine($"< LEAVE: {functionName}");
    }

    [UnmanagedCallersOnly(EntryPoint = "TailcallStub3WithInfo")]
    private static void TailcallStub3WithInfo(FunctionIDOrClientID functionOrClientId, nuint eltInfo)
    {
        if (ShutdownGuard.HasShutdownStarted())
        {
            return;
        }

        var hr = ProfilerInfoHelpers.GetFunctionIDName(
            _sCorProfilerInfo2,
            functionOrClientId.functionID,
            out string functionName);

        if (hr.Failed)
        {
            Console.WriteLine($"GetFunctionIDName failed for 0x{functionOrClientId.functionID:x8} with hr 0x{hr:x8}");
            return;
        }

        Console.WriteLine($"< LEAVE: {functionName}");
    }

    [DllImport("kernel32.dll")]
    public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

    [DllImport("kernel32.dll")]
    public static extern IntPtr GetModuleHandle(string moduleName);

    public override HRESULT Initialize(IUnknown* unknown)
    {
        ShutdownGuard.Initialize();

        Console.WriteLine("Profiler.dll!Profiler::Initialize");

        var hr = unknown->QueryInterface(ICorProfilerInfo13.IID_Guid, out var pinfo);

        if (hr.Failed)
        {
            Console.WriteLine("Profiler.dll!Profiler::Initialize failed to QI for ICorProfilerInfo.");
            return HRESULT.E_FAIL;
        }

        _corProfilerInfo5 = (ICorProfilerInfo5*)pinfo;

        _sCorProfilerInfo2 = (ICorProfilerInfo2*)_corProfilerInfo5;

        hr = _corProfilerInfo5->SetEventMask2((uint)(COR_PRF_MONITOR_ENTERLEAVE
                                                | COR_PRF_ENABLE_FUNCTION_ARGS
                                                | COR_PRF_ENABLE_FUNCTION_RETVAL
                                                | COR_PRF_ENABLE_FRAME_INFO),
                                                0);

        if (hr.Failed)
        {
            Console.WriteLine($"FAIL: IpCorProfilerInfo::SetEventMask2() failed hr=0x{hr:x8}");
            return hr;
        }

        var moduleHandle = GetModuleHandle($"{nameof(ELT3Profiler_StaticallyLinkedHooks)}.dll");

        Console.WriteLine($"self.module addr: 0x{moduleHandle:x8}");

        var enterNaked = GetProcAddress(moduleHandle, "EnterNaked3WithInfo");
        var leaveNamed = GetProcAddress(moduleHandle, "LeaveNaked3WithInfo");
        var tailcallNaked = GetProcAddress(moduleHandle, "TailcallNaked3WithInfo");

        Console.WriteLine($"EnterNaked addr: 0x{enterNaked:x8}");
        Console.WriteLine($"LeaveNamed addr: 0x{leaveNamed:x8}");
        Console.WriteLine($"TailcallNaked addr: 0x{tailcallNaked:x8}");

        hr = _corProfilerInfo5->SetEnterLeaveFunctionHooks3WithInfo(
            (delegate* unmanaged[Stdcall]<FunctionIDOrClientID, nuint, void>*)enterNaked,
            (delegate* unmanaged[Stdcall]<FunctionIDOrClientID, nuint, void>*)leaveNamed,
            (delegate* unmanaged[Stdcall]<FunctionIDOrClientID, nuint, void>*)tailcallNaked);

        if (hr.Failed)
        {
            Console.WriteLine($"FAIL SetEnterLeaveFunctionHooks3WithInfo::Register hr={hr}");
            return HRESULT.E_FAIL;
        }

        return HRESULT.S_OK;
    }

    public override HRESULT Shutdown()
    {
        Console.WriteLine("Profiler.dll!Profiler::Shutdown");
        Console.Out.Flush();

        // Wait for any in progress profiler callbacks to finish.
        ShutdownGuard.WaitForInProgressHooks();

        _corProfilerInfo5->Release();

        return HRESULT.S_OK;
    }
}