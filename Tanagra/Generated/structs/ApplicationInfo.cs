using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ApplicationInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public String pApplicationName;
        public UInt32 applicationVersion;
        public String pEngineName;
        public UInt32 engineVersion;
        public UInt32 apiVersion;
    }
}
