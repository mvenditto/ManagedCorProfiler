namespace CorProf.Profiling.Abstractions;

public interface IThreadManager
{
    ulong GetThreadCpuTime(IThreadInfo threadInfo);
}
