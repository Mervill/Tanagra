using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageSubresourceRange
    {
        public ImageAspectFlags aspectMask;
        public UInt32 baseMipLevel;
        public UInt32 levelCount;
        public UInt32 baseArrayLayer;
        public UInt32 layerCount;
    }
}
