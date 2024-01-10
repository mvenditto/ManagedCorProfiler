using System.Runtime.CompilerServices;
using Windows.Win32.Foundation;

namespace Windows.Win32.System.Diagnostics.ClrProfiling;

public unsafe partial struct ICorProfilerInfo2 : IVTable<ICorProfilerInfo2, ICorProfilerInfo2.Vtbl>, IComIID
{
    public static implicit operator ICorProfilerInfo(ICorProfilerInfo2 info) => info;

    public HRESULT AsInterface(out Interface iface)
    {
        return ComHelpers.UnwrapCCW((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), out iface);
    }
}

public unsafe partial struct ICorProfilerInfo3 : IVTable<ICorProfilerInfo3, ICorProfilerInfo3.Vtbl>, IComIID
{
    public static implicit operator ICorProfilerInfo2(ICorProfilerInfo3 info) => info;
    public static implicit operator ICorProfilerInfo(ICorProfilerInfo3 info) => info;
}

public unsafe partial struct ICorProfilerInfo4 : IVTable<ICorProfilerInfo4, ICorProfilerInfo4.Vtbl>, IComIID
{
    public static implicit operator ICorProfilerInfo3(ICorProfilerInfo4 info) => info;
    public static implicit operator ICorProfilerInfo2(ICorProfilerInfo4 info) => info;
    public static implicit operator ICorProfilerInfo(ICorProfilerInfo4 info) => info;
}

public unsafe partial struct ICorProfilerInfo5 : IVTable<ICorProfilerInfo5, ICorProfilerInfo5.Vtbl>, IComIID
{
    public static implicit operator ICorProfilerInfo4(ICorProfilerInfo5 info) => info;
    public static implicit operator ICorProfilerInfo3(ICorProfilerInfo5 info) => info;
    public static implicit operator ICorProfilerInfo2(ICorProfilerInfo5 info) => info;
    public static implicit operator ICorProfilerInfo(ICorProfilerInfo5 info) => info;
}

public unsafe partial struct ICorProfilerInfo6 : IVTable<ICorProfilerInfo6, ICorProfilerInfo6.Vtbl>, IComIID
{
    public static implicit operator ICorProfilerInfo5(ICorProfilerInfo6 info) => info;
    public static implicit operator ICorProfilerInfo4(ICorProfilerInfo6 info) => info;
    public static implicit operator ICorProfilerInfo3(ICorProfilerInfo6 info) => info;
    public static implicit operator ICorProfilerInfo2(ICorProfilerInfo6 info) => info;
    public static implicit operator ICorProfilerInfo(ICorProfilerInfo6 info) => info;
}

public unsafe partial struct ICorProfilerInfo7 : IVTable<ICorProfilerInfo7, ICorProfilerInfo7.Vtbl>, IComIID
{
    public static implicit operator ICorProfilerInfo6(ICorProfilerInfo7 info) => info;
    public static implicit operator ICorProfilerInfo5(ICorProfilerInfo7 info) => info;
    public static implicit operator ICorProfilerInfo4(ICorProfilerInfo7 info) => info;
    public static implicit operator ICorProfilerInfo3(ICorProfilerInfo7 info) => info;
    public static implicit operator ICorProfilerInfo2(ICorProfilerInfo7 info) => info;
    public static implicit operator ICorProfilerInfo(ICorProfilerInfo7 info) => info;
}

public unsafe partial struct ICorProfilerInfo8 : IVTable<ICorProfilerInfo8, ICorProfilerInfo8.Vtbl>, IComIID
{
    public static implicit operator ICorProfilerInfo7(ICorProfilerInfo8 info) => info;
    public static implicit operator ICorProfilerInfo6(ICorProfilerInfo8 info) => info;
    public static implicit operator ICorProfilerInfo5(ICorProfilerInfo8 info) => info;
    public static implicit operator ICorProfilerInfo4(ICorProfilerInfo8 info) => info;
    public static implicit operator ICorProfilerInfo3(ICorProfilerInfo8 info) => info;
    public static implicit operator ICorProfilerInfo2(ICorProfilerInfo8 info) => info;
    public static implicit operator ICorProfilerInfo(ICorProfilerInfo8 info) => info;
}

public unsafe partial struct ICorProfilerInfo9 : IVTable<ICorProfilerInfo9, ICorProfilerInfo9.Vtbl>, IComIID
{
    public static implicit operator ICorProfilerInfo8(ICorProfilerInfo9 info) => info;
    public static implicit operator ICorProfilerInfo7(ICorProfilerInfo9 info) => info;
    public static implicit operator ICorProfilerInfo6(ICorProfilerInfo9 info) => info;
    public static implicit operator ICorProfilerInfo5(ICorProfilerInfo9 info) => info;
    public static implicit operator ICorProfilerInfo4(ICorProfilerInfo9 info) => info;
    public static implicit operator ICorProfilerInfo3(ICorProfilerInfo9 info) => info;
    public static implicit operator ICorProfilerInfo2(ICorProfilerInfo9 info) => info;
    public static implicit operator ICorProfilerInfo(ICorProfilerInfo9 info) => info;
}

