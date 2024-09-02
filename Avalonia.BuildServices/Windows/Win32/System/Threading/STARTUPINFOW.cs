// Decompiled with JetBrains decompiler
// Type: Windows.Win32.System.Threading.STARTUPINFOW
// Assembly: Avalonia.BuildServices.4d13ac13194b4e8f8d5d765a80db914b, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D40A8C9-4F8F-4CDA-A558-A155F40715C0
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.29\tools\netstandard2.0\Avalonia.BuildServices.dll

using Windows.Win32.Foundation;

namespace Windows.Win32.System.Threading
{
  internal struct STARTUPINFOW
  {
    internal uint cb;
    internal PWSTR lpReserved;
    internal PWSTR lpDesktop;
    internal PWSTR lpTitle;
    internal uint dwX;
    internal uint dwY;
    internal uint dwXSize;
    internal uint dwYSize;
    internal uint dwXCountChars;
    internal uint dwYCountChars;
    internal uint dwFillAttribute;
    internal STARTUPINFOW_FLAGS dwFlags;
    internal ushort wShowWindow;
    internal ushort cbReserved2;
    internal unsafe byte* lpReserved2;
    internal HANDLE hStdInput;
    internal HANDLE hStdOutput;
    internal HANDLE hStdError;
  }
}
