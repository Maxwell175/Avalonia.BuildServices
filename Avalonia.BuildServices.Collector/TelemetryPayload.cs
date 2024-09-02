// Decompiled with JetBrains decompiler
// Type: Avalonia.Telemetry.TelemetryPayload
// Assembly: Avalonia.BuildServices.9164706a96e3427f8aaebeddbbc25360, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B0DD5459-F11C-4817-A603-2C93531B14CB
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.29\tools\netstandard2.0\Avalonia.BuildServices.Collector.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace Avalonia.Telemetry
{
  public class TelemetryPayload
  {
    public static readonly ushort Version = 1;

    private TelemetryPayload()
    {
    }

    public Guid RecordId { get; private set; }

    public DateTimeOffset TimeStamp { get; private set; }

    public Guid Machine { get; private set; }

    public string ProjectRootHash { get; private set; }

    public string ProjectHash { get; private set; }

    public Ide Ide { get; private set; }

    public CiProvider CiProvider { get; private set; }

    public string OutputType { get; set; }

    public string Tfm { get; private set; }

    public string Rid { get; private set; }

    public string AvaloniaMainPackageVersion { get; private set; }

    public string OSDescription { get; private set; }

    public Architecture ProcessorArchitecture { get; private set; }

    public static byte[] EncodeMany(IList<TelemetryPayload> payloads)
    {
      if (payloads.Count <= 0)
        return Array.Empty<byte>();
      if (payloads.Count > 50)
        throw new Exception("No more than 50 in a single packet.");
      using (MemoryStream output = new MemoryStream())
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) output))
        {
          binaryWriter.Write(payloads.Count);
          foreach (TelemetryPayload payload in (IEnumerable<TelemetryPayload>) payloads)
            binaryWriter.Write(payload.Encode());
          return output.ToArray();
        }
      }
    }

    public byte[] Encode()
    {
      using (MemoryStream output = new MemoryStream())
      {
        using (BinaryWriter binaryWriter1 = new BinaryWriter((Stream) output))
        {
          binaryWriter1.Write(TelemetryPayload.Version);
          BinaryWriter binaryWriter2 = binaryWriter1;
          Guid guid = this.RecordId;
          byte[] byteArray1 = guid.ToByteArray();
          binaryWriter2.Write(byteArray1);
          binaryWriter1.Write(this.TimeStamp.ToUnixTimeMilliseconds());
          BinaryWriter binaryWriter3 = binaryWriter1;
          guid = this.Machine;
          byte[] byteArray2 = guid.ToByteArray();
          binaryWriter3.Write(byteArray2);
          binaryWriter1.Write(this.ProjectRootHash);
          binaryWriter1.Write(this.ProjectHash);
          binaryWriter1.Write(string.Empty);
          binaryWriter1.Write(string.Empty);
          binaryWriter1.Write(string.Empty);
          binaryWriter1.Write((byte) this.Ide);
          binaryWriter1.Write((byte) this.CiProvider);
          binaryWriter1.Write(this.OutputType ?? string.Empty);
          binaryWriter1.Write(this.Tfm ?? string.Empty);
          binaryWriter1.Write(this.Rid ?? string.Empty);
          binaryWriter1.Write(this.AvaloniaMainPackageVersion ?? string.Empty);
          binaryWriter1.Write(this.OSDescription);
          binaryWriter1.Write((byte) this.ProcessorArchitecture);
          return output.ToArray();
        }
      }
    }

    public static TelemetryPayload FromBinaryReader(BinaryReader reader)
    {
      TelemetryPayload telemetryPayload = new TelemetryPayload();
      if ((int) reader.ReadInt16() == (int) TelemetryPayload.Version)
      {
        telemetryPayload.RecordId = new Guid(reader.ReadBytes(16));
        telemetryPayload.TimeStamp = DateTimeOffset.FromUnixTimeMilliseconds(reader.ReadInt64());
        telemetryPayload.Machine = new Guid(reader.ReadBytes(16));
        telemetryPayload.ProjectRootHash = reader.ReadString();
        telemetryPayload.ProjectHash = reader.ReadString();
        reader.ReadString();
        reader.ReadString();
        reader.ReadString();
        telemetryPayload.Ide = (Ide) reader.ReadByte();
        telemetryPayload.CiProvider = (CiProvider) reader.ReadByte();
        telemetryPayload.OutputType = reader.ReadString();
        telemetryPayload.Tfm = reader.ReadString();
        telemetryPayload.Rid = reader.ReadString();
        telemetryPayload.AvaloniaMainPackageVersion = reader.ReadString();
        telemetryPayload.OSDescription = reader.ReadString();
        telemetryPayload.ProcessorArchitecture = (Architecture) reader.ReadByte();
      }
      return telemetryPayload;
    }

    public static TelemetryPayload FromByteArray(byte[] data)
    {
      TelemetryPayload telemetryPayload = new TelemetryPayload();
      using (MemoryStream input = new MemoryStream(data))
      {
        using (BinaryReader reader = new BinaryReader((Stream) input))
          return TelemetryPayload.FromBinaryReader(reader);
      }
    }

    public static IList<TelemetryPayload> ManyFromByteArray(byte[] data)
    {
      using (MemoryStream input = new MemoryStream(data))
      {
        using (BinaryReader reader = new BinaryReader((Stream) input))
        {
          List<TelemetryPayload> telemetryPayloadList = new List<TelemetryPayload>();
          int num = reader.ReadInt32();
          if (num > 50)
            throw new Exception("Unexpected number of payloads, 50 is the maximum");
          for (int index = 0; index < num; ++index)
            telemetryPayloadList.Add(TelemetryPayload.FromBinaryReader(reader));
          return (IList<TelemetryPayload>) telemetryPayloadList;
        }
      }
    }

    public static TelemetryPayload Initialise(
      Guid machine,
      string projectName,
      string tfm,
      string rid,
      string avaloniaVersion,
      string outputType)
    {
      return new TelemetryPayload()
      {
        RecordId = Guid.NewGuid(),
        TimeStamp = DateTimeOffset.UtcNow,
        Machine = machine,
        Ide = TelemetryPayload.TryDetectIde(),
        CiProvider = TelemetryPayload.DetectCiProvider(),
        OutputType = outputType,
        Tfm = tfm,
        Rid = rid,
        AvaloniaMainPackageVersion = avaloniaVersion,
        OSDescription = RuntimeInformation.OSDescription,
        ProcessorArchitecture = RuntimeInformation.ProcessArchitecture,
        ProjectRootHash = TelemetryPayload.HashProperty((projectName != null ? ((IEnumerable<string>) projectName.Split('.')).FirstOrDefault<string>() : (string) null) ?? ""),
        ProjectHash = TelemetryPayload.HashProperty(projectName)
      };
    }

    internal static string HashProperty(string value)
    {
      if (string.IsNullOrEmpty(value))
        return string.Empty;
      using (SHA256 shA256 = SHA256.Create())
      {
        byte[] bytes = Encoding.UTF8.GetBytes(value);
        return BitConverter.ToString(shA256.ComputeHash(bytes)).Replace("-", string.Empty);
      }
    }

    private static Ide TryDetectIde()
    {
      IDictionary environmentVariables = Environment.GetEnvironmentVariables();
      return !environmentVariables.Contains((object) "VSMAC_MSBUILD_BUILDER_SETTINGS_FILE") ? (!environmentVariables.Contains((object) "VisualStudioVersion") ? (!environmentVariables.Contains((object) "IDEA_INITIAL_DIRECTORY") ? (!environmentVariables.Contains((object) "RESHARPER_FUS_BUILD") ? (!environmentVariables.Contains((object) "PWD") || !environmentVariables[(object) "PWD"].ToString().Contains("Rider") ? Ide.Cli : Ide.Rider) : Ide.Rider) : Ide.Rider) : Ide.Vs) : Ide.Vs4Mac;
    }

    public static CiProvider DetectCiProvider()
    {
      IDictionary environmentVariables = Environment.GetEnvironmentVariables();
      if (environmentVariables.Contains((object) "bamboo_planKey"))
        return CiProvider.Bamboo;
      if (environmentVariables.Contains((object) "BITRISE_BUILD_URL"))
        return CiProvider.Bitrise;
      if (environmentVariables.Contains((object) "JB_SPACE_PROJECT_KEY"))
        return CiProvider.SpaceAutomation;
      if (environmentVariables.Contains((object) "JENKINS_HOME"))
        return CiProvider.Jenkins;
      if (environmentVariables.Contains((object) "APPVEYOR"))
        return CiProvider.AppVeyor;
      if (environmentVariables.Contains((object) "GITLAB_CI"))
        return CiProvider.GitLab;
      if (environmentVariables.Contains((object) "BITBUCKET_PIPELINE_UUID"))
        return CiProvider.BitBucket;
      if (environmentVariables.Contains((object) "TRAVIS"))
        return CiProvider.Travis;
      if (environmentVariables.Contains((object) "TEAMCITY_VERSION"))
        return CiProvider.TeamCity;
      if (environmentVariables.Contains((object) "GITHUB_ACTIONS"))
        return CiProvider.GitHubActions;
      return environmentVariables.Contains((object) "TF_BUILD") ? CiProvider.AzurePipelines : CiProvider.None;
    }
  }
}
