// Decompiled with JetBrains decompiler
// Type: Windows.Win32.Security.SECURITY_ATTRIBUTES
// Assembly: Avalonia.BuildServices.414a6983686f44b4b34acf8b05411ccf, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 46AA80AB-7338-4A87-AD03-6DB25B4CC530
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.31\tools\netstandard2.0\Avalonia.BuildServices.dll

using Windows.Win32.Foundation;

namespace Windows.Win32.Security
{
  internal struct SECURITY_ATTRIBUTES
  {
    internal uint nLength;
    internal unsafe void* lpSecurityDescriptor;
    internal BOOL bInheritHandle;
  }
}
