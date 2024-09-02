// Decompiled with JetBrains decompiler
// Type: Avalonia.Telemetry.Program
// Assembly: Avalonia.BuildServices.4d13ac13194b4e8f8d5d765a80db914b, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D40A8C9-4F8F-4CDA-A558-A155F40715C0
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.29\tools\netstandard2.0\Avalonia.BuildServices.dll

namespace Avalonia.Telemetry
{
  public class Program
  {
    private static int Main(string[] args)
    {
      new AvaloniaStatsTask().Execute();
      return 1;
    }
  }
}
