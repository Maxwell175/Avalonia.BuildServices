// Decompiled with JetBrains decompiler
// Type: Windows.Win32.Storage.FileSystem.FILE_CREATION_DISPOSITION
// Assembly: Avalonia.BuildServices.4d13ac13194b4e8f8d5d765a80db914b, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D40A8C9-4F8F-4CDA-A558-A155F40715C0
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.29\tools\netstandard2.0\Avalonia.BuildServices.dll

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
