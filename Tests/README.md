# Profiler Tests
This folder contains a porting of the profiler tests in the .net runtime repo to check that the C# implementation produces the expected results. <br> The native test can be found here:  [dotnet/runtime/tree/main/src/tests/profiler/native](https://github.com/dotnet/runtime/tree/main/src/tests/profiler/native).

> **Note** 
> A large part of the test code is copied as is (or slighly adapted if needed)
> from the runtime repo. Aformentioned code is MIT licensed by MS. The copyright headers have been preserved.
>

## Run tests
In order to run tests it is necessary:
1. build and publish the `Tests.Profilers` project
2. have the following environment variables in the project `launchSettings.json`:
```
"environmentVariables": {
   "CORE_LIBRARIES": "C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\7.0.0",
   "CORE_ROOT": "path\to\corerun\location"
}
```

## Test Profilers
| name | id |
| ---- | -- |
| Transitions | `090B7720-6605-462B-86A0-C4D4C444D3F5` |
| GCBasic | `A040B953-EDE7-42D9-9077-AA69BB2BE024` |
| GCAllocations | `55b9554d-6115-45a2-be1e-c80f7fa35369` |
| GC | `BCD8186F-1EEC-47E9-AFA7-396F879382C3` |
| Inlining | `DDADC0CB-21C8-4E53-9A6C-7C65EE5800CE` |
| 🚧🚧🚧 | |
