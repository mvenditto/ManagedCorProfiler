# ManagedCorProfiler

A prototype [.NET profiler](https://learn.microsoft.com/en-us/dotnet/framework/unmanaged-api/profiling/) written in C# leveraging [NativeAOT](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/) + [ComWrappers](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.comwrappers?view=net-7.0).

> 🚧 WIP WIP WIP 🚧
> MORE INFO AND INSTRUCTION SOON

## Overview
<img src="/docs/images/overview.png"></img>

## Sample
The sample produces a native DLL that can be loaded as a CLR Profiler.

To test the concept, the example does a few basic things:
 1. Exposes `DllGetClassObject` DLL entry point
 2. Implements `ICorProfilerCallback` + `ICorProfilerCallback2` interfaces
 3. hooks to `ICorProfilerCallback::ModuleLoadFinished` and `ICorProfilerInfo2::SetEnterLeaveFunctionHooks2`
 4. logs the name of every loaded module

## Sample output
<pre><samp>C:\ManagedCorProfiler\ManagedCorProfiler> <kbd>.\run.cmd</kbd>
DllMain(reason=DLL_PROCESS_ATTACH)
DllGetClassObject()
DllMain(reason=DLL_THREAD_ATTACH)
        RCLSID = cf0d821e-299b-5307-a3d8-b283c03916dd
        RIID   = 00000001-0000-0000-c000-000000000046
ClassFactory!QueryInterface->ADD_REF
CorProfilerComWrappers
CorProfilerComWrappers!ComputeVtables
MyProfiler!InitializeICorProfilerCallback!Initialize(): profInfo 20A0A6071D0
DllMain(reason=DLL_THREAD_ATTACH)
ICorProfilerCallback!ModuleLoadFinished(0x7FFCCD4B4000)
Loaded Moudle -> 'C:\Users\mvenditto\Source\Repos\runtime\artifacts\bin\coreclr\windows.x64.Debug\System.Private.CoreLib.dll'
ICorProfilerCallback!ModuleLoadFinished(0x7FFCCDD741A0)
Loaded Moudle -> 'C:\Users\mvenditto\Source\Repos\ManagedCorProfiler\SampleApp\bin\Debug\net7.0\vtbl_test.dll'
ICorProfilerCallback!ModuleLoadFinished(0x7FFCCDD75E78)
Loaded Moudle -> 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\7.0.0\system.runtime.dll'
ICorProfilerCallback!ModuleLoadFinished(0x7FFCCDF0E960)
Loaded Moudle -> 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\7.0.0\system.console.dll'
DllMain(reason=DLL_THREAD_ATTACH)
ICorProfilerCallback!ModuleLoadFinished(0x7FFCCDF31538)
Loaded Moudle -> 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\7.0.0\system.threading.dll'
ICorProfilerCallback!ModuleLoadFinished(0x7FFCCDF36C68)
Loaded Moudle -> 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\7.0.0\system.text.encoding.extensions.dll'
ICorProfilerCallback!ModuleLoadFinished(0x7FFCCDF3DCC0)
Loaded Moudle -> 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\7.0.0\system.runtime.interopservices.dll'
Hello World!

C:\ManagedCorProfiler\ManagedCorProfiler> █</samp></pre>

## Other approaches or variations
> not tested, just off the top of my head
- [DNNE](https://github.com/AaronRobinsonMSFT/DNNE) + managed assembly implementing the profiler itself
- A native (C++) library using `nethost` to host an instance of the CRL + a managed library implementing the profiler
- do not use `ComWrappers` but directly mess with `UnmanagedCallersOnly`, [function pointers](https://learn.microsoft.com/it-it/dotnet/csharp/language-reference/proposals/csharp-9.0/function-pointers) and co to manually implement COM ABI vtables.

## Dumpbin of the profiler DLL
<pre><samp>C:\ManagedCorProfiler\ManagedCorProfiler> <kbd>dumpbin.exe /EXPORTS bin\Debug\net7.0\win-x64\native\ManagedCorProfiler.dll</kbd>
[...OMITTED FOR BREVITY...]
    ordinal hint RVA      name
          1    0 00232660 DllCanUnloadNow = DllCanUnloadNow
          2    1 002323A0 DllGetClassObject = DllGetClassObject
          3    2 002326A0 DllMain = DllMain
          4    3 00497430 DotNetRuntimeDebugHeader = DotNetRuntimeDebugHeader
[...OMITTED FOR BREVITY...]
C:\ManagedCorProfiler\ManagedCorProfiler> █</samp></pre>

## Next Work
- some source generation magic to ease the creation of COM interfaces, wrappers and CLR types.

## Codegen
- code contained in the `*.Bindings` projects is generated using [ClangSharpPInvokeGenerator](https://github.com/dotnet/ClangSharp)
- at this point, some manual tweaks are needed to make the generated bindings for an header compile (e.g fixing callconvs)

## Function Hooks
TBD

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
