using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct QueueFamilyProperties
    {
        public QueueFlags queueFlags;
        public UInt32 queueCount;
        public UInt32 timestampValidBits;
        public Extent3D minImageTransferGranularity;
    }
}
