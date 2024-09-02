// Decompiled with JetBrains decompiler
// Type: Avalonia.Telemetry.AvaloniaStatsTask
// Assembly: Avalonia.BuildServices.4d13ac13194b4e8f8d5d765a80db914b, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D40A8C9-4F8F-4CDA-A558-A155F40715C0
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.29\tools\netstandard2.0\Avalonia.BuildServices.dll

using Microsoft.Build.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Avalonia.Telemetry
{
  public class AvaloniaStatsTask : ITask
  {
    private Guid? _uniqueIdentifier;
    internal static readonly string AppDataFolder = Common.AppDataFolder;
    internal static readonly string IdPath = Common.IdPath;

    [Required]
    public string ProjectName { get; set; }

    [Required]
    public string TargetFramework { get; set; }

    public string RuntimeIdentifier { get; set; }

    public string AvaloniaPackageVersion { get; set; }

    [Required]
    public string OutputType { get; set; }

    public bool Execute()
    {
      if (Environment.GetEnvironmentVariables().Contains((object) "AVALONIA_TELEMETRY_OPTOUT") || Environment.GetEnvironmentVariables().Contains((object) "NCrunch"))
        return true;
      TelemetryPayload telemetryData = (TelemetryPayload) null;
      try
      {
        telemetryData = this.RunStats();
      }
      catch (Exception ex)
      {
      }
      if (telemetryData == null)
        return true;
      this.WriteTelemetry(telemetryData);
      this.StartCollector();
      return true;
    }

    private void WriteTelemetry(TelemetryPayload telemetryData)
    {
      try
      {
        TelemetryWriter.WriteTelemetry(telemetryData);
      }
      catch (Exception ex)
      {
      }
    }

    private void StartCollector()
    {
      string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      string str1 = Path.Combine(directoryName, "Avalonia.BuildServices.Collector.dll");
      string str2 = "exec --runtimeconfig " + Path.Combine(directoryName, "runtimeconfig.json") + " " + str1;
      if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
      {
        WinProcUtil.StartBackground((string) null, "dotnet " + str2);
      }
      else
      {
        Process process = Process.Start(new ProcessStartInfo()
        {
          CreateNoWindow = true,
          UseShellExecute = false,
          RedirectStandardError = true,
          RedirectStandardInput = true,
          RedirectStandardOutput = true,
          FileName = "dotnet",
          Arguments = str2
        });
        process?.StandardError.Close();
        process?.StandardInput.Close();
        process?.StandardOutput.Close();
      }
    }

    private Guid UniqueIdentifier
    {
      get
      {
        if (!this._uniqueIdentifier.HasValue)
        {
          if (!File.Exists(AvaloniaStatsTask.IdPath))
            File.WriteAllBytes(AvaloniaStatsTask.IdPath, Guid.NewGuid().ToByteArray());
          this._uniqueIdentifier = new Guid?(new Guid(File.ReadAllBytes(AvaloniaStatsTask.IdPath)));
        }
        return this._uniqueIdentifier.Value;
      }
    }

    private TelemetryPayload RunStats()
    {
      if (!Directory.Exists(AvaloniaStatsTask.AppDataFolder))
        Directory.CreateDirectory(AvaloniaStatsTask.AppDataFolder);
      return TelemetryPayload.Initialise(this.UniqueIdentifier, this.ProjectName, this.TargetFramework, this.RuntimeIdentifier, this.AvaloniaPackageVersion, this.OutputType);
    }

    public IBuildEngine BuildEngine { get; set; }

    public ITaskHost HostObject { get; set; }
  }
}
