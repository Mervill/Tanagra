using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DeviceCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public DeviceCreateFlags flags;
        public UInt32 queueCreateInfoCount;
        public DeviceQueueCreateInfo[] QueueCreateInfos; // len:queueCreateInfoCount
        public UInt32 enabledLayerCount;
        public Char[] EnabledLayerNames; // len:enabledLayerCount,null-terminated
        public UInt32 enabledExtensionCount;
        public Char[] EnabledExtensionNames; // len:enabledExtensionCount,null-terminated
        public PhysicalDeviceFeatures EnabledFeatures;
    }
}
