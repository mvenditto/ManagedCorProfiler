using CorProf.Bindings;
using CorProf.Profiling.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace CorProf.Profiling.Windows.Stack;

public unsafe class Windows64StackWalker : IStackCrawler, IDisposable
{
    private readonly ILogger<Windows64StackWalker> _logger;
    private readonly ICorProfilerInfo4* _profilerInfo;
    public Windows64StackWalker(ILogger<Windows64StackWalker> logger, ICorProfilerInfo4* profilerInfo)
    {
        _logger = logger ?? NullLogger<Windows64StackWalker>.Instance;
        
        if (profilerInfo != null)
        {
            _profilerInfo = profilerInfo;
            _profilerInfo->AddRef();
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        if (_profilerInfo != null)
        {
            _profilerInfo->Release();
        }
    }
}
