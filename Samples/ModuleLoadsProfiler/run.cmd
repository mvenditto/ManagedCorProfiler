set CORECLR_PROFILER={1E040027-162F-489B-B12F-F113E6AF40CF}
set CORECLR_PROFILER_PATH_64=%cd%\bin\Release\net8.0\win-x64\publish\ModuleLoadsProfiler.dll
set CORECLR_ENABLE_PROFILING=1
set COMPlus_LogEnable=1
set COMPlus_LogLevel=3
set COMPlus_LogToConsole=1
set CORE_LIBRARIES=C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.0

corerun.exe "..\SampleApp\bin\Debug\net8.0\SampleApp.dll"