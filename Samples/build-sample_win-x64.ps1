$sample_name = $args[0]
$profiler_proj = "$(pwd)\$sample_name"
dotnet publish $profiler_proj /p:NativeLib=Shared /p:SelfContained=true -r win-x64 -c Release
dotnet build .\SampleApp\ -c Debug