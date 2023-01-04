#include <windows.h>
#include <stdio.h>
#include <string.h>
#include <cor.h>
#include <corprof.h>

typedef struct EnterLeavelCallbacks2 {
    FunctionEnter2* Enter;
    FunctionLeave2* Leave;
    FunctionTailcall2* Tailcall;
    void* userData;
} EnterLeaveCallbacks2;

EXTERN_C void __stdcall TailcallStub(
    FunctionID functionId,
    UINT_PTR clientData,
    COR_PRF_FRAME_INFO frameInfo)
{
    ((EnterLeavelCallbacks2*)clientData)->Tailcall(
        functionId,
        clientData,
        frameInfo);
}

EXTERN_C void __stdcall EnterStub(
    FunctionID functionId,
    UINT_PTR clientData,
    COR_PRF_FRAME_INFO frameInfo,
    COR_PRF_FUNCTION_ARGUMENT_INFO* argumentInfo)
{
    ((EnterLeavelCallbacks2*)clientData)->Enter(
        functionId, 
        clientData, 
        frameInfo, 
        argumentInfo);
}

EXTERN_C void __stdcall LeaveStub(
    FunctionID functionId,
    UINT_PTR clientData,
    COR_PRF_FRAME_INFO frameInfo,
    COR_PRF_FUNCTION_ARGUMENT_RANGE* retvalRange)
{
    ((EnterLeavelCallbacks2*)clientData)->Leave(
        functionId,
        clientData,
        frameInfo,
        retvalRange);
}

#ifdef _X86_

/*
The implementation must use the __declspec(naked) storage-class attribute.
see: https://learn.microsoft.com/en-us/dotnet/framework/unmanaged-api/profiling/functionenter2-function
*/
__declspec(naked) void __stdcall EnterNaked2(
    FunctionID functionId,
    UINT_PTR clientData,
    COR_PRF_FRAME_INFO frameInfo,
    COR_PRF_FUNCTION_ARGUMENT_INFO* argumentInfo)
{
    // ENTER:
    //  Save all registers that we use     
    __asm
    {
        // ESP = current stack pointer
        // EBP = base pointer of current stack frame
        // Establish a new stack frame within the callee
        // while preserving the stack frame of the caller
        PUSH EBP
        MOV EBP, ESP

        // PUSH "bumps" the value of ESP (stack pointer)
        PUSH EAX
        PUSH ECX
        PUSH EDX
    }

    EnterStub(functionId, clientData, frameInfo, argumentInfo);

    // EXIT: 
    //  Restore the stack by popping
    //  the parameters that were pushed 
    //  by the caller
    __asm
    {
        POP  EDX
        POP  ECX
        POP  EAX

        MOV ESP, EBP
        POP EBP

        // RET N where N is the size of parameters on the stack. 
        // In this case it is 4 * 4 = 16 (10H) for 4 DWORDs
        RET 10H
    }

}

__declspec(naked)  void __stdcall LeaveNaked2(
    FunctionID functionId,
    UINT_PTR clientData,
    COR_PRF_FRAME_INFO frameInfo,
    COR_PRF_FUNCTION_ARGUMENT_RANGE* retvalRange)
{
    __asm
    {
        PUSH EBP        
        MOV EBP, ESP

        PUSH EAX
        PUSH ECX
        PUSH EDX
    }

    LeaveStub(functionId, clientData, frameInfo, retvalRange);
    
    __asm
    {
        POP  EDX
        POP  ECX
        POP  EAX

        MOV ESP, EBP
        POP EBP

        RET 10H
    }
} 

__declspec(naked)  void __stdcall TailcallNaked2(
    FunctionID functionId,
    UINT_PTR clientData,
    COR_PRF_FRAME_INFO frameInfo)
{
    __asm
    {
        push eax
        push ecx
        push edx
        push[esp + 16]
        call TailcallStub
        pop edx
        pop ecx
        pop eax
        ret 12
    }
}

#elif defined(_AMD64_)
// these are linked in to hooks_asm.obj on AMD64 (hooks_asm.asm)
// __declspec(naked) is not defined for X64
EXTERN_C void EnterNaked2(FunctionID funcId,
    UINT_PTR clientData,
    COR_PRF_FRAME_INFO frameInfo,
    COR_PRF_FUNCTION_ARGUMENT_INFO* argumentInfo);
EXTERN_C void LeaveNaked2(FunctionID funcId,
    UINT_PTR clientData,
    COR_PRF_FRAME_INFO frameInfo,
    COR_PRF_FUNCTION_ARGUMENT_RANGE* retvalRange);
EXTERN_C void TailcallNaked2(FunctionID funcId,
    UINT_PTR clientData,
    COR_PRF_FRAME_INFO frameInfo);
#endif // _X86_    