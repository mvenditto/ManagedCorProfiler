#include <windows.h>
#include <stdio.h>
#include <string.h>
#include <cor.h>
#include <corprof.h>
#include <CorError.h>

#pragma region Stubs2
typedef struct EnterLeaveCallbacks2 {
    FunctionEnter2* Enter;
    FunctionLeave2* Leave;
    FunctionTailcall2* Tailcall;
} EnterLeaveCallbacks2;

static EnterLeaveCallbacks2* Callbacks2;

void SetEnterLeaveCallbacks2(EnterLeaveCallbacks2* callbacks)
{
    Callbacks2 = callbacks;
}

EXTERN_C void __stdcall TailcallStub2(
    FunctionID functionId,
    UINT_PTR clientData,
    COR_PRF_FRAME_INFO frameInfo)
{
    Callbacks2->Tailcall(
        functionId,
        clientData,
        frameInfo);
}

EXTERN_C void __stdcall EnterStub2(
    FunctionID functionId,
    UINT_PTR clientData,
    COR_PRF_FRAME_INFO frameInfo,
    COR_PRF_FUNCTION_ARGUMENT_INFO* argumentInfo)
{
    Callbacks2->Enter(
        functionId,
        clientData,
        frameInfo,
        argumentInfo);
}

EXTERN_C void __stdcall LeaveStub2(
    FunctionID functionId,
    UINT_PTR clientData,
    COR_PRF_FRAME_INFO frameInfo,
    COR_PRF_FUNCTION_ARGUMENT_RANGE* retvalRange)
{
    Callbacks2->Leave(
        functionId,
        clientData,
        frameInfo,
        retvalRange);
}

#ifdef _X86_

__declspec(naked) void __stdcall EnterNaked2(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo)
{
    __asm
    {
        PUSH EAX
        PUSH ECX
        PUSH EDX
        PUSH[ESP + 16]
        CALL EnterStub2
        POP EDX
        POP ECX
        POP EAX
        RET 8
    }
}

__declspec(naked)  void __stdcall LeaveNaked2(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo)
{
    __asm
    {
        PUSH EAX
        PUSH ECX
        PUSH EDX
        PUSH[ESP + 16]
        CALL LeaveStub2
        POP EDX
        POP ECX
        POP EAX
        RET 8
    }
}

__declspec(naked)  void __stdcall TailcallNaked2(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo)
{
    __asm
    {
        PUSH EAX
        PUSH ECX
        PUSH EDX
        PUSH[ESP + 16]
        CALL TailcallStub2
        POP EDX
        POP ECX
        POP EAX
        RET 8
    }
}

#elif defined(_AMD64_)
// these are linked in to hooks_asm.obj on AMD64 (hooks_asm.asm)
// __declspec(naked) is not defined for X64
EXTERN_C void EnterNaked2(
    FunctionID functionId,
    UINT_PTR clientData,
    COR_PRF_FRAME_INFO frameInfo,
    COR_PRF_FUNCTION_ARGUMENT_INFO* argumentInfo);

EXTERN_C void LeaveNaked2(
    FunctionID functionId,
    UINT_PTR clientData,
    COR_PRF_FRAME_INFO frameInfo,
    COR_PRF_FUNCTION_ARGUMENT_RANGE* retvalRange);

EXTERN_C void TailcallNaked2(
    FunctionID functionId,
    UINT_PTR clientData,
    COR_PRF_FRAME_INFO frameInfo);
#endif // _X86_    
#pragma endregion

#pragma region Stubs_3WithInfo
typedef struct EnterLeaveCallbacks3WithInfo {
    FunctionEnter3WithInfo* Enter;
    FunctionLeave3WithInfo* Leave;
    FunctionTailcall3WithInfo* Tailcall;
} EnterLeaveCallbacks3WithInfo;

static EnterLeaveCallbacks3WithInfo* Callbacks3WithInfo;

void SetEnterLeaveCallbacks3WithInfo(EnterLeaveCallbacks3WithInfo* callbacks)
{
    Callbacks3WithInfo = callbacks;
}

EXTERN_C void __stdcall TailcallStub3WithInfo(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo)
{
    Callbacks3WithInfo->Tailcall(functionIDOrClientID, eltInfo);
}

EXTERN_C void __stdcall EnterStub3WithInfo(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo)
{
    Callbacks3WithInfo->Enter(functionIDOrClientID, eltInfo);
}

EXTERN_C void __stdcall LeaveStub3WithInfo(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo)
{
    Callbacks3WithInfo->Leave(functionIDOrClientID, eltInfo);
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
        CALL EnterStub3WithInfo
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
        CALL LeaveStub3WithInfo
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
        CALL TailcallStub3WithInfo
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

#pragma endregion