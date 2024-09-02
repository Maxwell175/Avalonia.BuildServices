// Decompiled with JetBrains decompiler
// Type: Avalonia.Telemetry.CiProvider
// Assembly: Avalonia.BuildServices.41a83caa4e4049439139943d38bf080f, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B932F8E0-14A1-478B-83B5-8C42A95A0FD3
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.31\tools\netstandard2.0\Avalonia.BuildServices.Collector.dll

namespace Avalonia.Telemetry
{
  public enum CiProvider
  {
    None,
    Bamboo,
    Bitrise,
    SpaceAutomation,
    Jenkins,
    AppVeyor,
    GitLab,
    BitBucket,
    Travis,
    TeamCity,
    GitHubActions,
    AzurePipelines,
  }
}
