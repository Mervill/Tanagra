using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageFormatProperties
    {
        public Extent3D maxExtent;
        public UInt32 maxMipLevels;
        public UInt32 maxArrayLayers;
        public SampleCountFlags sampleCounts;
        public DeviceSize maxResourceSize;
    }
}
