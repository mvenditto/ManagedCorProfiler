set CORECLR_PROFILER={cf0d821e-299b-5307-a3d8-b283c03916dd}
set CORECLR_PROFILER_PATH_64=%cd%\bin\Debug\net7.0\win-x64\native\ManagedCorProfiler.dll
set CORECLR_ENABLE_PROFILING=1
set COMPlus_LogEnable=0
set COMPlus_LogLevel=3
set COMPlus_LogToConsole=1
set CORE_LIBRARIES=C:\Program Files\dotnet\shared\Microsoft.NETCore.App\7.0.0

corerun.exe "..\SampleApp\bin\Debug\net7.0\SampleApp.dll"