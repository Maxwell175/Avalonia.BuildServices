// Decompiled with JetBrains decompiler
// Type: Windows.Win32.System.Threading.STARTUPINFOW
// Assembly: Avalonia.BuildServices.414a6983686f44b4b34acf8b05411ccf, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 46AA80AB-7338-4A87-AD03-6DB25B4CC530
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.31\tools\netstandard2.0\Avalonia.BuildServices.dll

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
