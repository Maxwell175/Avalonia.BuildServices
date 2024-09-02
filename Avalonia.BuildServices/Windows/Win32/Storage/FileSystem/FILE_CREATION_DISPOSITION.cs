// Decompiled with JetBrains decompiler
// Type: Windows.Win32.Storage.FileSystem.FILE_CREATION_DISPOSITION
// Assembly: Avalonia.BuildServices.414a6983686f44b4b34acf8b05411ccf, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 46AA80AB-7338-4A87-AD03-6DB25B4CC530
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.31\tools\netstandard2.0\Avalonia.BuildServices.dll

namespace Windows.Win32.Storage.FileSystem
{
  internal enum FILE_CREATION_DISPOSITION : uint
  {
    CREATE_NEW = 1,
    CREATE_ALWAYS = 2,
    OPEN_EXISTING = 3,
    OPEN_ALWAYS = 4,
    TRUNCATE_EXISTING = 5,
  }
}
