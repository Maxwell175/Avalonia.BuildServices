// Decompiled with JetBrains decompiler
// Type: Windows.Win32.Storage.FileSystem.FILE_SHARE_MODE
// Assembly: Avalonia.BuildServices.414a6983686f44b4b34acf8b05411ccf, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 46AA80AB-7338-4A87-AD03-6DB25B4CC530
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.31\tools\netstandard2.0\Avalonia.BuildServices.dll

using System;

namespace Windows.Win32.Storage.FileSystem
{
  [Flags]
  internal enum FILE_SHARE_MODE : uint
  {
    FILE_SHARE_NONE = 0,
    FILE_SHARE_DELETE = 4,
    FILE_SHARE_READ = 1,
    FILE_SHARE_WRITE = 2,
  }
}
