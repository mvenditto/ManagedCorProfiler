﻿using System.Runtime.InteropServices;
using Tests.Common;

/// <summary>
/// TODO: investigate:
///     System.Private.CoreLib.dll!EtwEnableCallback::Invoke
///     System.Private.CoreLib.dll!EtwEnableCallback::Invoke
/// that would mess the test
/// </summary>
unsafe class Transitions
{
    static readonly string PInvokeExpectedNameEnvVar = "PInvoke_Transition_Expected_Name";
    static readonly string ReversePInvokeExpectedNameEnvVar = "ReversePInvoke_Transition_Expected_Name";
    static readonly Guid TransitionsGuid = new("090B7720-6605-462B-86A0-C4D4C444D3F5");

    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    delegate int InteropDelegate(int i);

    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    delegate int InteropDelegateNonBlittable(bool b);

    private static int DoDelegateReversePInvoke(int i)
    {
        return i;
    }

    private static int DoDelegateReversePInvokeNonBlittable(bool b)
    {
        return b ? 1 : 0;
    }

    public static int BlittablePInvokeToBlittableInteropDelegate()
    {
        Console.WriteLine(nameof(BlittablePInvokeToBlittableInteropDelegate));
        InteropDelegate del = DoDelegateReversePInvoke;

        DoPInvoke((delegate* unmanaged<int, int>)Marshal.GetFunctionPointerForDelegate(del), 13);

        GC.KeepAlive(del); 

        return 100;
    }

    public static int NonBlittablePInvokeToNonBlittableInteropDelegate()
    {
        InteropDelegateNonBlittable del = DoDelegateReversePInvokeNonBlittable;

        DoPInvokeNonBlitable((delegate* unmanaged<int, int>)Marshal.GetFunctionPointerForDelegate(del), true);
        GC.KeepAlive(del);
        
        return 100;
    }

    [UnmanagedCallersOnly]
    private static int DoReversePInvoke(int i)
    {
        return i;
    }

    [DllImport("Profiler")]
    public static extern void DoPInvoke(delegate* unmanaged<int, int> callback, int i);

    [DllImport("Profiler", EntryPoint = nameof(DoPInvoke))]
    public static extern void DoPInvokeNonBlitable(delegate* unmanaged<int, int> callback, bool i);

    public static int BlittablePInvokeToUnmanagedCallersOnly()
    {
        DoPInvoke(&DoReversePInvoke, 13);

        return 100;
    }

    public static int NonBlittablePInvokeToUnmanagedCallersOnly()
    {
       DoPInvokeNonBlitable(&DoReversePInvoke, true);

        return 100;
    }

    public static int Main(string[] args)
    {
        if (args.Length > 1 && args[0].Equals("RunTest", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("RunTest: " + args[1]);

            switch (args[1])
            {
                case nameof(BlittablePInvokeToUnmanagedCallersOnly):
                    return BlittablePInvokeToUnmanagedCallersOnly();
                case nameof(BlittablePInvokeToBlittableInteropDelegate):
                    return BlittablePInvokeToBlittableInteropDelegate();
                case nameof(NonBlittablePInvokeToUnmanagedCallersOnly):
                    return NonBlittablePInvokeToUnmanagedCallersOnly();
                case nameof(NonBlittablePInvokeToNonBlittableInteropDelegate):
                    return NonBlittablePInvokeToNonBlittableInteropDelegate();
            }
        }

        if (!RunProfilerTest(nameof(BlittablePInvokeToUnmanagedCallersOnly), "Transitions::" + nameof(DoPInvoke), "Transitions::"+nameof(DoReversePInvoke)))
        {
            return 101;
        }

        if (!RunProfilerTest(nameof(BlittablePInvokeToBlittableInteropDelegate), "Transitions::" + nameof(DoPInvoke), "InteropDelegate::Invoke"))
        {
            return 102;
        }
        
        if (!RunProfilerTest(nameof(NonBlittablePInvokeToUnmanagedCallersOnly), "Transitions::" + nameof(DoPInvokeNonBlitable), "Transitions::" + nameof(DoReversePInvoke)))
        {
            return 101;
        }
        

        if (!RunProfilerTest(nameof(NonBlittablePInvokeToNonBlittableInteropDelegate), "Transitions::" + nameof(DoPInvokeNonBlitable), "InteropDelegateNonBlittable::Invoke"))
        {
            return 102;
        }

        return 100;
    }

    private static bool RunProfilerTest(string testName, string pInvokeExpectedName, string reversePInvokeExpectedName)
    {
        try
        {
            return ProfilerTestRunner.Run(profileePath: System.Reflection.Assembly.GetExecutingAssembly().Location,
                                      testName: "Transitions",
                                      profilerClsid: TransitionsGuid,
                                      profileeArguments: testName,
                                      envVars: new Dictionary<string, string>
                                      {
                                            { PInvokeExpectedNameEnvVar, "TransitionsApp.dll!" + pInvokeExpectedName },
                                            { ReversePInvokeExpectedNameEnvVar,  "TransitionsApp.dll!" + reversePInvokeExpectedName },
                                      }) == 100;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        return false;
    }
}