using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InstanceCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public InstanceCreateFlags flags;
        public ApplicationInfo pApplicationInfo;
        public UInt32 enabledLayerCount;
        public Char ppEnabledLayerNames;
        public UInt32 enabledExtensionCount;
        public Char ppEnabledExtensionNames;
    }
}
