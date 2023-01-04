ClangSharpPInvokeGenerator `
    -c preview-codegen multi-file generate-vtbl-index-attribute `
    -I .\include `
    -f .\include\corhdr.h `
	    -r _GUID=Guid `
    -n CorProf.Bindings `
    -m CorHdrConsts `
	-o .\CorHdr.Bindings `
	-om CSharp