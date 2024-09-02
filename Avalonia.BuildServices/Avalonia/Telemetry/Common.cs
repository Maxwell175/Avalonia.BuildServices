// Decompiled with JetBrains decompiler
// Type: Avalonia.Telemetry.Common
// Assembly: Avalonia.BuildServices.4d13ac13194b4e8f8d5d765a80db914b, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D40A8C9-4F8F-4CDA-A558-A155F40715C0
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.29\tools\netstandard2.0\Avalonia.BuildServices.dll

using System;
using System.IO;

namespace Avalonia.Telemetry
{
  internal static class Common
  {
    public const string RECORD_FILE_PREFIX = "avalonia_build";
    internal static readonly string AppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".avalonia-build-tasks");
    internal static readonly string IdPath = Path.Combine(Common.AppDataFolder, "id");
  }
}
