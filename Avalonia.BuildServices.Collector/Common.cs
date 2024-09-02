// Decompiled with JetBrains decompiler
// Type: Avalonia.Telemetry.Common
// Assembly: Avalonia.BuildServices.9164706a96e3427f8aaebeddbbc25360, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B0DD5459-F11C-4817-A603-2C93531B14CB
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.29\tools\netstandard2.0\Avalonia.BuildServices.Collector.dll

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
