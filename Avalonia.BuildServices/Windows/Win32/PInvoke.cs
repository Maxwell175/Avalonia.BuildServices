// Decompiled with JetBrains decompiler
// Type: Windows.Win32.PInvoke
// Assembly: Avalonia.BuildServices.4d13ac13194b4e8f8d5d765a80db914b, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D40A8C9-4F8F-4CDA-A558-A155F40715C0
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.29\tools\netstandard2.0\Avalonia.BuildServices.dll

using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.Security;
using Windows.Win32.Storage.FileSystem;
using Windows.Win32.System.Threading;

namespace Windows.Win32
{
  internal static class PInvoke
  {
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [DllImport("Kernel32", SetLastError = true)]
    internal static extern BOOL CloseHandle(HANDLE hObject);

    internal static unsafe BOOL CreateProcess(
      string lpApplicationName,
      PWSTR lpCommandLine,
      SECURITY_ATTRIBUTES? lpProcessAttributes,
      SECURITY_ATTRIBUTES? lpThreadAttributes,
      BOOL bInheritHandles,
      PROCESS_CREATION_FLAGS dwCreationFlags,
      void* lpEnvironment,
      string lpCurrentDirectory,
      in STARTUPINFOW lpStartupInfo,
      out PROCESS_INFORMATION lpProcessInformation)
    {
      fixed (PROCESS_INFORMATION* lpProcessInformation1 = &lpProcessInformation)
        fixed (STARTUPINFOW* lpStartupInfo1 = &lpStartupInfo)
          fixed (char* lpCurrentDirectory1 = lpCurrentDirectory)
            fixed (char* lpApplicationName1 = lpApplicationName)
            {
              SECURITY_ATTRIBUTES securityAttributes1 = lpProcessAttributes.HasValue ? lpProcessAttributes.Value : new SECURITY_ATTRIBUTES();
              SECURITY_ATTRIBUTES securityAttributes2 = lpThreadAttributes.HasValue ? lpThreadAttributes.Value : new SECURITY_ATTRIBUTES();
              return PInvoke.CreateProcess((PCWSTR) lpApplicationName1, lpCommandLine, lpProcessAttributes.HasValue ? &securityAttributes1 : (SECURITY_ATTRIBUTES*) null, lpThreadAttributes.HasValue ? &securityAttributes2 : (SECURITY_ATTRIBUTES*) null, bInheritHandles, dwCreationFlags, lpEnvironment, (PCWSTR) lpCurrentDirectory1, lpStartupInfo1, lpProcessInformation1);
            }
    }

    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [DllImport("Kernel32", EntryPoint = "CreateProcessW", SetLastError = true)]
    internal static extern unsafe BOOL CreateProcess(
      PCWSTR lpApplicationName,
      PWSTR lpCommandLine,
      [Optional] SECURITY_ATTRIBUTES* lpProcessAttributes,
      [Optional] SECURITY_ATTRIBUTES* lpThreadAttributes,
      BOOL bInheritHandles,
      PROCESS_CREATION_FLAGS dwCreationFlags,
      [Optional] void* lpEnvironment,
      PCWSTR lpCurrentDirectory,
      STARTUPINFOW* lpStartupInfo,
      PROCESS_INFORMATION* lpProcessInformation);

    internal static unsafe SafeFileHandle CreateFile(
      string lpFileName,
      FILE_ACCESS_FLAGS dwDesiredAccess,
      FILE_SHARE_MODE dwShareMode,
      SECURITY_ATTRIBUTES? lpSecurityAttributes,
      FILE_CREATION_DISPOSITION dwCreationDisposition,
      FILE_FLAGS_AND_ATTRIBUTES dwFlagsAndAttributes,
      SafeHandle hTemplateFile)
    {
      bool success = false;
      try
      {
        fixed (char* lpFileName1 = lpFileName)
        {
          SECURITY_ATTRIBUTES securityAttributes = lpSecurityAttributes.HasValue ? lpSecurityAttributes.Value : new SECURITY_ATTRIBUTES();
          HANDLE hTemplateFile1;
          if (hTemplateFile != null)
          {
            hTemplateFile.DangerousAddRef(ref success);
            hTemplateFile1 = (HANDLE) hTemplateFile.DangerousGetHandle();
          }
          else
            hTemplateFile1 = new HANDLE();
          return new SafeFileHandle((IntPtr) PInvoke.CreateFile((PCWSTR) lpFileName1, dwDesiredAccess, dwShareMode, lpSecurityAttributes.HasValue ? &securityAttributes : (SECURITY_ATTRIBUTES*) null, dwCreationDisposition, dwFlagsAndAttributes, hTemplateFile1), true);
        }
      }
      finally
      {
        if (success)
          hTemplateFile.DangerousRelease();
      }
    }

    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [DllImport("Kernel32", EntryPoint = "CreateFileW", SetLastError = true)]
    internal static extern unsafe HANDLE CreateFile(
      PCWSTR lpFileName,
      FILE_ACCESS_FLAGS dwDesiredAccess,
      FILE_SHARE_MODE dwShareMode,
      [Optional] SECURITY_ATTRIBUTES* lpSecurityAttributes,
      FILE_CREATION_DISPOSITION dwCreationDisposition,
      FILE_FLAGS_AND_ATTRIBUTES dwFlagsAndAttributes,
      HANDLE hTemplateFile);
  }
}
