namespace ClrProfiling.Runner;

[Flags]
public enum ProfileeOptions
{
    None = 0,
    OptimizationSensitive,
    NoStartupAttach,
    ReverseDiagnosticsMode
}
