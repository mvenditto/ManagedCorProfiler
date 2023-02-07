ml64 /nologo /c hooks_asm.asm
cl /nologo /c /Od /TP hooks.cpp
LINK.EXE /nologo /DEF:hooks.def /OUT:hooks.dll /DLL hooks.obj hooks_asm.obj
copy hooks.dll ..\bin\profiler\hooks.dll /Y
REM DUMPBIN /EXPORTS hooks.dll