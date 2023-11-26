using uint64_t = ulong;

namespace CorProf.Profiling.Abstractions;

public interface IThreadInfo
{
    uint OSThreadId { get; }

    string ThreadName { get; }

    IntPtr OSThreadHandle { get; }
}
