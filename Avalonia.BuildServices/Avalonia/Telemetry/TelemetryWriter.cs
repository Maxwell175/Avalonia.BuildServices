// Decompiled with JetBrains decompiler
// Type: Avalonia.Telemetry.TelemetryWriter
// Assembly: Avalonia.BuildServices.4d13ac13194b4e8f8d5d765a80db914b, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D40A8C9-4F8F-4CDA-A558-A155F40715C0
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.29\tools\netstandard2.0\Avalonia.BuildServices.dll

using System.IO;

namespace Avalonia.Telemetry
{
  public class TelemetryWriter
  {
    internal static void WriteTelemetry(TelemetryPayload telemetryPayload)
    {
      string path = Path.Combine(AvaloniaStatsTask.AppDataFolder, "avalonia_build" + telemetryPayload.RecordId.ToString());
      if (File.Exists(path))
        return;
      byte[] bytes = telemetryPayload.Encode();
      File.WriteAllBytes(path, bytes);
    }
  }
}
