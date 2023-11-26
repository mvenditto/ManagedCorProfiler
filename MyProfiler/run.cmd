dotnet publish /p:NativeLib=Shared /p:SelfContained=true -r win-x64 -c Debug

set CORECLR_PROFILER={cf0d821e-299b-5307-a3d8-b283c03916dd}
set CORECLR_PROFILER_PATH_64=%cd%\bin\Debug\net8.0\win-x64\native\MyProfiler.dll
set CORECLR_ENABLE_PROFILING=1
set COMPlus_LogEnable=0
set COMPlus_LogLevel=3
set COMPlus_LogToConsole=1
set CORE_LIBRARIES=C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.0

corerun.exe "..\SampleApp\bin\Debug\net8.0\SampleApp.dll"