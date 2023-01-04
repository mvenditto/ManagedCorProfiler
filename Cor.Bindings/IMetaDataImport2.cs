using System;
using System.Runtime.CompilerServices;

namespace CorProf.Bindings
{
    [NativeTypeName("struct IMetaDataImport2 : IMetaDataImport")]
    public unsafe partial struct IMetaDataImport2
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, Guid*, void**, int>)(lpVtbl[0]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint>)(lpVtbl[1]))((IMetaDataImport2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint>)(lpVtbl[2]))((IMetaDataImport2*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        public void CloseEnum([NativeTypeName("HCORENUM")] void* hEnum)
        {
            ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void*, void>)(lpVtbl[3]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), hEnum);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int CountEnum([NativeTypeName("HCORENUM")] void* hEnum, [NativeTypeName("ULONG *")] uint* pulCount)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void*, uint*, int>)(lpVtbl[4]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), hEnum, pulCount);
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int ResetEnum([NativeTypeName("HCORENUM")] void* hEnum, [NativeTypeName("ULONG")] uint ulPos)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void*, uint, int>)(lpVtbl[5]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), hEnum, ulPos);
        }

        [VtblIndex(6)]
        [return: NativeTypeName("HRESULT")]
        public int EnumTypeDefs([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdTypeDef[]")] uint* rTypeDefs, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTypeDefs)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint*, uint, uint*, int>)(lpVtbl[6]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, rTypeDefs, cMax, pcTypeDefs);
        }

        [VtblIndex(7)]
        [return: NativeTypeName("HRESULT")]
        public int EnumInterfaceImpls([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdTypeDef")] uint td, [NativeTypeName("mdInterfaceImpl[]")] uint* rImpls, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcImpls)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, uint*, uint, uint*, int>)(lpVtbl[7]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, td, rImpls, cMax, pcImpls);
        }

        [VtblIndex(8)]
        [return: NativeTypeName("HRESULT")]
        public int EnumTypeRefs([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdTypeRef[]")] uint* rTypeRefs, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTypeRefs)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint*, uint, uint*, int>)(lpVtbl[8]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, rTypeRefs, cMax, pcTypeRefs);
        }

        [VtblIndex(9)]
        [return: NativeTypeName("HRESULT")]
        public int FindTypeDefByName([NativeTypeName("LPCWSTR")] ushort* szTypeDef, [NativeTypeName("mdToken")] uint tkEnclosingClass, [NativeTypeName("mdTypeDef *")] uint* ptd)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, ushort*, uint, uint*, int>)(lpVtbl[9]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), szTypeDef, tkEnclosingClass, ptd);
        }

        [VtblIndex(10)]
        [return: NativeTypeName("HRESULT")]
        public int GetScopeProps([NativeTypeName("LPWSTR")] ushort* szName, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pchName, Guid* pmvid)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, ushort*, uint, uint*, Guid*, int>)(lpVtbl[10]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), szName, cchName, pchName, pmvid);
        }

        [VtblIndex(11)]
        [return: NativeTypeName("HRESULT")]
        public int GetModuleFromScope([NativeTypeName("mdModule *")] uint* pmd)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint*, int>)(lpVtbl[11]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), pmd);
        }

        [VtblIndex(12)]
        [return: NativeTypeName("HRESULT")]
        public int GetTypeDefProps([NativeTypeName("mdTypeDef")] uint td, [NativeTypeName("LPWSTR")] ushort* szTypeDef, [NativeTypeName("ULONG")] uint cchTypeDef, [NativeTypeName("ULONG *")] uint* pchTypeDef, [NativeTypeName("DWORD *")] uint* pdwTypeDefFlags, [NativeTypeName("mdToken *")] uint* ptkExtends)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, ushort*, uint, uint*, uint*, uint*, int>)(lpVtbl[12]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), td, szTypeDef, cchTypeDef, pchTypeDef, pdwTypeDefFlags, ptkExtends);
        }

        [VtblIndex(13)]
        [return: NativeTypeName("HRESULT")]
        public int GetInterfaceImplProps([NativeTypeName("mdInterfaceImpl")] uint iiImpl, [NativeTypeName("mdTypeDef *")] uint* pClass, [NativeTypeName("mdToken *")] uint* ptkIface)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, uint*, int>)(lpVtbl[13]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), iiImpl, pClass, ptkIface);
        }

        [VtblIndex(14)]
        [return: NativeTypeName("HRESULT")]
        public int GetTypeRefProps([NativeTypeName("mdTypeRef")] uint tr, [NativeTypeName("mdToken *")] uint* ptkResolutionScope, [NativeTypeName("LPWSTR")] ushort* szName, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pchName)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, ushort*, uint, uint*, int>)(lpVtbl[14]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), tr, ptkResolutionScope, szName, cchName, pchName);
        }

        [VtblIndex(15)]
        [return: NativeTypeName("HRESULT")]
        public int ResolveTypeRef([NativeTypeName("mdTypeRef")] uint tr, [NativeTypeName("const IID &")] Guid* riid, IUnknown** ppIScope, [NativeTypeName("mdTypeDef *")] uint* ptd)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, Guid*, IUnknown**, uint*, int>)(lpVtbl[15]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), tr, riid, ppIScope, ptd);
        }

        [VtblIndex(16)]
        [return: NativeTypeName("HRESULT")]
        public int EnumMembers([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdTypeDef")] uint cl, [NativeTypeName("mdToken[]")] uint* rMembers, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTokens)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, uint*, uint, uint*, int>)(lpVtbl[16]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, cl, rMembers, cMax, pcTokens);
        }

        [VtblIndex(17)]
        [return: NativeTypeName("HRESULT")]
        public int EnumMembersWithName([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdTypeDef")] uint cl, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("mdToken[]")] uint* rMembers, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTokens)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, ushort*, uint*, uint, uint*, int>)(lpVtbl[17]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, cl, szName, rMembers, cMax, pcTokens);
        }

        [VtblIndex(18)]
        [return: NativeTypeName("HRESULT")]
        public int EnumMethods([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdTypeDef")] uint cl, [NativeTypeName("mdMethodDef[]")] uint* rMethods, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTokens)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, uint*, uint, uint*, int>)(lpVtbl[18]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, cl, rMethods, cMax, pcTokens);
        }

        [VtblIndex(19)]
        [return: NativeTypeName("HRESULT")]
        public int EnumMethodsWithName([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdTypeDef")] uint cl, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("mdMethodDef[]")] uint* rMethods, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTokens)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, ushort*, uint*, uint, uint*, int>)(lpVtbl[19]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, cl, szName, rMethods, cMax, pcTokens);
        }

        [VtblIndex(20)]
        [return: NativeTypeName("HRESULT")]
        public int EnumFields([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdTypeDef")] uint cl, [NativeTypeName("mdFieldDef[]")] uint* rFields, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTokens)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, uint*, uint, uint*, int>)(lpVtbl[20]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, cl, rFields, cMax, pcTokens);
        }

        [VtblIndex(21)]
        [return: NativeTypeName("HRESULT")]
        public int EnumFieldsWithName([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdTypeDef")] uint cl, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("mdFieldDef[]")] uint* rFields, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTokens)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, ushort*, uint*, uint, uint*, int>)(lpVtbl[21]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, cl, szName, rFields, cMax, pcTokens);
        }

        [VtblIndex(22)]
        [return: NativeTypeName("HRESULT")]
        public int EnumParams([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdMethodDef")] uint mb, [NativeTypeName("mdParamDef[]")] uint* rParams, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTokens)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, uint*, uint, uint*, int>)(lpVtbl[22]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, mb, rParams, cMax, pcTokens);
        }

        [VtblIndex(23)]
        [return: NativeTypeName("HRESULT")]
        public int EnumMemberRefs([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdToken")] uint tkParent, [NativeTypeName("mdMemberRef[]")] uint* rMemberRefs, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTokens)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, uint*, uint, uint*, int>)(lpVtbl[23]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, tkParent, rMemberRefs, cMax, pcTokens);
        }

        [VtblIndex(24)]
        [return: NativeTypeName("HRESULT")]
        public int EnumMethodImpls([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdTypeDef")] uint td, [NativeTypeName("mdToken[]")] uint* rMethodBody, [NativeTypeName("mdToken[]")] uint* rMethodDecl, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTokens)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, uint*, uint*, uint, uint*, int>)(lpVtbl[24]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, td, rMethodBody, rMethodDecl, cMax, pcTokens);
        }

        [VtblIndex(25)]
        [return: NativeTypeName("HRESULT")]
        public int EnumPermissionSets([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdToken")] uint tk, [NativeTypeName("DWORD")] uint dwActions, [NativeTypeName("mdPermission[]")] uint* rPermission, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTokens)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, uint, uint*, uint, uint*, int>)(lpVtbl[25]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, tk, dwActions, rPermission, cMax, pcTokens);
        }

        [VtblIndex(26)]
        [return: NativeTypeName("HRESULT")]
        public int FindMember([NativeTypeName("mdTypeDef")] uint td, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("PCCOR_SIGNATURE")] byte* pvSigBlob, [NativeTypeName("ULONG")] uint cbSigBlob, [NativeTypeName("mdToken *")] uint* pmb)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, ushort*, byte*, uint, uint*, int>)(lpVtbl[26]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), td, szName, pvSigBlob, cbSigBlob, pmb);
        }

        [VtblIndex(27)]
        [return: NativeTypeName("HRESULT")]
        public int FindMethod([NativeTypeName("mdTypeDef")] uint td, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("PCCOR_SIGNATURE")] byte* pvSigBlob, [NativeTypeName("ULONG")] uint cbSigBlob, [NativeTypeName("mdMethodDef *")] uint* pmb)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, ushort*, byte*, uint, uint*, int>)(lpVtbl[27]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), td, szName, pvSigBlob, cbSigBlob, pmb);
        }

        [VtblIndex(28)]
        [return: NativeTypeName("HRESULT")]
        public int FindField([NativeTypeName("mdTypeDef")] uint td, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("PCCOR_SIGNATURE")] byte* pvSigBlob, [NativeTypeName("ULONG")] uint cbSigBlob, [NativeTypeName("mdFieldDef *")] uint* pmb)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, ushort*, byte*, uint, uint*, int>)(lpVtbl[28]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), td, szName, pvSigBlob, cbSigBlob, pmb);
        }

        [VtblIndex(29)]
        [return: NativeTypeName("HRESULT")]
        public int FindMemberRef([NativeTypeName("mdTypeRef")] uint td, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("PCCOR_SIGNATURE")] byte* pvSigBlob, [NativeTypeName("ULONG")] uint cbSigBlob, [NativeTypeName("mdMemberRef *")] uint* pmr)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, ushort*, byte*, uint, uint*, int>)(lpVtbl[29]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), td, szName, pvSigBlob, cbSigBlob, pmr);
        }

        [VtblIndex(30)]
        [return: NativeTypeName("HRESULT")]
        public int GetMethodProps([NativeTypeName("mdMethodDef")] uint mb, [NativeTypeName("mdTypeDef *")] uint* pClass, [NativeTypeName("LPWSTR")] ushort* szMethod, [NativeTypeName("ULONG")] uint cchMethod, [NativeTypeName("ULONG *")] uint* pchMethod, [NativeTypeName("DWORD *")] uint* pdwAttr, [NativeTypeName("PCCOR_SIGNATURE *")] byte** ppvSigBlob, [NativeTypeName("ULONG *")] uint* pcbSigBlob, [NativeTypeName("ULONG *")] uint* pulCodeRVA, [NativeTypeName("DWORD *")] uint* pdwImplFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, ushort*, uint, uint*, uint*, byte**, uint*, uint*, uint*, int>)(lpVtbl[30]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), mb, pClass, szMethod, cchMethod, pchMethod, pdwAttr, ppvSigBlob, pcbSigBlob, pulCodeRVA, pdwImplFlags);
        }

        [VtblIndex(31)]
        [return: NativeTypeName("HRESULT")]
        public int GetMemberRefProps([NativeTypeName("mdMemberRef")] uint mr, [NativeTypeName("mdToken *")] uint* ptk, [NativeTypeName("LPWSTR")] ushort* szMember, [NativeTypeName("ULONG")] uint cchMember, [NativeTypeName("ULONG *")] uint* pchMember, [NativeTypeName("PCCOR_SIGNATURE *")] byte** ppvSigBlob, [NativeTypeName("ULONG *")] uint* pbSig)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, ushort*, uint, uint*, byte**, uint*, int>)(lpVtbl[31]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), mr, ptk, szMember, cchMember, pchMember, ppvSigBlob, pbSig);
        }

        [VtblIndex(32)]
        [return: NativeTypeName("HRESULT")]
        public int EnumProperties([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdTypeDef")] uint td, [NativeTypeName("mdProperty[]")] uint* rProperties, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcProperties)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, uint*, uint, uint*, int>)(lpVtbl[32]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, td, rProperties, cMax, pcProperties);
        }

        [VtblIndex(33)]
        [return: NativeTypeName("HRESULT")]
        public int EnumEvents([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdTypeDef")] uint td, [NativeTypeName("mdEvent[]")] uint* rEvents, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcEvents)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, uint*, uint, uint*, int>)(lpVtbl[33]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, td, rEvents, cMax, pcEvents);
        }

        [VtblIndex(34)]
        [return: NativeTypeName("HRESULT")]
        public int GetEventProps([NativeTypeName("mdEvent")] uint ev, [NativeTypeName("mdTypeDef *")] uint* pClass, [NativeTypeName("LPCWSTR")] ushort* szEvent, [NativeTypeName("ULONG")] uint cchEvent, [NativeTypeName("ULONG *")] uint* pchEvent, [NativeTypeName("DWORD *")] uint* pdwEventFlags, [NativeTypeName("mdToken *")] uint* ptkEventType, [NativeTypeName("mdMethodDef *")] uint* pmdAddOn, [NativeTypeName("mdMethodDef *")] uint* pmdRemoveOn, [NativeTypeName("mdMethodDef *")] uint* pmdFire, [NativeTypeName("mdMethodDef[]")] uint* rmdOtherMethod, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcOtherMethod)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, ushort*, uint, uint*, uint*, uint*, uint*, uint*, uint*, uint*, uint, uint*, int>)(lpVtbl[34]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), ev, pClass, szEvent, cchEvent, pchEvent, pdwEventFlags, ptkEventType, pmdAddOn, pmdRemoveOn, pmdFire, rmdOtherMethod, cMax, pcOtherMethod);
        }

        [VtblIndex(35)]
        [return: NativeTypeName("HRESULT")]
        public int EnumMethodSemantics([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdMethodDef")] uint mb, [NativeTypeName("mdToken[]")] uint* rEventProp, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcEventProp)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, uint*, uint, uint*, int>)(lpVtbl[35]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, mb, rEventProp, cMax, pcEventProp);
        }

        [VtblIndex(36)]
        [return: NativeTypeName("HRESULT")]
        public int GetMethodSemantics([NativeTypeName("mdMethodDef")] uint mb, [NativeTypeName("mdToken")] uint tkEventProp, [NativeTypeName("DWORD *")] uint* pdwSemanticsFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint, uint*, int>)(lpVtbl[36]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), mb, tkEventProp, pdwSemanticsFlags);
        }

        [VtblIndex(37)]
        [return: NativeTypeName("HRESULT")]
        public int GetClassLayout([NativeTypeName("mdTypeDef")] uint td, [NativeTypeName("DWORD *")] uint* pdwPackSize, [NativeTypeName("COR_FIELD_OFFSET[]")] COR_FIELD_OFFSET* rFieldOffset, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcFieldOffset, [NativeTypeName("ULONG *")] uint* pulClassSize)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, COR_FIELD_OFFSET*, uint, uint*, uint*, int>)(lpVtbl[37]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), td, pdwPackSize, rFieldOffset, cMax, pcFieldOffset, pulClassSize);
        }

        [VtblIndex(38)]
        [return: NativeTypeName("HRESULT")]
        public int GetFieldMarshal([NativeTypeName("mdToken")] uint tk, [NativeTypeName("PCCOR_SIGNATURE *")] byte** ppvNativeType, [NativeTypeName("ULONG *")] uint* pcbNativeType)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, byte**, uint*, int>)(lpVtbl[38]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), tk, ppvNativeType, pcbNativeType);
        }

        [VtblIndex(39)]
        [return: NativeTypeName("HRESULT")]
        public int GetRVA([NativeTypeName("mdToken")] uint tk, [NativeTypeName("ULONG *")] uint* pulCodeRVA, [NativeTypeName("DWORD *")] uint* pdwImplFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, uint*, int>)(lpVtbl[39]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), tk, pulCodeRVA, pdwImplFlags);
        }

        [VtblIndex(40)]
        [return: NativeTypeName("HRESULT")]
        public int GetPermissionSetProps([NativeTypeName("mdPermission")] uint pm, [NativeTypeName("DWORD *")] uint* pdwAction, [NativeTypeName("const void **")] void** ppvPermission, [NativeTypeName("ULONG *")] uint* pcbPermission)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, void**, uint*, int>)(lpVtbl[40]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), pm, pdwAction, ppvPermission, pcbPermission);
        }

        [VtblIndex(41)]
        [return: NativeTypeName("HRESULT")]
        public int GetSigFromToken([NativeTypeName("mdSignature")] uint mdSig, [NativeTypeName("PCCOR_SIGNATURE *")] byte** ppvSig, [NativeTypeName("ULONG *")] uint* pcbSig)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, byte**, uint*, int>)(lpVtbl[41]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), mdSig, ppvSig, pcbSig);
        }

        [VtblIndex(42)]
        [return: NativeTypeName("HRESULT")]
        public int GetModuleRefProps([NativeTypeName("mdModuleRef")] uint mur, [NativeTypeName("LPWSTR")] ushort* szName, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pchName)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, ushort*, uint, uint*, int>)(lpVtbl[42]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), mur, szName, cchName, pchName);
        }

        [VtblIndex(43)]
        [return: NativeTypeName("HRESULT")]
        public int EnumModuleRefs([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdModuleRef[]")] uint* rModuleRefs, [NativeTypeName("ULONG")] uint cmax, [NativeTypeName("ULONG *")] uint* pcModuleRefs)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint*, uint, uint*, int>)(lpVtbl[43]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, rModuleRefs, cmax, pcModuleRefs);
        }

        [VtblIndex(44)]
        [return: NativeTypeName("HRESULT")]
        public int GetTypeSpecFromToken([NativeTypeName("mdTypeSpec")] uint typespec, [NativeTypeName("PCCOR_SIGNATURE *")] byte** ppvSig, [NativeTypeName("ULONG *")] uint* pcbSig)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, byte**, uint*, int>)(lpVtbl[44]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), typespec, ppvSig, pcbSig);
        }

        [VtblIndex(45)]
        [return: NativeTypeName("HRESULT")]
        public int GetNameFromToken([NativeTypeName("mdToken")] uint tk, [NativeTypeName("MDUTF8CSTR *")] sbyte** pszUtf8NamePtr)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, sbyte**, int>)(lpVtbl[45]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), tk, pszUtf8NamePtr);
        }

        [VtblIndex(46)]
        [return: NativeTypeName("HRESULT")]
        public int EnumUnresolvedMethods([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdToken[]")] uint* rMethods, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcTokens)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint*, uint, uint*, int>)(lpVtbl[46]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, rMethods, cMax, pcTokens);
        }

        [VtblIndex(47)]
        [return: NativeTypeName("HRESULT")]
        public int GetUserString([NativeTypeName("mdString")] uint stk, [NativeTypeName("LPWSTR")] ushort* szString, [NativeTypeName("ULONG")] uint cchString, [NativeTypeName("ULONG *")] uint* pchString)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, ushort*, uint, uint*, int>)(lpVtbl[47]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), stk, szString, cchString, pchString);
        }

        [VtblIndex(48)]
        [return: NativeTypeName("HRESULT")]
        public int GetPinvokeMap([NativeTypeName("mdToken")] uint tk, [NativeTypeName("DWORD *")] uint* pdwMappingFlags, [NativeTypeName("LPWSTR")] ushort* szImportName, [NativeTypeName("ULONG")] uint cchImportName, [NativeTypeName("ULONG *")] uint* pchImportName, [NativeTypeName("mdModuleRef *")] uint* pmrImportDLL)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, ushort*, uint, uint*, uint*, int>)(lpVtbl[48]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), tk, pdwMappingFlags, szImportName, cchImportName, pchImportName, pmrImportDLL);
        }

        [VtblIndex(49)]
        [return: NativeTypeName("HRESULT")]
        public int EnumSignatures([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdSignature[]")] uint* rSignatures, [NativeTypeName("ULONG")] uint cmax, [NativeTypeName("ULONG *")] uint* pcSignatures)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint*, uint, uint*, int>)(lpVtbl[49]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, rSignatures, cmax, pcSignatures);
        }

        [VtblIndex(50)]
        [return: NativeTypeName("HRESULT")]
        public int EnumTypeSpecs([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdTypeSpec[]")] uint* rTypeSpecs, [NativeTypeName("ULONG")] uint cmax, [NativeTypeName("ULONG *")] uint* pcTypeSpecs)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint*, uint, uint*, int>)(lpVtbl[50]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, rTypeSpecs, cmax, pcTypeSpecs);
        }

        [VtblIndex(51)]
        [return: NativeTypeName("HRESULT")]
        public int EnumUserStrings([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdString[]")] uint* rStrings, [NativeTypeName("ULONG")] uint cmax, [NativeTypeName("ULONG *")] uint* pcStrings)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint*, uint, uint*, int>)(lpVtbl[51]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, rStrings, cmax, pcStrings);
        }

        [VtblIndex(52)]
        [return: NativeTypeName("HRESULT")]
        public int GetParamForMethodIndex([NativeTypeName("mdMethodDef")] uint md, [NativeTypeName("ULONG")] uint ulParamSeq, [NativeTypeName("mdParamDef *")] uint* ppd)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint, uint*, int>)(lpVtbl[52]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), md, ulParamSeq, ppd);
        }

        [VtblIndex(53)]
        [return: NativeTypeName("HRESULT")]
        public int EnumCustomAttributes([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdToken")] uint tk, [NativeTypeName("mdToken")] uint tkType, [NativeTypeName("mdCustomAttribute[]")] uint* rCustomAttributes, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcCustomAttributes)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, uint, uint*, uint, uint*, int>)(lpVtbl[53]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, tk, tkType, rCustomAttributes, cMax, pcCustomAttributes);
        }

        [VtblIndex(54)]
        [return: NativeTypeName("HRESULT")]
        public int GetCustomAttributeProps([NativeTypeName("mdCustomAttribute")] uint cv, [NativeTypeName("mdToken *")] uint* ptkObj, [NativeTypeName("mdToken *")] uint* ptkType, [NativeTypeName("const void **")] void** ppBlob, [NativeTypeName("ULONG *")] uint* pcbSize)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, uint*, void**, uint*, int>)(lpVtbl[54]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), cv, ptkObj, ptkType, ppBlob, pcbSize);
        }

        [VtblIndex(55)]
        [return: NativeTypeName("HRESULT")]
        public int FindTypeRef([NativeTypeName("mdToken")] uint tkResolutionScope, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("mdTypeRef *")] uint* ptr)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, ushort*, uint*, int>)(lpVtbl[55]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), tkResolutionScope, szName, ptr);
        }

        [VtblIndex(56)]
        [return: NativeTypeName("HRESULT")]
        public int GetMemberProps([NativeTypeName("mdToken")] uint mb, [NativeTypeName("mdTypeDef *")] uint* pClass, [NativeTypeName("LPWSTR")] ushort* szMember, [NativeTypeName("ULONG")] uint cchMember, [NativeTypeName("ULONG *")] uint* pchMember, [NativeTypeName("DWORD *")] uint* pdwAttr, [NativeTypeName("PCCOR_SIGNATURE *")] byte** ppvSigBlob, [NativeTypeName("ULONG *")] uint* pcbSigBlob, [NativeTypeName("ULONG *")] uint* pulCodeRVA, [NativeTypeName("DWORD *")] uint* pdwImplFlags, [NativeTypeName("DWORD *")] uint* pdwCPlusTypeFlag, [NativeTypeName("UVCP_CONSTANT *")] void** ppValue, [NativeTypeName("ULONG *")] uint* pcchValue)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, ushort*, uint, uint*, uint*, byte**, uint*, uint*, uint*, uint*, void**, uint*, int>)(lpVtbl[56]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), mb, pClass, szMember, cchMember, pchMember, pdwAttr, ppvSigBlob, pcbSigBlob, pulCodeRVA, pdwImplFlags, pdwCPlusTypeFlag, ppValue, pcchValue);
        }

        [VtblIndex(57)]
        [return: NativeTypeName("HRESULT")]
        public int GetFieldProps([NativeTypeName("mdFieldDef")] uint mb, [NativeTypeName("mdTypeDef *")] uint* pClass, [NativeTypeName("LPWSTR")] ushort* szField, [NativeTypeName("ULONG")] uint cchField, [NativeTypeName("ULONG *")] uint* pchField, [NativeTypeName("DWORD *")] uint* pdwAttr, [NativeTypeName("PCCOR_SIGNATURE *")] byte** ppvSigBlob, [NativeTypeName("ULONG *")] uint* pcbSigBlob, [NativeTypeName("DWORD *")] uint* pdwCPlusTypeFlag, [NativeTypeName("UVCP_CONSTANT *")] void** ppValue, [NativeTypeName("ULONG *")] uint* pcchValue)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, ushort*, uint, uint*, uint*, byte**, uint*, uint*, void**, uint*, int>)(lpVtbl[57]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), mb, pClass, szField, cchField, pchField, pdwAttr, ppvSigBlob, pcbSigBlob, pdwCPlusTypeFlag, ppValue, pcchValue);
        }

        [VtblIndex(58)]
        [return: NativeTypeName("HRESULT")]
        public int GetPropertyProps([NativeTypeName("mdProperty")] uint prop, [NativeTypeName("mdTypeDef *")] uint* pClass, [NativeTypeName("LPCWSTR")] ushort* szProperty, [NativeTypeName("ULONG")] uint cchProperty, [NativeTypeName("ULONG *")] uint* pchProperty, [NativeTypeName("DWORD *")] uint* pdwPropFlags, [NativeTypeName("PCCOR_SIGNATURE *")] byte** ppvSig, [NativeTypeName("ULONG *")] uint* pbSig, [NativeTypeName("DWORD *")] uint* pdwCPlusTypeFlag, [NativeTypeName("UVCP_CONSTANT *")] void** ppDefaultValue, [NativeTypeName("ULONG *")] uint* pcchDefaultValue, [NativeTypeName("mdMethodDef *")] uint* pmdSetter, [NativeTypeName("mdMethodDef *")] uint* pmdGetter, [NativeTypeName("mdMethodDef[]")] uint* rmdOtherMethod, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcOtherMethod)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, ushort*, uint, uint*, uint*, byte**, uint*, uint*, void**, uint*, uint*, uint*, uint*, uint, uint*, int>)(lpVtbl[58]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), prop, pClass, szProperty, cchProperty, pchProperty, pdwPropFlags, ppvSig, pbSig, pdwCPlusTypeFlag, ppDefaultValue, pcchDefaultValue, pmdSetter, pmdGetter, rmdOtherMethod, cMax, pcOtherMethod);
        }

        [VtblIndex(59)]
        [return: NativeTypeName("HRESULT")]
        public int GetParamProps([NativeTypeName("mdParamDef")] uint tk, [NativeTypeName("mdMethodDef *")] uint* pmd, [NativeTypeName("ULONG *")] uint* pulSequence, [NativeTypeName("LPWSTR")] ushort* szName, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pchName, [NativeTypeName("DWORD *")] uint* pdwAttr, [NativeTypeName("DWORD *")] uint* pdwCPlusTypeFlag, [NativeTypeName("UVCP_CONSTANT *")] void** ppValue, [NativeTypeName("ULONG *")] uint* pcchValue)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, uint*, ushort*, uint, uint*, uint*, uint*, void**, uint*, int>)(lpVtbl[59]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), tk, pmd, pulSequence, szName, cchName, pchName, pdwAttr, pdwCPlusTypeFlag, ppValue, pcchValue);
        }

        [VtblIndex(60)]
        [return: NativeTypeName("HRESULT")]
        public int GetCustomAttributeByName([NativeTypeName("mdToken")] uint tkObj, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("const void **")] void** ppData, [NativeTypeName("ULONG *")] uint* pcbData)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, ushort*, void**, uint*, int>)(lpVtbl[60]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), tkObj, szName, ppData, pcbData);
        }

        [VtblIndex(61)]
        [return: NativeTypeName("BOOL")]
        public int IsValidToken([NativeTypeName("mdToken")] uint tk)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, int>)(lpVtbl[61]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), tk);
        }

        [VtblIndex(62)]
        [return: NativeTypeName("HRESULT")]
        public int GetNestedClassProps([NativeTypeName("mdTypeDef")] uint tdNestedClass, [NativeTypeName("mdTypeDef *")] uint* ptdEnclosingClass)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, int>)(lpVtbl[62]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), tdNestedClass, ptdEnclosingClass);
        }

        [VtblIndex(63)]
        [return: NativeTypeName("HRESULT")]
        public int GetNativeCallConvFromSig([NativeTypeName("const void *")] void* pvSig, [NativeTypeName("ULONG")] uint cbSig, [NativeTypeName("ULONG *")] uint* pCallConv)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void*, uint, uint*, int>)(lpVtbl[63]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), pvSig, cbSig, pCallConv);
        }

        [VtblIndex(64)]
        [return: NativeTypeName("HRESULT")]
        public int IsGlobal([NativeTypeName("mdToken")] uint pd, int* pbGlobal)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, int*, int>)(lpVtbl[64]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), pd, pbGlobal);
        }

        [VtblIndex(65)]
        [return: NativeTypeName("HRESULT")]
        public int EnumGenericParams([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdToken")] uint tk, [NativeTypeName("mdGenericParam[]")] uint* rGenericParams, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcGenericParams)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, uint*, uint, uint*, int>)(lpVtbl[65]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, tk, rGenericParams, cMax, pcGenericParams);
        }

        [VtblIndex(66)]
        [return: NativeTypeName("HRESULT")]
        public int GetGenericParamProps([NativeTypeName("mdGenericParam")] uint gp, [NativeTypeName("ULONG *")] uint* pulParamSeq, [NativeTypeName("DWORD *")] uint* pdwParamFlags, [NativeTypeName("mdToken *")] uint* ptOwner, [NativeTypeName("DWORD *")] uint* reserved, [NativeTypeName("LPWSTR")] ushort* wzname, [NativeTypeName("ULONG")] uint cchName, [NativeTypeName("ULONG *")] uint* pchName)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, uint*, uint*, uint*, ushort*, uint, uint*, int>)(lpVtbl[66]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), gp, pulParamSeq, pdwParamFlags, ptOwner, reserved, wzname, cchName, pchName);
        }

        [VtblIndex(67)]
        [return: NativeTypeName("HRESULT")]
        public int GetMethodSpecProps([NativeTypeName("mdMethodSpec")] uint mi, [NativeTypeName("mdToken *")] uint* tkParent, [NativeTypeName("PCCOR_SIGNATURE *")] byte** ppvSigBlob, [NativeTypeName("ULONG *")] uint* pcbSigBlob)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, byte**, uint*, int>)(lpVtbl[67]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), mi, tkParent, ppvSigBlob, pcbSigBlob);
        }

        [VtblIndex(68)]
        [return: NativeTypeName("HRESULT")]
        public int EnumGenericParamConstraints([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdGenericParam")] uint tk, [NativeTypeName("mdGenericParamConstraint[]")] uint* rGenericParamConstraints, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcGenericParamConstraints)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, uint*, uint, uint*, int>)(lpVtbl[68]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, tk, rGenericParamConstraints, cMax, pcGenericParamConstraints);
        }

        [VtblIndex(69)]
        [return: NativeTypeName("HRESULT")]
        public int GetGenericParamConstraintProps([NativeTypeName("mdGenericParamConstraint")] uint gpc, [NativeTypeName("mdGenericParam *")] uint* ptGenericParam, [NativeTypeName("mdToken *")] uint* ptkConstraintType)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint, uint*, uint*, int>)(lpVtbl[69]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), gpc, ptGenericParam, ptkConstraintType);
        }

        [VtblIndex(70)]
        [return: NativeTypeName("HRESULT")]
        public int GetPEKind([NativeTypeName("DWORD *")] uint* pdwPEKind, [NativeTypeName("DWORD *")] uint* pdwMAchine)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, uint*, uint*, int>)(lpVtbl[70]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), pdwPEKind, pdwMAchine);
        }

        [VtblIndex(71)]
        [return: NativeTypeName("HRESULT")]
        public int GetVersionString([NativeTypeName("LPWSTR")] ushort* pwzBuf, [NativeTypeName("DWORD")] uint ccBufSize, [NativeTypeName("DWORD *")] uint* pccBufSize)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, ushort*, uint, uint*, int>)(lpVtbl[71]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), pwzBuf, ccBufSize, pccBufSize);
        }

        [VtblIndex(72)]
        [return: NativeTypeName("HRESULT")]
        public int EnumMethodSpecs([NativeTypeName("HCORENUM *")] void** phEnum, [NativeTypeName("mdToken")] uint tk, [NativeTypeName("mdMethodSpec[]")] uint* rMethodSpecs, [NativeTypeName("ULONG")] uint cMax, [NativeTypeName("ULONG *")] uint* pcMethodSpecs)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataImport2*, void**, uint, uint*, uint, uint*, int>)(lpVtbl[72]))((IMetaDataImport2*)Unsafe.AsPointer(ref this), phEnum, tk, rMethodSpecs, cMax, pcMethodSpecs);
        }
    }
}
