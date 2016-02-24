using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DeviceQueueCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public DeviceQueueCreateFlags flags;
        public UInt32 queueFamilyIndex;
        public UInt32 queueCount;
        public Single[] QueuePriorities; // len:queueCount
    }
}
