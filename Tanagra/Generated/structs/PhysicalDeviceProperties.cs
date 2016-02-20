using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PhysicalDeviceProperties
    {
        public UInt32 apiVersion;
        public UInt32 driverVersion;
        public UInt32 vendorID;
        public UInt32 deviceID;
        public PhysicalDeviceType deviceType;
        public Char deviceName;
        public Byte pipelineCacheUUID;
        public PhysicalDeviceLimits limits;
        public PhysicalDeviceSparseProperties sparseProperties;
    }
}
