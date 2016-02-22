using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DeviceCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public DeviceCreateFlags flags;
        public UInt32 queueCreateInfoCount;
        public DeviceQueueCreateInfo* pQueueCreateInfos;
        public UInt32 enabledLayerCount;
        public Char ppEnabledLayerNames;
        public UInt32 enabledExtensionCount;
        public Char ppEnabledExtensionNames;
        public PhysicalDeviceFeatures* pEnabledFeatures;
    }
}
