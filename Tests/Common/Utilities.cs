using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;

namespace TestLibrary;

public static class Utilities
{
    class TestAssemblyLoadContext : AssemblyLoadContext
    {
        public TestAssemblyLoadContext() : base(isCollectible: true)
        {

        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            return null;
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int ExecuteAndUnloadInternal(string assemblyPath, string[] args, Action<AssemblyLoadContext> unloadingCallback, out WeakReference alcWeakRef)
    {
        TestAssemblyLoadContext alc = new TestAssemblyLoadContext();
        if (unloadingCallback != null)
        {
            alc.Unloading += unloadingCallback;
        }
        alcWeakRef = new WeakReference(alc);

        Assembly a = alc.LoadFromAssemblyPath(assemblyPath);

        object[] argsObjArray = (a.EntryPoint.GetParameters().Length != 0) ? new object[] { args } : null;
        object res = a.EntryPoint.Invoke(null, argsObjArray);

        alc.Unload();

        return (a.EntryPoint.ReturnType == typeof(void)) ? Environment.ExitCode : Convert.ToInt32(res);
    }

    public static int ExecuteAndUnload(string assemblyPath, string[] args, Action<AssemblyLoadContext> unloadingCallback = null)
    {
        WeakReference alcWeakRef;
        int exitCode;

        exitCode = ExecuteAndUnloadInternal(assemblyPath, args, unloadingCallback, out alcWeakRef);

        for (int i = 0; i < 8 && alcWeakRef.IsAlive; i++)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        if (alcWeakRef.IsAlive)
        {
            exitCode += 100;
            Console.WriteLine($"Unload failed - {assemblyPath}");
        }
        else
        {
            Console.WriteLine($"Unload succeeded - {assemblyPath}");
        }

        return exitCode;
    }
}
