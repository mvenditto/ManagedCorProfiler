using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[Guid("CC0935CD-A518-487D-B0BB-A93214E65478")]
public unsafe partial struct ICorProfilerInfo2
{
    public void** lpVtbl;

    public int SetEventMask(uint dwEvents)
    {
        return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, uint, int>)(lpVtbl[16]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), dwEvents);
    }

    public int GetModuleInfo(ulong moduleId, byte** ppBaseLoadAddress, uint cchName, uint* pcchName, ushort* szName, ulong* pAssemblyId)
    {
        return ((delegate* unmanaged[Stdcall]<ICorProfilerInfo2*, ulong, byte**, uint, uint*, ushort*, ulong*, int>)(lpVtbl[20]))((ICorProfilerInfo2*)Unsafe.AsPointer(ref this), moduleId, ppBaseLoadAddress, cchName, pcchName, szName, pAssemblyId);
    }
}