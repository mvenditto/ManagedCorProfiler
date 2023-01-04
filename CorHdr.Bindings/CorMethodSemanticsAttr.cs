namespace CorProf.Bindings
{
    public enum CorMethodSemanticsAttr
    {
        msSetter = 0x0001,
        msGetter = 0x0002,
        msOther = 0x0004,
        msAddOn = 0x0008,
        msRemoveOn = 0x0010,
        msFire = 0x0020,
    }
}
