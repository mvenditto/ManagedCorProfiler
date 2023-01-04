using System;
using System.Runtime.CompilerServices;

namespace CorProf.Bindings
{
    [NativeTypeName("struct IMetaDataTables : IUnknown")]
    public unsafe partial struct IMetaDataTables
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, Guid*, void**, int>)(lpVtbl[0]))((IMetaDataTables*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint>)(lpVtbl[1]))((IMetaDataTables*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint>)(lpVtbl[2]))((IMetaDataTables*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int GetStringHeapSize([NativeTypeName("ULONG *")] uint* pcbStrings)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint*, int>)(lpVtbl[3]))((IMetaDataTables*)Unsafe.AsPointer(ref this), pcbStrings);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int GetBlobHeapSize([NativeTypeName("ULONG *")] uint* pcbBlobs)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint*, int>)(lpVtbl[4]))((IMetaDataTables*)Unsafe.AsPointer(ref this), pcbBlobs);
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int GetGuidHeapSize([NativeTypeName("ULONG *")] uint* pcbGuids)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint*, int>)(lpVtbl[5]))((IMetaDataTables*)Unsafe.AsPointer(ref this), pcbGuids);
        }

        [VtblIndex(6)]
        [return: NativeTypeName("HRESULT")]
        public int GetUserStringHeapSize([NativeTypeName("ULONG *")] uint* pcbBlobs)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint*, int>)(lpVtbl[6]))((IMetaDataTables*)Unsafe.AsPointer(ref this), pcbBlobs);
        }

        [VtblIndex(7)]
        [return: NativeTypeName("HRESULT")]
        public int GetNumTables([NativeTypeName("ULONG *")] uint* pcTables)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint*, int>)(lpVtbl[7]))((IMetaDataTables*)Unsafe.AsPointer(ref this), pcTables);
        }

        [VtblIndex(8)]
        [return: NativeTypeName("HRESULT")]
        public int GetTableIndex([NativeTypeName("ULONG")] uint token, [NativeTypeName("ULONG *")] uint* pixTbl)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint, uint*, int>)(lpVtbl[8]))((IMetaDataTables*)Unsafe.AsPointer(ref this), token, pixTbl);
        }

        [VtblIndex(9)]
        [return: NativeTypeName("HRESULT")]
        public int GetTableInfo([NativeTypeName("ULONG")] uint ixTbl, [NativeTypeName("ULONG *")] uint* pcbRow, [NativeTypeName("ULONG *")] uint* pcRows, [NativeTypeName("ULONG *")] uint* pcCols, [NativeTypeName("ULONG *")] uint* piKey, [NativeTypeName("const char **")] sbyte** ppName)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint, uint*, uint*, uint*, uint*, sbyte**, int>)(lpVtbl[9]))((IMetaDataTables*)Unsafe.AsPointer(ref this), ixTbl, pcbRow, pcRows, pcCols, piKey, ppName);
        }

        [VtblIndex(10)]
        [return: NativeTypeName("HRESULT")]
        public int GetColumnInfo([NativeTypeName("ULONG")] uint ixTbl, [NativeTypeName("ULONG")] uint ixCol, [NativeTypeName("ULONG *")] uint* poCol, [NativeTypeName("ULONG *")] uint* pcbCol, [NativeTypeName("ULONG *")] uint* pType, [NativeTypeName("const char **")] sbyte** ppName)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint, uint, uint*, uint*, uint*, sbyte**, int>)(lpVtbl[10]))((IMetaDataTables*)Unsafe.AsPointer(ref this), ixTbl, ixCol, poCol, pcbCol, pType, ppName);
        }

        [VtblIndex(11)]
        [return: NativeTypeName("HRESULT")]
        public int GetCodedTokenInfo([NativeTypeName("ULONG")] uint ixCdTkn, [NativeTypeName("ULONG *")] uint* pcTokens, [NativeTypeName("ULONG **")] uint** ppTokens, [NativeTypeName("const char **")] sbyte** ppName)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint, uint*, uint**, sbyte**, int>)(lpVtbl[11]))((IMetaDataTables*)Unsafe.AsPointer(ref this), ixCdTkn, pcTokens, ppTokens, ppName);
        }

        [VtblIndex(12)]
        [return: NativeTypeName("HRESULT")]
        public int GetRow([NativeTypeName("ULONG")] uint ixTbl, [NativeTypeName("ULONG")] uint rid, void** ppRow)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint, uint, void**, int>)(lpVtbl[12]))((IMetaDataTables*)Unsafe.AsPointer(ref this), ixTbl, rid, ppRow);
        }

        [VtblIndex(13)]
        [return: NativeTypeName("HRESULT")]
        public int GetColumn([NativeTypeName("ULONG")] uint ixTbl, [NativeTypeName("ULONG")] uint ixCol, [NativeTypeName("ULONG")] uint rid, [NativeTypeName("ULONG *")] uint* pVal)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint, uint, uint, uint*, int>)(lpVtbl[13]))((IMetaDataTables*)Unsafe.AsPointer(ref this), ixTbl, ixCol, rid, pVal);
        }

        [VtblIndex(14)]
        [return: NativeTypeName("HRESULT")]
        public int GetString([NativeTypeName("ULONG")] uint ixString, [NativeTypeName("const char **")] sbyte** ppString)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint, sbyte**, int>)(lpVtbl[14]))((IMetaDataTables*)Unsafe.AsPointer(ref this), ixString, ppString);
        }

        [VtblIndex(15)]
        [return: NativeTypeName("HRESULT")]
        public int GetBlob([NativeTypeName("ULONG")] uint ixBlob, [NativeTypeName("ULONG *")] uint* pcbData, [NativeTypeName("const void **")] void** ppData)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint, uint*, void**, int>)(lpVtbl[15]))((IMetaDataTables*)Unsafe.AsPointer(ref this), ixBlob, pcbData, ppData);
        }

        [VtblIndex(16)]
        [return: NativeTypeName("HRESULT")]
        public int GetGuid([NativeTypeName("ULONG")] uint ixGuid, [NativeTypeName("const GUID **")] Guid** ppGUID)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint, Guid**, int>)(lpVtbl[16]))((IMetaDataTables*)Unsafe.AsPointer(ref this), ixGuid, ppGUID);
        }

        [VtblIndex(17)]
        [return: NativeTypeName("HRESULT")]
        public int GetUserString([NativeTypeName("ULONG")] uint ixUserString, [NativeTypeName("ULONG *")] uint* pcbData, [NativeTypeName("const void **")] void** ppData)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint, uint*, void**, int>)(lpVtbl[17]))((IMetaDataTables*)Unsafe.AsPointer(ref this), ixUserString, pcbData, ppData);
        }

        [VtblIndex(18)]
        [return: NativeTypeName("HRESULT")]
        public int GetNextString([NativeTypeName("ULONG")] uint ixString, [NativeTypeName("ULONG *")] uint* pNext)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint, uint*, int>)(lpVtbl[18]))((IMetaDataTables*)Unsafe.AsPointer(ref this), ixString, pNext);
        }

        [VtblIndex(19)]
        [return: NativeTypeName("HRESULT")]
        public int GetNextBlob([NativeTypeName("ULONG")] uint ixBlob, [NativeTypeName("ULONG *")] uint* pNext)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint, uint*, int>)(lpVtbl[19]))((IMetaDataTables*)Unsafe.AsPointer(ref this), ixBlob, pNext);
        }

        [VtblIndex(20)]
        [return: NativeTypeName("HRESULT")]
        public int GetNextGuid([NativeTypeName("ULONG")] uint ixGuid, [NativeTypeName("ULONG *")] uint* pNext)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint, uint*, int>)(lpVtbl[20]))((IMetaDataTables*)Unsafe.AsPointer(ref this), ixGuid, pNext);
        }

        [VtblIndex(21)]
        [return: NativeTypeName("HRESULT")]
        public int GetNextUserString([NativeTypeName("ULONG")] uint ixUserString, [NativeTypeName("ULONG *")] uint* pNext)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataTables*, uint, uint*, int>)(lpVtbl[21]))((IMetaDataTables*)Unsafe.AsPointer(ref this), ixUserString, pNext);
        }
    }
}
