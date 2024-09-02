// Decompiled with JetBrains decompiler
// Type: Windows.Win32.Storage.FileSystem.FILE_SHARE_MODE
// Assembly: Avalonia.BuildServices.4d13ac13194b4e8f8d5d765a80db914b, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D40A8C9-4F8F-4CDA-A558-A155F40715C0
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.29\tools\netstandard2.0\Avalonia.BuildServices.dll

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
