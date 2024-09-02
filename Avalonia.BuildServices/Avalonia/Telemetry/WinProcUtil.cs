// Decompiled with JetBrains decompiler
// Type: Avalonia.Telemetry.WinProcUtil
// Assembly: Avalonia.BuildServices.414a6983686f44b4b34acf8b05411ccf, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 46AA80AB-7338-4A87-AD03-6DB25B4CC530
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.31\tools\netstandard2.0\Avalonia.BuildServices.dll

using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Security;
using Windows.Win32.Storage.FileSystem;
using Windows.Win32.System.Threading;

namespace Avalonia.Telemetry
{
  public class WinProcUtil
  {
    public static unsafe void StartBackground(string exe, string cmdline)
    {
      using (SafeFileHandle file = PInvoke.CreateFile("NUL", (FILE_ACCESS_FLAGS) 268435456, FILE_SHARE_MODE.FILE_SHARE_NONE, new SECURITY_ATTRIBUTES?(new SECURITY_ATTRIBUTES()
      {
        nLength = (uint) Marshal.SizeOf<SECURITY_ATTRIBUTES>(),
        lpSecurityDescriptor = (void*) null,
        bInheritHandle = (BOOL) true
      }), FILE_CREATION_DISPOSITION.OPEN_EXISTING, FILE_FLAGS_AND_ATTRIBUTES.SECURITY_ANONYMOUS, (SafeHandle) null))
      {
        IntPtr handle = file.DangerousGetHandle();
        STARTUPINFOW lpStartupInfo = new STARTUPINFOW()
        {
          cb = (uint) Marshal.SizeOf<STARTUPINFOW>(),
          dwFlags = STARTUPINFOW_FLAGS.STARTF_USESTDHANDLES,
          hStdInput = new HANDLE(handle),
          hStdOutput = new HANDLE(handle),
          hStdError = new HANDLE(handle)
        };
        fixed (char* lpCommandLine = cmdline)
        {
          PROCESS_INFORMATION lpProcessInformation;
          if (!(bool) PInvoke.CreateProcess(exe, (PWSTR) lpCommandLine, new SECURITY_ATTRIBUTES?(), new SECURITY_ATTRIBUTES?(), (BOOL) false, PROCESS_CREATION_FLAGS.DETACHED_PROCESS | PROCESS_CREATION_FLAGS.CREATE_NEW_PROCESS_GROUP | PROCESS_CREATION_FLAGS.CREATE_NO_WINDOW, (void*) null, Directory.GetCurrentDirectory(), in lpStartupInfo, out lpProcessInformation))
            throw new Win32Exception();
          PInvoke.CloseHandle(lpProcessInformation.hProcess);
          PInvoke.CloseHandle(lpProcessInformation.hThread);
        }
      }
    }
  }
}
