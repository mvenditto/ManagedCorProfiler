namespace CorProf.Bindings
{
    public enum CorDeclSecurity
    {
        dclActionMask = 0x001f,
        dclActionNil = 0x0000,
        dclRequest = 0x0001,
        dclDemand = 0x0002,
        dclAssert = 0x0003,
        dclDeny = 0x0004,
        dclPermitOnly = 0x0005,
        dclLinktimeCheck = 0x0006,
        dclInheritanceCheck = 0x0007,
        dclRequestMinimum = 0x0008,
        dclRequestOptional = 0x0009,
        dclRequestRefuse = 0x000a,
        dclPrejitGrant = 0x000b,
        dclPrejitDenied = 0x000c,
        dclNonCasDemand = 0x000d,
        dclNonCasLinkDemand = 0x000e,
        dclNonCasInheritance = 0x000f,
        dclMaximumValue = 0x000f,
    }
}
