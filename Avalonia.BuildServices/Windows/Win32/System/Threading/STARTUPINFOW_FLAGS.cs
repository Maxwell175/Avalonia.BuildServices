// Decompiled with JetBrains decompiler
// Type: Windows.Win32.System.Threading.STARTUPINFOW_FLAGS
// Assembly: Avalonia.BuildServices.4d13ac13194b4e8f8d5d765a80db914b, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D40A8C9-4F8F-4CDA-A558-A155F40715C0
// Assembly location: \.nuget\packages\avalonia.buildservices\0.0.29\tools\netstandard2.0\Avalonia.BuildServices.dll

using System;

namespace Windows.Win32.System.Threading
{
  [Flags]
  internal enum STARTUPINFOW_FLAGS : uint
  {
    STARTF_FORCEONFEEDBACK = 64, // 0x00000040
    STARTF_FORCEOFFFEEDBACK = 128, // 0x00000080
    STARTF_PREVENTPINNING = 8192, // 0x00002000
    STARTF_RUNFULLSCREEN = 32, // 0x00000020
    STARTF_TITLEISAPPID = 4096, // 0x00001000
    STARTF_TITLEISLINKNAME = 2048, // 0x00000800
    STARTF_UNTRUSTEDSOURCE = 32768, // 0x00008000
    STARTF_USECOUNTCHARS = 8,
    STARTF_USEFILLATTRIBUTE = 16, // 0x00000010
    STARTF_USEHOTKEY = 512, // 0x00000200
    STARTF_USEPOSITION = 4,
    STARTF_USESHOWWINDOW = 1,
    STARTF_USESIZE = 2,
    STARTF_USESTDHANDLES = 256, // 0x00000100
  }
}
