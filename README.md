# ManagedCorProfiler

A prototype CLR profiler written in C# for learning and fun.

> [!WARNING]
> 🚧 WIP WIP WIP 🚧

## Building blocks
- [NativeAOT](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/) native compilation to build and link the native profiler library.
- [ComWrappers API](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.comwrappers?view=net-7.0) to expose the `ICorProfilerCallbackX` to the CLR.
- [CsWin32](https://github.com/microsoft/CsWin32) to generate C# bindings for the native [Profiling API](https://learn.microsoft.com/en-us/dotnet/framework/unmanaged-api/profiling/).

## Exposing a profiler callback
```csharp
///
/// A sample profiler callback that prints the loaded modules
///
[ProfilerCallback("cf0d821e-299b-5307-a3d8-b283c03916dd")]
internal unsafe class MyProfiler : CorProfilerCallback2
{
    private ICorProfilerInfo2* _corProfilerInfo;

    private const uint NameBufferLength = 256;

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
        hr = _corProfilerInfo->SetEventMask((uint)COR_PRF_MONITOR_MODULE_LOADS);

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

        // Allocate a buffer to hold the module name
        using var nameBuff = NativeBuffer<ushort>.Alloc(NameBufferLength);
        var szName = new PWSTR((char*)nameBuff.Pointer);
        
        uint pcchName = 0;

        // Retrieve the file name of the module
        var hr = _corProfilerInfo->GetModuleInfo(
            moduleId,         // the moduleId
            null,
            NameBufferLength, // The length, in characters, of the szName return buffer
            &pcchName,        // A pointer to the total character length of the module's file name that is returned
            szName,           // A caller-provided wide character buffer
            null);

        if (hr.Failed)
        {
            Console.WriteLine($"FAIL GetModuleInfo hr={hr}");
            return hr;
        }

        var moduleName = szName.ToString();

        Console.WriteLine($"loaded module 0x{moduleId:x8} <{moduleName}>");

        return HRESULT.S_OK;
    }

    public override HRESULT Shutdown()
    {
        _corProfilerInfo->Release();
        return HRESULT.S_OK;
    }
}
```

### Sample output
<pre><samp>C:\ManagedCorProfiler\Samples\ModuleLoads> <kbd>.\run.cmd</kbd>
[... OMITTED ...]
Loaded Module -> 0x7ffeac1b4000 C:\Users\dev\Source\Repos\runtime\artifacts\bin\coreclr\windows.x64.Debug\System.Private.CoreLib.dll
Loaded Module -> 0x7ffeac702148 C:\ManagedCorProfiler\Samples\SampleApp\bin\Debug\net8.0\SampleApp.dll
Loaded Module -> 0x7ffeac703e40 C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.0\system.runtime.dll
Loaded Module -> 0x7ffeac8f9798 C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.0\system.console.dll
Loaded Module -> 0x7ffeac8fc1f0 C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.0\system.threading.dll
Loaded Module -> 0x7ffeac9317d0 C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.0\system.text.encoding.extensions.dll
Loaded Module -> 0x7ffeac9389a0 C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.0\system.runtime.interopservices.dll
Hello World!
C:\ManagedCorProfiler\Samples\ModuleLoads> █</samp></pre>

## Compilation

<picture>
<source
  srcset="/docs/images/compilation-darrk.svg"
  media="(prefers-color-scheme: dark)"
/>
<source
  srcset="/docs/images/compilation-light.svg"
  media="(prefers-color-scheme: light), (prefers-color-scheme: no-preference)"
/>
<img src="/docs/images/compilation-light.svg" width="800">
</picture>

## Dumpbin of the profiler DLL
<pre><samp>C:\ManagedCorProfiler\Samples\ModuleLoads> <kbd>dumpbin.exe /EXPORTS bin\Release\net8.0\publish\win-x64\ModuleLoads.dll</kbd>
[...OMITTED FOR BREVITY...]
    ordinal hint RVA      name
          1    0 00232660 DllCanUnloadNow = DllCanUnloadNow
          2    1 002323A0 DllGetClassObject = DllGetClassObject
          3    2 002326A0 DllMain = DllMain
[...OMITTED FOR BREVITY...]
C:\ManagedCorProfiler\Samples\ModuleLoads> █</samp></pre>

## ELT Hooks
.

## How to Build
.
### Requirements
.

## Contributing
Any contribution is welcome.
I'm actually working on porting the tests at [dotnet/runtime/tree/main/src/tests/profiler](https://github.com/dotnet/runtime/tree/main/src/tests/profiler),
this is a good place to start contributing.

## Resources
### Misc
- [Writing a .NET Profiler in C# by Kevin Gosse](https://minidump.net/writing-a-net-profiler-in-c-part-1-d3978aae9b12)
- [https://github.com/dotnet/runtime](https://github.com/dotnet/runtime)
### COM / COM Interop
- [DllGetClassObject](https://learn.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-dllgetclassobject)
- [ComWrappers Tutorial](https://learn.microsoft.com/en-us/dotnet/standard/native-interop/tutorial-comwrappers)
- [ComWrappers interop sample](https://github.com/dotnet/samples/blob/main/core/interop/comwrappers/Tutorial/Program.cs)
### Profiling
- [Profiling Overview](https://learn.microsoft.com/en-us/dotnet/framework/unmanaged-api/profiling/profiling-overview)
- [Unmanaged profiling API](https://learn.microsoft.com/en-us/dotnet/framework/unmanaged-api/profiling/)
- [CoreCLR Profilin BOTR](https://github.com/dotnet/runtime/blob/main/docs/design/coreclr/botr/profiling.md)
- [clr-sample ProfilingAPI](https://github.com/mvenditto/clr-samples/tree/master/ProfilingAPI)
- [Profiling Interfaces](https://learn.microsoft.com/en-us/dotnet/framework/unmanaged-api/profiling/profiling-interfaces)
- [Profiling global static function](https://learn.microsoft.com/en-us/dotnet/framework/unmanaged-api/profiling/profiling-global-static-functions)
### Native AOT
- [NativeAOT Interop](https://github.com/dotnet/runtime/blob/main/src/coreclr/nativeaot/docs/interop.md)
- [Deploying NativeAOT](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/)
