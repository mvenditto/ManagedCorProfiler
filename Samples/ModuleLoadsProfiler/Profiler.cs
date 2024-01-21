using ClrProfiling.Core;
using ClrProfiling.Core.Abstractions;
using ClrProfiling.Helpers;
using System.Net;
using System.Runtime.CompilerServices;
using Windows.Win32.Foundation;
using Windows.Win32.System.Com;
using Windows.Win32.System.Diagnostics.ClrProfiling;

namespace ModuleLoadsProfiler;

///
/// A sample profiler callback that prints the loaded modules
///
[ProfilerCallback("1E040027-162F-489B-B12F-F113E6AF40CF")]
internal unsafe class MyProfiler : CorProfilerCallback2
{
    private ICorProfilerInfo2* _corProfilerInfo;

    public override HRESULT Initialize(IUnknown* pICorProfilerInfoUnk)
    {
        // Query for a pointer to the ICorProfilerCallback2 interface
        var hr = pICorProfilerInfoUnk->QueryInterface(ICorProfilerInfo2.IID_Guid, out var pinfo);

        if (hr.Failed)
        {
            Console.WriteLine($"FAIL QueryInterface hr={hr}");
            return HRESULT.E_FAIL;
        }

        // Track our reference
        _corProfilerInfo = (ICorProfilerInfo2*)pinfo;
        _corProfilerInfo->AddRef();

        // Specify our profiler is interested in module load events (Module* callbacks)
        hr = _corProfilerInfo->SetEventMask((uint)COR_PRF_MONITOR.COR_PRF_MONITOR_MODULE_LOADS);

        if (hr.Failed)
        {
            Console.WriteLine($"FAIL SetEventMask hr={hr}");
            return HRESULT.E_FAIL;
        }

        return HRESULT.S_OK;
    }

    public override HRESULT ModuleLoadFinished(nuint moduleId, HRESULT hrStatus)
    {
        if (hrStatus.Failed)
        {
            return HRESULT.S_OK;
        }

        const int NameBufferLength = 256; // char

        // Allocate a buffer to hold the module name.
        using var szNameBuffer = NativeBuffer<char>.Alloc(NameBufferLength);

        // A pointer to a string of wide-characters to pass in input to GetModuleInfo.
        var szName = new PWSTR(szNameBuffer.Pointer);

        uint pcchName = 0;

        // Retrieve the file name of the module
        var hr = _corProfilerInfo->GetModuleInfo(
            moduleId,            // the target moduleId
            null,
            NameBufferLength,    // The length, in characters, of the szName return buffer
            &pcchName,           // A pointer to the total character length of the module's file name that is returned
            szName,              // A caller-provided wide character buffer
            null);

        if (hr.Failed)
        {
            Console.WriteLine($"FAIL GetModuleInfo hr={hr}");
            return hr;
        }

        var moduleName = szName.CopyToString(length: (int)pcchName);

        Console.WriteLine($"loaded module 0x{moduleId:x8} <{moduleName}>");

        return HRESULT.S_OK;
    }

    public override HRESULT Shutdown()
    {
        _corProfilerInfo->Release();
        return HRESULT.S_OK;
    }
}