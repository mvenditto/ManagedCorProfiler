namespace ClrProfiling.Backend.Abstractions;

public interface IThreadManager
{
    ulong GetThreadCpuTime(IThreadInfo threadInfo);
}
