#include <windows.h>
#include <stdio.h>
#include <string.h>
#include <cor.h>
#include <corprof.h>

#ifdef ELT3
#ifdef _X86_
EXTERN_C void EnterStub3WithInfo(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo);

EXTERN_C void LeaveStub3WithInfo(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo);

EXTERN_C void TailcallStub3WithInfo(
    FunctionIDOrClientID functionIDOrClientID,
    COR_PRF_ELT_INFO eltInfo);

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

__declspec(naked) void __stdcall LeaveNaked3WithInfo(
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
// these are linked in to hooks_asm.obj on AMD64 (hooks.asm)
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
#endif // _AMD64_
#endif // ELT3