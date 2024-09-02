// Decompiled with JetBrains decompiler
// Type: Windows.Win32.Foundation.HANDLE
// Assembly: Avalonia.BuildServices.414a6983686f44b4b34acf8b05411ccf, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 46AA80AB-7338-4A87-AD03-6DB25B4CC530
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.31\tools\netstandard2.0\Avalonia.BuildServices.dll

using System;
using System.Diagnostics;

namespace Windows.Win32.Foundation
{
  [DebuggerDisplay("{Value}")]
  internal readonly struct HANDLE : IEquatable<HANDLE>
  {
    internal readonly IntPtr Value;

    internal HANDLE(IntPtr value) => this.Value = value;

    internal bool IsNull => this.Value == IntPtr.Zero;

    public static implicit operator IntPtr(HANDLE value) => value.Value;

    public static explicit operator HANDLE(IntPtr value) => new HANDLE(value);

    public static bool operator ==(HANDLE left, HANDLE right) => left.Value == right.Value;

    public static bool operator !=(HANDLE left, HANDLE right) => !(left == right);

    public bool Equals(HANDLE other) => this.Value == other.Value;

    public override bool Equals(object obj) => obj is HANDLE other && this.Equals(other);

    public override int GetHashCode() => this.Value.GetHashCode();
  }
}
