namespace CorProf.Bindings
{
    public enum MergeFlags
    {
        MergeFlagsNone = 0,
        MergeManifest = 0x00000001,
        DropMemberRefCAs = 0x00000002,
        NoDupCheck = 0x00000004,
        MergeExportedTypes = 0x00000008,
    }
}
