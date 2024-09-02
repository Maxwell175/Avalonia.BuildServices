// Decompiled with JetBrains decompiler
// Type: Windows.Win32.Foundation.BOOL
// Assembly: Avalonia.BuildServices.414a6983686f44b4b34acf8b05411ccf, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 46AA80AB-7338-4A87-AD03-6DB25B4CC530
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.31\tools\netstandard2.0\Avalonia.BuildServices.dll

namespace Windows.Win32.Foundation
{
  internal readonly struct BOOL
  {
    private readonly int value;

    internal int Value => this.value;

    internal BOOL(bool value) => this.value = value ? 1 : 0;

    internal BOOL(int value) => this.value = value;

    public static implicit operator bool(BOOL value) => checked ((sbyte) value.value) == 1;

    public static implicit operator BOOL(bool value) => new BOOL(value);

    public static explicit operator BOOL(int value) => new BOOL(value);
  }
}
