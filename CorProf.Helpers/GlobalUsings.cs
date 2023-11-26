// global using ClassID = ulong;
// global using ModuleID = ulong;
// global using FunctionID = ulong;
global using ULONG32 = uint;
global using mdToken = uint;
global using COR_PRF_FRAME_INFO = ulong;
global using WCHAR = ushort;
global using DWORD = uint;

#region winnt.h
global using HANDLE = nint;
#endregion

#region corprof.h
global using ProcessID = nuint;
global using AssemblyID = nuint;
global using AppDomainID = nuint;
global using ModuleID = ulong;
global using ClassID = ulong;
global using ThreadID = ulong;
global using ContextID = nuint;
global using FunctionID = ulong;
global using ObjectID = nuint;
global using GCHandleID = nuint;
global using COR_PRF_ELT_INFO = nuint;
global using ReJITID = nuint;
#endregion