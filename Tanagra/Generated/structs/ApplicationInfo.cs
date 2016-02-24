using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ApplicationInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public String ApplicationName; // len:null-terminated
        public UInt32 applicationVersion;
        public String EngineName; // len:null-terminated
        public UInt32 engineVersion;
        public UInt32 apiVersion;
    }
}
