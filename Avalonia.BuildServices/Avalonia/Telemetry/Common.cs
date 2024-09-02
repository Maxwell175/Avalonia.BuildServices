// Decompiled with JetBrains decompiler
// Type: Avalonia.Telemetry.Common
// Assembly: Avalonia.BuildServices.414a6983686f44b4b34acf8b05411ccf, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 46AA80AB-7338-4A87-AD03-6DB25B4CC530
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.31\tools\netstandard2.0\Avalonia.BuildServices.dll

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
