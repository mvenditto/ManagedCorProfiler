; this files contains the AMD64 hooks definition
; the _X86_ definitions can be found in hooks.cpp.
; (on x86 we have __asm and __declspec(naked) available to use, on AMD64 we do not)
;
; build with ml.exe to ml64.exe
; e.g ml64 /nologo /c hooks_asm.asm (build only, link later)
; see build_hooks.cmd for more info 
;
; adapter from: 
; https://github.com/wickyhu/simple-assembly-explorer/blob/master/SimpleProfiler/LeaveNaked.asm
;

; stubs calling into profiler code
; defined and exported by hooks.cpp
extern EnterStub:proc
extern LeaveStub:proc
extern TailcallStub:proc

;typedef void FunctionEnter2(
;         rcx = FunctionID funcId, 
;         rdx = UINT_PTR clientData, 
;         r8  = COR_PRF_FRAME_INFO func, 
;         r9  = COR_PRF_FUNCTION_ARGUMENT_INFO *argumentInfo);
_TEXT segment para 'CODE'

        align   16

        public  EnterNaked2

; mark as EXPORT so we can use GetProcAddress from C#
; and pass the function pointer to the CLR with
; with ICorProfilerCallback2::SetEnterLeaveFunctionHooks
EnterNaked2  proc EXPORT frame

        ; save registers
        push    rax
        .allocstack 8

        push    r10
        .allocstack 8

        push    r11
        .allocstack 8

        sub     rsp, 20h
        .allocstack 20h

        .endprolog

        call    EnterStub

        add     rsp, 20h

        ; restore registers
        pop     r11
        pop     r10
        pop     rax

        ; return
        ret

EnterNaked2    endp

;typedef void LeaveNaked2(
;         rcx =  FunctionID funcId, 
;         rdx =  UINT_PTR clientData, 
;         r8  =  COR_PRF_FRAME_INFO func, 
;         r9  =  COR_PRF_FUNCTION_ARGUMENT_RANGE *retvalRange);
_TEXT segment para 'CODE'

        align   16

        public  LeaveNaked2

; mark as EXPORT so we can use GetProcAddress from C#
; and pass the function pointer to the CLR with
; with ICorProfilerCallback2::SetEnterLeaveFunctionHooks
LeaveNaked2    proc EXPORT   frame

        ; save integer return register
        push    rax
        .allocstack 8

        sub     rsp, 20h
        .allocstack 20h

        .endprolog

        call    LeaveStub

        add     rsp, 20h

        ; restore integer return register
        pop                     rax

        ; return
        ret

LeaveNaked2    endp

;typedef void TailcallNaked2(
;         rcx =  FunctionID funcId, 
;         rdx =  UINT_PTR clientData, 
;         t8  =  COR_PRF_FRAME_INFO,

        align   16

        public  TailcallNaked2

; mark as EXPORT so we can use GetProcAddress from C#
; and pass the function pointer to the CLR with
; with ICorProfilerCallback2::SetEnterLeaveFunctionHooks
TailcallNaked2   proc EXPORT   frame

        ; save rax
        push    rax
        .allocstack 8

        sub     rsp, 20h
        .allocstack 20h

        .endprolog

        call    TailcallStub

        add     rsp, 20h

        ; restore rax
        pop     rax

        ; return
        ret

TailcallNaked2   endp

_TEXT ends

end
