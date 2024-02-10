$sample_name = $args[0]

$pwd = "$(pwd)"

$profiler_src_file = "$pwd\$sample_name\Profiler.cs"

$profiler_clsid = (Get-Content $profiler_src_file `
    | Select-String -Pattern '^\[ProfilerCallback\("(.*)"\)\]').Matches[0].Groups[1].Value

$sample_host = $env:SAMPLE_HOST

if ([string]::IsNullOrEmpty($sample_host))
{
    $sample_host = 'dotnet'
}

Write-Output "Running sample using host: $sample_host"

$profiler_dll = "$pwd\$sample_name\bin\Release\net8.0\win-x64\publish\$sample_name.dll"

if (!(Test-Path $profiler_dll -PathType Leaf))
{
    Write-Error "[ERR] Cannot find profiler.dll, has the project been published?"
    exit
}

$env:CORECLR_PROFILER="{$profiler_clsid}"
$env:CORECLR_PROFILER_PATH_64=$profiler_dll
$env:CORECLR_ENABLE_PROFILING=1

if ($sample_host -eq 'corerun')
{
    Write-Output "sample-runner - [INF] Set CORE_ROOT and CORE_LIBRARIES if necessary."

    $env:COMPlus_LogEnable=1
    $env:COMPlus_LogLevel=3
    $env:COMPlus_LogToConsole=1
    $env:COMPlus_LogToFile=1
    $env:COMPlus_LogFile=".\logs\prof_${sample_name}.log"
    
    if (!(Test-Path ./logs))
    {
	New-Item -ItemType Directory -Path .\logs
    }
}
elseif ($sample_host  -eq 'dotnet')
{
   Write-Output "sample-runner - [INF] Profiler logging will only work for Debug builds of dotnet."
}

& $sample_host ".\SampleApp\bin\Debug\net8.0\SampleApp.dll"