public unsafe partial struct ICorProfilerInfo10 : IVTable<ICorProfilerInfo10, ICorProfilerInfo10.Vtbl>, IComIID
{
    public static implicit operator ICorProfilerInfo9(ICorProfilerInfo10 info) => info;
    public static implicit operator ICorProfilerInfo8(ICorProfilerInfo10 info) => info;
    public static implicit operator ICorProfilerInfo7(ICorProfilerInfo10 info) => info;
    public static implicit operator ICorProfilerInfo6(ICorProfilerInfo10 info) => info;
    public static implicit operator ICorProfilerInfo5(ICorProfilerInfo10 info) => info;
    public static implicit operator ICorProfilerInfo4(ICorProfilerInfo10 info) => info;
    public static implicit operator ICorProfilerInfo3(ICorProfilerInfo10 info) => info;
    public static implicit operator ICorProfilerInfo2(ICorProfilerInfo10 info) => info;
    public static implicit operator ICorProfilerInfo(ICorProfilerInfo10 info) => info;
}

public unsafe partial struct ICorProfilerInfo11 : IVTable<ICorProfilerInfo11, ICorProfilerInfo11.Vtbl>, IComIID
{
    public static implicit operator ICorProfilerInfo10(ICorProfilerInfo11 info) => info;
    public static implicit operator ICorProfilerInfo9(ICorProfilerInfo11 info) => info;
    public static implicit operator ICorProfilerInfo8(ICorProfilerInfo11 info) => info;
    public static implicit operator ICorProfilerInfo7(ICorProfilerInfo11 info) => info;
    public static implicit operator ICorProfilerInfo6(ICorProfilerInfo11 info) => info;
    public static implicit operator ICorProfilerInfo5(ICorProfilerInfo11 info) => info;
    public static implicit operator ICorProfilerInfo4(ICorProfilerInfo11 info) => info;
    public static implicit operator ICorProfilerInfo3(ICorProfilerInfo11 info) => info;
    public static implicit operator ICorProfilerInfo(ICorProfilerInfo11 info) => info;

    public static implicit operator ICorProfilerInfo2*(ICorProfilerInfo11 pInfo) => (ICorProfilerInfo2*)&pInfo;
}

public unsafe partial struct ICorProfilerInfo12 : IVTable<ICorProfilerInfo12, ICorProfilerInfo12.Vtbl>, IComIID
{
    public static implicit operator ICorProfilerInfo11(ICorProfilerInfo12 info) => info;
    public static implicit operator ICorProfilerInfo10(ICorProfilerInfo12 info) => info;
    public static implicit operator ICorProfilerInfo9(ICorProfilerInfo12 info) => info;
    public static implicit operator ICorProfilerInfo8(ICorProfilerInfo12 info) => info;
    public static implicit operator ICorProfilerInfo7(ICorProfilerInfo12 info) => info;
    public static implicit operator ICorProfilerInfo6(ICorProfilerInfo12 info) => info;
    public static implicit operator ICorProfilerInfo5(ICorProfilerInfo12 info) => info;
    public static implicit operator ICorProfilerInfo4(ICorProfilerInfo12 info) => info;
    public static implicit operator ICorProfilerInfo3(ICorProfilerInfo12 info) => info;
    public static implicit operator ICorProfilerInfo2(ICorProfilerInfo12 info) => info;
    public static implicit operator ICorProfilerInfo(ICorProfilerInfo12 info) => info;
}

public unsafe partial struct ICorProfilerInfo13 : IVTable<ICorProfilerInfo13, ICorProfilerInfo13.Vtbl>, IComIID
{
    public static implicit operator ICorProfilerInfo12(ICorProfilerInfo13 info) => info;
    public static implicit operator ICorProfilerInfo11(ICorProfilerInfo13 info) => info;
    public static implicit operator ICorProfilerInfo10(ICorProfilerInfo13 info) => info;
    public static implicit operator ICorProfilerInfo9(ICorProfilerInfo13 info) => info;
    public static implicit operator ICorProfilerInfo8(ICorProfilerInfo13 info) => info;
    public static implicit operator ICorProfilerInfo7(ICorProfilerInfo13 info) => info;
    public static implicit operator ICorProfilerInfo6(ICorProfilerInfo13 info) => info;
    public static implicit operator ICorProfilerInfo5(ICorProfilerInfo13 info) => info;
    public static implicit operator ICorProfilerInfo4(ICorProfilerInfo13 info) => info;
    public static implicit operator ICorProfilerInfo3(ICorProfilerInfo13 info) => info;
    public static implicit operator ICorProfilerInfo2(ICorProfilerInfo13 info) => info;
    public static implicit operator ICorProfilerInfo(ICorProfilerInfo13 info) => info;
}