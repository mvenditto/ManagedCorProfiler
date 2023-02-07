#include <windows.h>
#include <stdio.h>
#include <string.h>
#include <cor.h>
#include <corprof.h>

typedef struct EnterLeaveCallbacks3WithInfo {
    FunctionEnter3WithInfo* Enter;
    FunctionLeave3WithInfo* Leave;
    FunctionTailcall3WithInfo* Tailcall;
} EnterLeaveCallbacks3WithInfo;

static EnterLeaveCallbacks3WithInfo* UserCallbacks;

void SetUserCallbacks(EnterLeaveCallbacks3WithInfo* callbacks)
{
    UserCallbacks = callbacks;
}

EXTERN_C void __stdcall TailcallStub(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo)
{
    //printf("> tail %lld\n", functionIDOrClientID.functionID);
    UserCallbacks->Tailcall(functionIDOrClientID, eltInfo);
    //printf("< tail %lld\n", functionIDOrClientID.functionID);
}

EXTERN_C void __stdcall EnterStub(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo)
{
    //printf("> enter %lld\n", functionIDOrClientID.functionID);
    UserCallbacks->Enter(functionIDOrClientID, eltInfo);
    //printf("< enter %lld\n", functionIDOrClientID.functionID);
}

EXTERN_C void __stdcall LeaveStub(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo)
{
    //printf("> leave %lld\n", functionIDOrClientID.functionID);
    UserCallbacks->Leave(functionIDOrClientID, eltInfo);
    //printf("< leave %lld\n", functionIDOrClientID.functionID);
}

#ifdef _X86_

__declspec(naked) void __stdcall EnterNaked3WithInfo(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo)
{
    __asm
    {
        PUSH EAX
        PUSH ECX
        PUSH EDX
        PUSH[ESP + 16]
        CALL EnterStub
        POP EDX
        POP ECX
        POP EAX
        RET 8
    }
}

__declspec(naked)  void __stdcall LeaveNaked3WithInfo(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo)
{
    __asm
    {
        PUSH EAX
        PUSH ECX
        PUSH EDX
        PUSH[ESP + 16]
        CALL LeaveStub
        POP EDX
        POP ECX
        POP EAX
        RET 8
    }
} 

__declspec(naked)  void __stdcall TailcallNaked3WithInfo(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo)
{
    __asm
    {
        PUSH EAX
        PUSH ECX
        PUSH EDX
        PUSH[ESP + 16]
        CALL TailcallStub
        POP EDX
        POP ECX
        POP EAX
        RET 8
    }
}

#elif defined(_AMD64_)
// these are linked in to hooks_asm.obj on AMD64 (hooks_asm.asm)
// __declspec(naked) is not defined for X64
EXTERN_C void EnterNaked3WithInfo(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo);

EXTERN_C void LeaveNaked3WithInfo(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo);

EXTERN_C void TailcallNaked3WithInfo(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo);
#endif // _X86_    