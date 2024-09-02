// Decompiled with JetBrains decompiler
// Type: Windows.Win32.Foundation.PCWSTR
// Assembly: Avalonia.BuildServices.4d13ac13194b4e8f8d5d765a80db914b, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D40A8C9-4F8F-4CDA-A558-A155F40715C0
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.29\tools\netstandard2.0\Avalonia.BuildServices.dll

using System;
using System.Diagnostics;

namespace Windows.Win32.Foundation
{
  [DebuggerDisplay("{DebuggerDisplay}")]
  internal readonly struct PCWSTR : IEquatable<PCWSTR>
  {
    internal readonly unsafe char* Value;

    internal unsafe PCWSTR(char* value) => this.Value = value;

    public static unsafe explicit operator char*(PCWSTR value) => value.Value;

    public static unsafe implicit operator PCWSTR(char* value) => new PCWSTR(value);

    public static unsafe implicit operator PCWSTR(PWSTR value) => new PCWSTR(value.Value);

    public unsafe bool Equals(PCWSTR other) => this.Value == other.Value;

    public override bool Equals(object obj) => obj is PCWSTR other && this.Equals(other);

    public override unsafe int GetHashCode() => (int) this.Value;

    internal unsafe int Length
    {
      get
      {
        char* chPtr = this.Value;
        if ((IntPtr) chPtr == IntPtr.Zero)
          return 0;
        while (*chPtr != char.MinValue)
          ++chPtr;
        return checked ((int) (chPtr - this.Value));
      }
    }

    public override unsafe string ToString() => (IntPtr) this.Value != IntPtr.Zero ? new string(this.Value) : (string) null;

    private string DebuggerDisplay => this.ToString();

    internal unsafe ReadOnlySpan<char> AsSpan() => (IntPtr) this.Value != IntPtr.Zero ? new ReadOnlySpan<char>((void*) this.Value, this.Length) : new ReadOnlySpan<char>();
  }
}
