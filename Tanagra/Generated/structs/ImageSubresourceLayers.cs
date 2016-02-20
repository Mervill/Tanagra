using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageSubresourceLayers
    {
        public ImageAspectFlags aspectMask;
        public UInt32 mipLevel;
        public UInt32 baseArrayLayer;
        public UInt32 layerCount;
    }
}
