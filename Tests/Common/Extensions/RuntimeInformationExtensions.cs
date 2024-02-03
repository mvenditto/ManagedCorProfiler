namespace Tests.Common.Utils;

public static class RuntimeInformationExtensions
{
    public static bool IsEqualOrGreater(this RuntimeInformation runtime, Version targetVersion)
    {
        return runtime.Version >= targetVersion;
    }

    public static bool IsEqualOrGreater(this RuntimeInformation runtime, string targetVersion)
    {
        return runtime.Version >= new Version(targetVersion);
    }

    public static bool IsNet5(this RuntimeInformation runtime) => runtime.MajorVersion == 5;

    public static bool IsNet6(this RuntimeInformation runtime) => runtime.MajorVersion == 6;

    public static bool IsNet7(this RuntimeInformation runtime) => runtime.MajorVersion == 7;

    public static bool IsNet8(this RuntimeInformation runtime) => runtime.MajorVersion == 8;

    public static bool IsNet5OrGreater(this RuntimeInformation runtime) => runtime.MajorVersion >= 5;

    public static bool IsNet6OrGreater(this RuntimeInformation runtime) => runtime.MajorVersion >= 6;

    public static bool IsNet7OrGreater(this RuntimeInformation runtime) => runtime.MajorVersion >= 7;

    public static bool IsNet8OrGreater(this RuntimeInformation runtime) => runtime.MajorVersion >= 8;
}
