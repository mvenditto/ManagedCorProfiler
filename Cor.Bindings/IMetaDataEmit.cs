using System;
using System.Runtime.CompilerServices;

namespace CorProf.Bindings
{
    [NativeTypeName("struct IMetaDataEmit : IUnknown")]
    public unsafe partial struct IMetaDataEmit
    {
        public void** lpVtbl;

        [VtblIndex(0)]
        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, Guid*, void**, int>)(lpVtbl[0]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint>)(lpVtbl[1]))((IMetaDataEmit*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint>)(lpVtbl[2]))((IMetaDataEmit*)Unsafe.AsPointer(ref this));
        }

        [VtblIndex(3)]
        [return: NativeTypeName("HRESULT")]
        public int SetModuleProps([NativeTypeName("LPCWSTR")] ushort* szName)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, ushort*, int>)(lpVtbl[3]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), szName);
        }

        [VtblIndex(4)]
        [return: NativeTypeName("HRESULT")]
        public int Save([NativeTypeName("LPCWSTR")] ushort* szFile, [NativeTypeName("DWORD")] uint dwSaveFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, ushort*, uint, int>)(lpVtbl[4]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), szFile, dwSaveFlags);
        }

        [VtblIndex(5)]
        [return: NativeTypeName("HRESULT")]
        public int SaveToStream([NativeTypeName("IStream *")] IntPtr* pIStream, [NativeTypeName("DWORD")] uint dwSaveFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, IntPtr*, uint, int>)(lpVtbl[5]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), pIStream, dwSaveFlags);
        }

        [VtblIndex(6)]
        [return: NativeTypeName("HRESULT")]
        public int GetSaveSize(CorSaveSize fSave, [NativeTypeName("DWORD *")] uint* pdwSaveSize)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, CorSaveSize, uint*, int>)(lpVtbl[6]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), fSave, pdwSaveSize);
        }

        [VtblIndex(7)]
        [return: NativeTypeName("HRESULT")]
        public int DefineTypeDef([NativeTypeName("LPCWSTR")] ushort* szTypeDef, [NativeTypeName("DWORD")] uint dwTypeDefFlags, [NativeTypeName("mdToken")] uint tkExtends, [NativeTypeName("mdToken[]")] uint* rtkImplements, [NativeTypeName("mdTypeDef *")] uint* ptd)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, ushort*, uint, uint, uint*, uint*, int>)(lpVtbl[7]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), szTypeDef, dwTypeDefFlags, tkExtends, rtkImplements, ptd);
        }

        [VtblIndex(8)]
        [return: NativeTypeName("HRESULT")]
        public int DefineNestedType([NativeTypeName("LPCWSTR")] ushort* szTypeDef, [NativeTypeName("DWORD")] uint dwTypeDefFlags, [NativeTypeName("mdToken")] uint tkExtends, [NativeTypeName("mdToken[]")] uint* rtkImplements, [NativeTypeName("mdTypeDef")] uint tdEncloser, [NativeTypeName("mdTypeDef *")] uint* ptd)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, ushort*, uint, uint, uint*, uint, uint*, int>)(lpVtbl[8]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), szTypeDef, dwTypeDefFlags, tkExtends, rtkImplements, tdEncloser, ptd);
        }

        [VtblIndex(9)]
        [return: NativeTypeName("HRESULT")]
        public int SetHandler(IUnknown* pUnk)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, IUnknown*, int>)(lpVtbl[9]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), pUnk);
        }

        [VtblIndex(10)]
        [return: NativeTypeName("HRESULT")]
        public int DefineMethod([NativeTypeName("mdTypeDef")] uint td, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("DWORD")] uint dwMethodFlags, [NativeTypeName("PCCOR_SIGNATURE")] byte* pvSigBlob, [NativeTypeName("ULONG")] uint cbSigBlob, [NativeTypeName("ULONG")] uint ulCodeRVA, [NativeTypeName("DWORD")] uint dwImplFlags, [NativeTypeName("mdMethodDef *")] uint* pmd)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, ushort*, uint, byte*, uint, uint, uint, uint*, int>)(lpVtbl[10]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), td, szName, dwMethodFlags, pvSigBlob, cbSigBlob, ulCodeRVA, dwImplFlags, pmd);
        }

        [VtblIndex(11)]
        [return: NativeTypeName("HRESULT")]
        public int DefineMethodImpl([NativeTypeName("mdTypeDef")] uint td, [NativeTypeName("mdToken")] uint tkBody, [NativeTypeName("mdToken")] uint tkDecl)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, uint, int>)(lpVtbl[11]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), td, tkBody, tkDecl);
        }

        [VtblIndex(12)]
        [return: NativeTypeName("HRESULT")]
        public int DefineTypeRefByName([NativeTypeName("mdToken")] uint tkResolutionScope, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("mdTypeRef *")] uint* ptr)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, ushort*, uint*, int>)(lpVtbl[12]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), tkResolutionScope, szName, ptr);
        }

        [VtblIndex(13)]
        [return: NativeTypeName("HRESULT")]
        public int DefineImportType(IMetaDataAssemblyImport* pAssemImport, [NativeTypeName("const void *")] void* pbHashValue, [NativeTypeName("ULONG")] uint cbHashValue, IMetaDataImport* pImport, [NativeTypeName("mdTypeDef")] uint tdImport, IMetaDataAssemblyEmit* pAssemEmit, [NativeTypeName("mdTypeRef *")] uint* ptr)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, IMetaDataAssemblyImport*, void*, uint, IMetaDataImport*, uint, IMetaDataAssemblyEmit*, uint*, int>)(lpVtbl[13]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), pAssemImport, pbHashValue, cbHashValue, pImport, tdImport, pAssemEmit, ptr);
        }

        [VtblIndex(14)]
        [return: NativeTypeName("HRESULT")]
        public int DefineMemberRef([NativeTypeName("mdToken")] uint tkImport, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("PCCOR_SIGNATURE")] byte* pvSigBlob, [NativeTypeName("ULONG")] uint cbSigBlob, [NativeTypeName("mdMemberRef *")] uint* pmr)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, ushort*, byte*, uint, uint*, int>)(lpVtbl[14]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), tkImport, szName, pvSigBlob, cbSigBlob, pmr);
        }

        [VtblIndex(15)]
        [return: NativeTypeName("HRESULT")]
        public int DefineImportMember(IMetaDataAssemblyImport* pAssemImport, [NativeTypeName("const void *")] void* pbHashValue, [NativeTypeName("ULONG")] uint cbHashValue, IMetaDataImport* pImport, [NativeTypeName("mdToken")] uint mbMember, IMetaDataAssemblyEmit* pAssemEmit, [NativeTypeName("mdToken")] uint tkParent, [NativeTypeName("mdMemberRef *")] uint* pmr)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, IMetaDataAssemblyImport*, void*, uint, IMetaDataImport*, uint, IMetaDataAssemblyEmit*, uint, uint*, int>)(lpVtbl[15]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), pAssemImport, pbHashValue, cbHashValue, pImport, mbMember, pAssemEmit, tkParent, pmr);
        }

        [VtblIndex(16)]
        [return: NativeTypeName("HRESULT")]
        public int DefineEvent([NativeTypeName("mdTypeDef")] uint td, [NativeTypeName("LPCWSTR")] ushort* szEvent, [NativeTypeName("DWORD")] uint dwEventFlags, [NativeTypeName("mdToken")] uint tkEventType, [NativeTypeName("mdMethodDef")] uint mdAddOn, [NativeTypeName("mdMethodDef")] uint mdRemoveOn, [NativeTypeName("mdMethodDef")] uint mdFire, [NativeTypeName("mdMethodDef[]")] uint* rmdOtherMethods, [NativeTypeName("mdEvent *")] uint* pmdEvent)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, ushort*, uint, uint, uint, uint, uint, uint*, uint*, int>)(lpVtbl[16]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), td, szEvent, dwEventFlags, tkEventType, mdAddOn, mdRemoveOn, mdFire, rmdOtherMethods, pmdEvent);
        }

        [VtblIndex(17)]
        [return: NativeTypeName("HRESULT")]
        public int SetClassLayout([NativeTypeName("mdTypeDef")] uint td, [NativeTypeName("DWORD")] uint dwPackSize, [NativeTypeName("COR_FIELD_OFFSET[]")] COR_FIELD_OFFSET* rFieldOffsets, [NativeTypeName("ULONG")] uint ulClassSize)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, COR_FIELD_OFFSET*, uint, int>)(lpVtbl[17]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), td, dwPackSize, rFieldOffsets, ulClassSize);
        }

        [VtblIndex(18)]
        [return: NativeTypeName("HRESULT")]
        public int DeleteClassLayout([NativeTypeName("mdTypeDef")] uint td)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, int>)(lpVtbl[18]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), td);
        }

        [VtblIndex(19)]
        [return: NativeTypeName("HRESULT")]
        public int SetFieldMarshal([NativeTypeName("mdToken")] uint tk, [NativeTypeName("PCCOR_SIGNATURE")] byte* pvNativeType, [NativeTypeName("ULONG")] uint cbNativeType)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, byte*, uint, int>)(lpVtbl[19]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), tk, pvNativeType, cbNativeType);
        }

        [VtblIndex(20)]
        [return: NativeTypeName("HRESULT")]
        public int DeleteFieldMarshal([NativeTypeName("mdToken")] uint tk)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, int>)(lpVtbl[20]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), tk);
        }

        [VtblIndex(21)]
        [return: NativeTypeName("HRESULT")]
        public int DefinePermissionSet([NativeTypeName("mdToken")] uint tk, [NativeTypeName("DWORD")] uint dwAction, [NativeTypeName("const void *")] void* pvPermission, [NativeTypeName("ULONG")] uint cbPermission, [NativeTypeName("mdPermission *")] uint* ppm)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, void*, uint, uint*, int>)(lpVtbl[21]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), tk, dwAction, pvPermission, cbPermission, ppm);
        }

        [VtblIndex(22)]
        [return: NativeTypeName("HRESULT")]
        public int SetRVA([NativeTypeName("mdMethodDef")] uint md, [NativeTypeName("ULONG")] uint ulRVA)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, int>)(lpVtbl[22]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), md, ulRVA);
        }

        [VtblIndex(23)]
        [return: NativeTypeName("HRESULT")]
        public int GetTokenFromSig([NativeTypeName("PCCOR_SIGNATURE")] byte* pvSig, [NativeTypeName("ULONG")] uint cbSig, [NativeTypeName("mdSignature *")] uint* pmsig)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, byte*, uint, uint*, int>)(lpVtbl[23]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), pvSig, cbSig, pmsig);
        }

        [VtblIndex(24)]
        [return: NativeTypeName("HRESULT")]
        public int DefineModuleRef([NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("mdModuleRef *")] uint* pmur)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, ushort*, uint*, int>)(lpVtbl[24]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), szName, pmur);
        }

        [VtblIndex(25)]
        [return: NativeTypeName("HRESULT")]
        public int SetParent([NativeTypeName("mdMemberRef")] uint mr, [NativeTypeName("mdToken")] uint tk)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, int>)(lpVtbl[25]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), mr, tk);
        }

        [VtblIndex(26)]
        [return: NativeTypeName("HRESULT")]
        public int GetTokenFromTypeSpec([NativeTypeName("PCCOR_SIGNATURE")] byte* pvSig, [NativeTypeName("ULONG")] uint cbSig, [NativeTypeName("mdTypeSpec *")] uint* ptypespec)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, byte*, uint, uint*, int>)(lpVtbl[26]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), pvSig, cbSig, ptypespec);
        }

        [VtblIndex(27)]
        [return: NativeTypeName("HRESULT")]
        public int SaveToMemory(void* pbData, [NativeTypeName("ULONG")] uint cbData)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, void*, uint, int>)(lpVtbl[27]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), pbData, cbData);
        }

        [VtblIndex(28)]
        [return: NativeTypeName("HRESULT")]
        public int DefineUserString([NativeTypeName("LPCWSTR")] ushort* szString, [NativeTypeName("ULONG")] uint cchString, [NativeTypeName("mdString *")] uint* pstk)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, ushort*, uint, uint*, int>)(lpVtbl[28]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), szString, cchString, pstk);
        }

        [VtblIndex(29)]
        [return: NativeTypeName("HRESULT")]
        public int DeleteToken([NativeTypeName("mdToken")] uint tkObj)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, int>)(lpVtbl[29]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), tkObj);
        }

        [VtblIndex(30)]
        [return: NativeTypeName("HRESULT")]
        public int SetMethodProps([NativeTypeName("mdMethodDef")] uint md, [NativeTypeName("DWORD")] uint dwMethodFlags, [NativeTypeName("ULONG")] uint ulCodeRVA, [NativeTypeName("DWORD")] uint dwImplFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, uint, uint, int>)(lpVtbl[30]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), md, dwMethodFlags, ulCodeRVA, dwImplFlags);
        }

        [VtblIndex(31)]
        [return: NativeTypeName("HRESULT")]
        public int SetTypeDefProps([NativeTypeName("mdTypeDef")] uint td, [NativeTypeName("DWORD")] uint dwTypeDefFlags, [NativeTypeName("mdToken")] uint tkExtends, [NativeTypeName("mdToken[]")] uint* rtkImplements)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, uint, uint*, int>)(lpVtbl[31]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), td, dwTypeDefFlags, tkExtends, rtkImplements);
        }

        [VtblIndex(32)]
        [return: NativeTypeName("HRESULT")]
        public int SetEventProps([NativeTypeName("mdEvent")] uint ev, [NativeTypeName("DWORD")] uint dwEventFlags, [NativeTypeName("mdToken")] uint tkEventType, [NativeTypeName("mdMethodDef")] uint mdAddOn, [NativeTypeName("mdMethodDef")] uint mdRemoveOn, [NativeTypeName("mdMethodDef")] uint mdFire, [NativeTypeName("mdMethodDef[]")] uint* rmdOtherMethods)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, uint, uint, uint, uint, uint*, int>)(lpVtbl[32]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), ev, dwEventFlags, tkEventType, mdAddOn, mdRemoveOn, mdFire, rmdOtherMethods);
        }

        [VtblIndex(33)]
        [return: NativeTypeName("HRESULT")]
        public int SetPermissionSetProps([NativeTypeName("mdToken")] uint tk, [NativeTypeName("DWORD")] uint dwAction, [NativeTypeName("const void *")] void* pvPermission, [NativeTypeName("ULONG")] uint cbPermission, [NativeTypeName("mdPermission *")] uint* ppm)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, void*, uint, uint*, int>)(lpVtbl[33]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), tk, dwAction, pvPermission, cbPermission, ppm);
        }

        [VtblIndex(34)]
        [return: NativeTypeName("HRESULT")]
        public int DefinePinvokeMap([NativeTypeName("mdToken")] uint tk, [NativeTypeName("DWORD")] uint dwMappingFlags, [NativeTypeName("LPCWSTR")] ushort* szImportName, [NativeTypeName("mdModuleRef")] uint mrImportDLL)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, ushort*, uint, int>)(lpVtbl[34]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), tk, dwMappingFlags, szImportName, mrImportDLL);
        }

        [VtblIndex(35)]
        [return: NativeTypeName("HRESULT")]
        public int SetPinvokeMap([NativeTypeName("mdToken")] uint tk, [NativeTypeName("DWORD")] uint dwMappingFlags, [NativeTypeName("LPCWSTR")] ushort* szImportName, [NativeTypeName("mdModuleRef")] uint mrImportDLL)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, ushort*, uint, int>)(lpVtbl[35]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), tk, dwMappingFlags, szImportName, mrImportDLL);
        }

        [VtblIndex(36)]
        [return: NativeTypeName("HRESULT")]
        public int DeletePinvokeMap([NativeTypeName("mdToken")] uint tk)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, int>)(lpVtbl[36]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), tk);
        }

        [VtblIndex(37)]
        [return: NativeTypeName("HRESULT")]
        public int DefineCustomAttribute([NativeTypeName("mdToken")] uint tkOwner, [NativeTypeName("mdToken")] uint tkCtor, [NativeTypeName("const void *")] void* pCustomAttribute, [NativeTypeName("ULONG")] uint cbCustomAttribute, [NativeTypeName("mdCustomAttribute *")] uint* pcv)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, void*, uint, uint*, int>)(lpVtbl[37]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), tkOwner, tkCtor, pCustomAttribute, cbCustomAttribute, pcv);
        }

        [VtblIndex(38)]
        [return: NativeTypeName("HRESULT")]
        public int SetCustomAttributeValue([NativeTypeName("mdCustomAttribute")] uint pcv, [NativeTypeName("const void *")] void* pCustomAttribute, [NativeTypeName("ULONG")] uint cbCustomAttribute)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, void*, uint, int>)(lpVtbl[38]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), pcv, pCustomAttribute, cbCustomAttribute);
        }

        [VtblIndex(39)]
        [return: NativeTypeName("HRESULT")]
        public int DefineField([NativeTypeName("mdTypeDef")] uint td, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("DWORD")] uint dwFieldFlags, [NativeTypeName("PCCOR_SIGNATURE")] byte* pvSigBlob, [NativeTypeName("ULONG")] uint cbSigBlob, [NativeTypeName("DWORD")] uint dwCPlusTypeFlag, [NativeTypeName("const void *")] void* pValue, [NativeTypeName("ULONG")] uint cchValue, [NativeTypeName("mdFieldDef *")] uint* pmd)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, ushort*, uint, byte*, uint, uint, void*, uint, uint*, int>)(lpVtbl[39]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), td, szName, dwFieldFlags, pvSigBlob, cbSigBlob, dwCPlusTypeFlag, pValue, cchValue, pmd);
        }

        [VtblIndex(40)]
        [return: NativeTypeName("HRESULT")]
        public int DefineProperty([NativeTypeName("mdTypeDef")] uint td, [NativeTypeName("LPCWSTR")] ushort* szProperty, [NativeTypeName("DWORD")] uint dwPropFlags, [NativeTypeName("PCCOR_SIGNATURE")] byte* pvSig, [NativeTypeName("ULONG")] uint cbSig, [NativeTypeName("DWORD")] uint dwCPlusTypeFlag, [NativeTypeName("const void *")] void* pValue, [NativeTypeName("ULONG")] uint cchValue, [NativeTypeName("mdMethodDef")] uint mdSetter, [NativeTypeName("mdMethodDef")] uint mdGetter, [NativeTypeName("mdMethodDef[]")] uint* rmdOtherMethods, [NativeTypeName("mdProperty *")] uint* pmdProp)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, ushort*, uint, byte*, uint, uint, void*, uint, uint, uint, uint*, uint*, int>)(lpVtbl[40]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), td, szProperty, dwPropFlags, pvSig, cbSig, dwCPlusTypeFlag, pValue, cchValue, mdSetter, mdGetter, rmdOtherMethods, pmdProp);
        }

        [VtblIndex(41)]
        [return: NativeTypeName("HRESULT")]
        public int DefineParam([NativeTypeName("mdMethodDef")] uint md, [NativeTypeName("ULONG")] uint ulParamSeq, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("DWORD")] uint dwParamFlags, [NativeTypeName("DWORD")] uint dwCPlusTypeFlag, [NativeTypeName("const void *")] void* pValue, [NativeTypeName("ULONG")] uint cchValue, [NativeTypeName("mdParamDef *")] uint* ppd)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, ushort*, uint, uint, void*, uint, uint*, int>)(lpVtbl[41]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), md, ulParamSeq, szName, dwParamFlags, dwCPlusTypeFlag, pValue, cchValue, ppd);
        }

        [VtblIndex(42)]
        [return: NativeTypeName("HRESULT")]
        public int SetFieldProps([NativeTypeName("mdFieldDef")] uint fd, [NativeTypeName("DWORD")] uint dwFieldFlags, [NativeTypeName("DWORD")] uint dwCPlusTypeFlag, [NativeTypeName("const void *")] void* pValue, [NativeTypeName("ULONG")] uint cchValue)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, uint, void*, uint, int>)(lpVtbl[42]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), fd, dwFieldFlags, dwCPlusTypeFlag, pValue, cchValue);
        }

        [VtblIndex(43)]
        [return: NativeTypeName("HRESULT")]
        public int SetPropertyProps([NativeTypeName("mdProperty")] uint pr, [NativeTypeName("DWORD")] uint dwPropFlags, [NativeTypeName("DWORD")] uint dwCPlusTypeFlag, [NativeTypeName("const void *")] void* pValue, [NativeTypeName("ULONG")] uint cchValue, [NativeTypeName("mdMethodDef")] uint mdSetter, [NativeTypeName("mdMethodDef")] uint mdGetter, [NativeTypeName("mdMethodDef[]")] uint* rmdOtherMethods)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, uint, void*, uint, uint, uint, uint*, int>)(lpVtbl[43]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), pr, dwPropFlags, dwCPlusTypeFlag, pValue, cchValue, mdSetter, mdGetter, rmdOtherMethods);
        }

        [VtblIndex(44)]
        [return: NativeTypeName("HRESULT")]
        public int SetParamProps([NativeTypeName("mdParamDef")] uint pd, [NativeTypeName("LPCWSTR")] ushort* szName, [NativeTypeName("DWORD")] uint dwParamFlags, [NativeTypeName("DWORD")] uint dwCPlusTypeFlag, [NativeTypeName("const void *")] void* pValue, [NativeTypeName("ULONG")] uint cchValue)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, ushort*, uint, uint, void*, uint, int>)(lpVtbl[44]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), pd, szName, dwParamFlags, dwCPlusTypeFlag, pValue, cchValue);
        }

        [VtblIndex(45)]
        [return: NativeTypeName("HRESULT")]
        public int DefineSecurityAttributeSet([NativeTypeName("mdToken")] uint tkObj, [NativeTypeName("COR_SECATTR[]")] COR_SECATTR* rSecAttrs, [NativeTypeName("ULONG")] uint cSecAttrs, [NativeTypeName("ULONG *")] uint* pulErrorAttr)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, COR_SECATTR*, uint, uint*, int>)(lpVtbl[45]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), tkObj, rSecAttrs, cSecAttrs, pulErrorAttr);
        }

        [VtblIndex(46)]
        [return: NativeTypeName("HRESULT")]
        public int ApplyEditAndContinue(IUnknown* pImport)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, IUnknown*, int>)(lpVtbl[46]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), pImport);
        }

        [VtblIndex(47)]
        [return: NativeTypeName("HRESULT")]
        public int TranslateSigWithScope(IMetaDataAssemblyImport* pAssemImport, [NativeTypeName("const void *")] void* pbHashValue, [NativeTypeName("ULONG")] uint cbHashValue, IMetaDataImport* import, [NativeTypeName("PCCOR_SIGNATURE")] byte* pbSigBlob, [NativeTypeName("ULONG")] uint cbSigBlob, IMetaDataAssemblyEmit* pAssemEmit, IMetaDataEmit* emit, [NativeTypeName("PCOR_SIGNATURE")] byte* pvTranslatedSig, [NativeTypeName("ULONG")] uint cbTranslatedSigMax, [NativeTypeName("ULONG *")] uint* pcbTranslatedSig)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, IMetaDataAssemblyImport*, void*, uint, IMetaDataImport*, byte*, uint, IMetaDataAssemblyEmit*, IMetaDataEmit*, byte*, uint, uint*, int>)(lpVtbl[47]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), pAssemImport, pbHashValue, cbHashValue, import, pbSigBlob, cbSigBlob, pAssemEmit, emit, pvTranslatedSig, cbTranslatedSigMax, pcbTranslatedSig);
        }

        [VtblIndex(48)]
        [return: NativeTypeName("HRESULT")]
        public int SetMethodImplFlags([NativeTypeName("mdMethodDef")] uint md, [NativeTypeName("DWORD")] uint dwImplFlags)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, int>)(lpVtbl[48]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), md, dwImplFlags);
        }

        [VtblIndex(49)]
        [return: NativeTypeName("HRESULT")]
        public int SetFieldRVA([NativeTypeName("mdFieldDef")] uint fd, [NativeTypeName("ULONG")] uint ulRVA)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, uint, uint, int>)(lpVtbl[49]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), fd, ulRVA);
        }

        [VtblIndex(50)]
        [return: NativeTypeName("HRESULT")]
        public int Merge(IMetaDataImport* pImport, IMapToken* pHostMapToken, IUnknown* pHandler)
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, IMetaDataImport*, IMapToken*, IUnknown*, int>)(lpVtbl[50]))((IMetaDataEmit*)Unsafe.AsPointer(ref this), pImport, pHostMapToken, pHandler);
        }

        [VtblIndex(51)]
        [return: NativeTypeName("HRESULT")]
        public int MergeEnd()
        {
            return ((delegate* unmanaged[Stdcall]<IMetaDataEmit*, int>)(lpVtbl[51]))((IMetaDataEmit*)Unsafe.AsPointer(ref this));
        }
    }
}
