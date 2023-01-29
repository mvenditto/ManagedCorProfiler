# Transitions Profiler

Slightly modified version of [dotnet/runtime/tree/main/src/tests/profiler/native/transitions](https://github.com/dotnet/runtime/tree/main/src/tests/profiler/native/transitions)

> **Note**
> for some reason that needs further investigation two unexpected transitions messed up the test:
>
>     [U => M] System.Private.CoreLib.dll!EtwEnableCallback::Invoke
>     [M => U] System.Private.CoreLib.dll!EtwEnableCallback::Invoke
>
> taking into account the fully qualified name of transition functions fix the issue
> but there probably is some unwanted behavior with the profiler itself i'm not aware of that
> causes that transitions. i will look into this agai
> 