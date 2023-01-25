dotnet publish /p:NativeLib=Shared /p:SelfContained=true -r win-x64 -c Release

set CORECLR_PROFILER={090B7720-6605-462B-86A0-C4D4C444D3F5}
set CORECLR_PROFILER_PATH_64=%cd%\bin\Release\net7.0\win-x64\native\Profiler.dll
set CORECLR_ENABLE_PROFILING=1
set COMPlus_LogEnable=1
set COMPlus_LogLevel=3
set COMPlus_LogToConsole=1
set CORE_LIBRARIES=C:\Program Files\dotnet\shared\Microsoft.NETCore.App\7.0.0

set PInvoke_Transition_Expected_Name=pinvoke
set ReversePInvoke_Transition_Expected_Name=rpinvoke

corerun.exe "..\App\bin\Release\net7.0\TransitionsApp.dll"