// Decompiled with JetBrains decompiler
// Type: Windows.Win32.Foundation.BOOL
// Assembly: Avalonia.BuildServices.4d13ac13194b4e8f8d5d765a80db914b, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D40A8C9-4F8F-4CDA-A558-A155F40715C0
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.29\tools\netstandard2.0\Avalonia.BuildServices.dll

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
