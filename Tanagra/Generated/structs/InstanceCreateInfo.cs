using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InstanceCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public InstanceCreateFlags flags;
        public ApplicationInfo ApplicationInfo;
        public UInt32 enabledLayerCount;
        public Char[] EnabledLayerNames; // len:enabledLayerCount,null-terminated
        public UInt32 enabledExtensionCount;
        public Char[] EnabledExtensionNames; // len:enabledExtensionCount,null-terminated
    }
}
