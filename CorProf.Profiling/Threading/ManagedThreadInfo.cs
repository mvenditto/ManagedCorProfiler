using CorProf.Profiling.Abstractions;

namespace CorProf.Profiling.Threading;

public sealed class ManagedThreadInfo : IThreadInfo
{
    private readonly ThreadID _clrThreadId;
    private string _threadName;
    private uint _osThreadId;
    private nint _osThreadHandle;

    private ManagedThreadInfo(ThreadID clrThreadId, uint osThreadId, HANDLE osThreadHandle, string threadName)
    {
        _clrThreadId = clrThreadId;
        _osThreadId = osThreadId;
        _osThreadHandle = osThreadHandle;
        _threadName = threadName;
    }

    public ManagedThreadInfo(ThreadID clrThreadId) : this(clrThreadId, 0, HANDLE.Zero, string.Empty)
    {
    }

    public ThreadID CLRThreadId => _clrThreadId;

    public nint OSThreadHandle => _osThreadHandle;

    public uint OSThreadId => _osThreadId;

    public string ThreadName => _threadName;

    public void SetOSThreadInfo(uint osThreadId, HANDLE osThreadHandle)
    {
        _osThreadId = osThreadId;
        _osThreadHandle = osThreadHandle;
    }

    public void SetThreadName(string threadName)
    {
        _threadName = threadName;
    }
}