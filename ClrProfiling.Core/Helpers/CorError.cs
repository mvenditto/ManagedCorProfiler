using Windows.Win32.Foundation;

namespace ClrProfiling.Core.Helpers;

/// <summary>
/// See CorErr.h
/// </summary>
internal static class CorError
{
    # region CORPROF_E
    /// <summary>
    /// Function not yet compiled..
    /// </summary>
    public const int CORPROF_E_FUNCTION_NOT_COMPILED = unchecked((int)0x80131350);

    /// <summary>
    /// The ID is not fully loaded/defined yet..
    /// </summary>
    public const int CORPROF_E_DATAINCOMPLETE = unchecked((int)0x80131351);

    /// <summary>
    /// The Module is not configured for updateable methods..
    /// </summary>
    public const int CORPROF_E_NOT_REJITABLE_METHODS = unchecked((int)0x80131352);

    /// <summary>
    /// The Method could not be updated for re-jit..
    /// </summary>
    public const int CORPROF_E_CANNOT_UPDATE_METHOD = unchecked((int)0x80131353);

    /// <summary>
    /// The Method has no associated IL.
    /// </summary>
    public const int CORPROF_E_FUNCTION_NOT_IL = unchecked((int)0x80131354);

    /// <summary>
    /// The thread has never run managed code before.
    /// </summary>
    public const int CORPROF_E_NOT_MANAGED_THREAD = unchecked((int)0x80131355);

    /// <summary>
    /// The function may only be called during profiler init.
    /// </summary>
    public const int CORPROF_E_CALL_ONLY_FROM_INIT = unchecked((int)0x80131356);

    /// <summary>
    /// Inprocess debugging must be enabled during init.
    /// </summary>
    public const int CORPROF_E_INPROC_NOT_ENABLED = unchecked((int)0x80131357);

    /// <summary>
    /// Can't get a JIT map becuase they are not enabled.
    /// </summary>
    public const int CORPROF_E_JITMAPS_NOT_ENABLED = unchecked((int)0x80131358);

    /// <summary>
    /// If a profiler tries to call BeginInprocDebugging more than.
    /// </summary>
    public const int CORPROF_E_INPROC_ALREADY_BEGUN = unchecked((int)0x80131359);

    /// <summary>
    /// States that inprocess debugging not allowed at this point.
    /// </summary>
    public const int CORPROF_E_INPROC_NOT_AVAILABLE = unchecked((int)0x8013135a);

    /// <summary>
    /// This is a general error used to indicated that the information.
    /// </summary>
    public const int CORPROF_E_NOT_YET_AVAILABLE = unchecked((int)0x8013135b);

    /// <summary>
    /// The given type is a generic and cannot be used with this method..
    /// </summary>
    public const int CORPROF_E_TYPE_IS_PARAMETERIZED = unchecked((int)0x8013135c);

    /// <summary>
    /// The given function is a generic and cannot be used with this method..
    /// </summary>
    public const int CORPROF_E_FUNCTION_IS_PARAMETERIZED = unchecked((int)0x8013135d);

    /// <summary>
    /// A profiler tried to walk the stack of an invalid thread.
    /// </summary>
    public const int CORPROF_E_STACKSNAPSHOT_INVALID_TGT_THREAD = unchecked((int)0x8013135e);

    /// <summary>
    /// A profiler can not walk a thread that is currently executing unmanaged code.
    /// </summary>
    public const int CORPROF_E_STACKSNAPSHOT_UNMANAGED_CTX = unchecked((int)0x8013135f);

    /// <summary>
    /// A stackwalk at this point may cause dead locks or data corruption.
    /// </summary>
    public const int CORPROF_E_STACKSNAPSHOT_UNSAFE = unchecked((int)0x80131360);

    /// <summary>
    /// Stackwalking callback requested the walk to abort.
    /// </summary>
    public const int CORPROF_E_STACKSNAPSHOT_ABORTED = unchecked((int)0x80131361);

    /// <summary>
    /// Returned when asked for the address of a static that is a literal..
    /// </summary>
    public const int CORPROF_E_LITERALS_HAVE_NO_ADDRESS = unchecked((int)0x80131362);

    /// <summary>
    /// A call was made at an unsupported time (e.g., API illegally called asynchronously).
    /// </summary>
    public const int CORPROF_E_UNSUPPORTED_CALL_SEQUENCE = unchecked((int)0x80131363);

    /// <summary>
    /// A legal asynchronous call was made at an unsafe time (e.g., CLR locks are held).
    /// </summary>
    public const int CORPROF_E_ASYNCHRONOUS_UNSAFE = unchecked((int)0x80131364);

    /// <summary>
    /// The specified ClassID cannot be inspected by this function because it is an array.
    /// </summary>
    public const int CORPROF_E_CLASSID_IS_ARRAY = unchecked((int)0x80131365);

    /// <summary>
    /// The specified ClassID is a non-array composite type (e.g., ref) and cannot be inspected.
    /// </summary>
    public const int CORPROF_E_CLASSID_IS_COMPOSITE = unchecked((int)0x80131366);

    #endregion
}
