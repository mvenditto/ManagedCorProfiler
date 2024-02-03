namespace Tests.Common.Utils;

public record RuntimeInformation
{
    public RuntimeInformation(uint major, uint minor, uint build, string versionString)
    {
        MajorVersion = major;
        MinorVersion = minor;
        BuildNumber = build;
        VersionString = versionString;
        Version = new Version((int)major, (int)minor, (int)build);
    }

    public uint MajorVersion { get; }

    public uint MinorVersion { get; }

    public uint BuildNumber { get; }

    public string VersionString { get; } = null!;

    public Version Version { get; }
}
