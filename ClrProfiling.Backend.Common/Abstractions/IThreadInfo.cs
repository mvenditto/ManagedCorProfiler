using uint64_t = ulong;

namespace ClrProfiling.Backend.Abstractions;

public interface IThreadInfo
{
    uint OSThreadId { get; }

    string ThreadName { get; }

    IntPtr OSThreadHandle { get; }
}
