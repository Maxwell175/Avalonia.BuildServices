// Decompiled with JetBrains decompiler
// Type: Windows.Win32.Foundation.PCWSTR
// Assembly: Avalonia.BuildServices.414a6983686f44b4b34acf8b05411ccf, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 46AA80AB-7338-4A87-AD03-6DB25B4CC530
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.31\tools\netstandard2.0\Avalonia.BuildServices.dll

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
