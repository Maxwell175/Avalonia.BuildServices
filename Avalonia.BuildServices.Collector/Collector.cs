// Decompiled with JetBrains decompiler
// Type: Avalonia.Telemetry.Collector
// Assembly: Avalonia.BuildServices.9164706a96e3427f8aaebeddbbc25360, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B0DD5459-F11C-4817-A603-2C93531B14CB
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.29\tools\netstandard2.0\Avalonia.BuildServices.Collector.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


#nullable enable
namespace Avalonia.Telemetry
{
  public class Collector
  {
    private readonly 
    #nullable disable
    HttpClient _httpClient;
    private const string DESTINATION_URL = "https://av-build-tel-api-v1.avaloniaui.net/api/usage";
    private static Stopwatch _stopwatch = new Stopwatch();

    public Collector()
    {
      AppContext.SetSwitch("System.Net.DisableIPv6", true);
      this._httpClient = new HttpClient((HttpMessageHandler) new SocketsHttpHandler()
      {
        ConnectCallback = (Func<SocketsHttpConnectionContext, CancellationToken, ValueTask<Stream>>) (async (context, cancellationToken) =>
        {
          IPHostEntry hostEntryAsync = await Dns.GetHostEntryAsync(context.DnsEndPoint.Host);
          Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
          socket.NoDelay = true;
          Stream stream;
          try
          {
            await socket.ConnectAsync(((IEnumerable<IPAddress>) hostEntryAsync.AddressList).Where<IPAddress>((Func<IPAddress, bool>) (x => x.AddressFamily == AddressFamily.InterNetwork)).ToArray<IPAddress>(), context.DnsEndPoint.Port, cancellationToken);
            stream = (Stream) new NetworkStream(socket, true);
          }
          catch
          {
            socket.Dispose();
            throw;
          }
          socket = (Socket) null;
          return stream;
        })
      })
      {
        Timeout = TimeSpan.FromMilliseconds(10000.0)
      };
    }

    public void Execute()
    {
      Console.In.Close();
      Console.Out.Close();
      Console.Error.Close();
      Console.SetIn((TextReader) new StringReader(""));
      Console.SetOut((TextWriter) new Collector.NullWriter());
      Console.SetError((TextWriter) new Collector.NullWriter());
      Mutex mutex = new Mutex(false, "Global\\Avalonia.BuildServices.Signal");
      if (!mutex.WaitOne(50))
        return;
      this.SweepAndSendAsync().Wait();
      mutex.ReleaseMutex();
    }

    private async Task SweepAndSendAsync()
    {
      Collector._stopwatch.Restart();
      while (true)
      {
        List<TelemetryPayload> payloads = new List<TelemetryPayload>();
        foreach (string path in Directory.EnumerateFiles(Common.AppDataFolder).ToList<string>())
        {
          if (Path.GetFileName(path).StartsWith("avalonia_build"))
          {
            try
            {
              payloads.Add(TelemetryPayload.FromByteArray(File.ReadAllBytes(path)));
            }
            catch (Exception ex)
            {
            }
            if (payloads.Count == 50)
              break;
          }
        }
        if (payloads.Count > 0)
        {
          bool sent = false;
          try
          {
            sent = await this.SendAsync((IList<TelemetryPayload>) payloads);
          }
          catch (Exception ex)
          {
          }
          if (sent)
          {
            Collector._stopwatch.Restart();
            foreach (TelemetryPayload telemetryPayload in payloads)
              File.Delete(Path.Combine(Common.AppDataFolder, "avalonia_build" + telemetryPayload.RecordId.ToString()));
          }
        }
        if (!(Collector._stopwatch.Elapsed > TimeSpan.FromSeconds(30.0)))
        {
          await Task.Delay(100);
          payloads = (List<TelemetryPayload>) null;
        }
        else
          break;
      }
    }

    private async Task<bool> SendAsync(IList<TelemetryPayload> payloads)
    {
      if (payloads.Count < 1)
        return true;
      ByteArrayContent content = new ByteArrayContent(TelemetryPayload.EncodeMany(payloads));
      try
      {
        return (await this._httpClient.PostAsync("https://av-build-tel-api-v1.avaloniaui.net/api/usage", (HttpContent) content)).IsSuccessStatusCode;
      }
      catch (HttpRequestException ex)
      {
      }
      return false;
    }

    private class NullWriter : TextWriter
    {
      public override Encoding Encoding => Encoding.UTF8;
    }
  }
}
