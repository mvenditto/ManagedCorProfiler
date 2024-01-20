namespace ClrProfiling.Core;

public class ProfilerCallbackAttribute : Attribute
{
    public Guid IID { get; private set; }

    public ProfilerCallbackAttribute(string guid)
    {
        IID = new Guid(guid);
    }
}