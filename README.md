# Avalonia.BuildServices

This is a decompilation of the Avalonia.BuildServices (using dotPeek) that at time of writing is closed source.

# Why?

This decompilation is done to allow auditing of this telemetry package that runs on every project build.

# Changes made

A few minor decompilation artifacts are fixed after running dotPeek:
 * Worked around invalid cast in `implicit operator bool(BOOL value)` in `Windows.Win32.Foundation.BOOL`.
 * Missing using for `DebuggerDisplay` attribute on `Windows.Win32.Foundation.PCWSTR`.
 * Fixed missing `async` keyword on lambda in `Avalonia.Telemetry.Collector`.