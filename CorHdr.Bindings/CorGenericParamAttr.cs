namespace CorProf.Bindings
{
    public enum CorGenericParamAttr
    {
        gpVarianceMask = 0x0003,
        gpNonVariant = 0x0000,
        gpCovariant = 0x0001,
        gpContravariant = 0x0002,
        gpSpecialConstraintMask = 0x003C,
        gpNoSpecialConstraint = 0x0000,
        gpReferenceTypeConstraint = 0x0004,
        gpNotNullableValueTypeConstraint = 0x0008,
        gpDefaultConstructorConstraint = 0x0010,
        gpAcceptByRefLike = 0x0020,
    }
}
