using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageSubresource
    {
        public ImageAspectFlags aspectMask;
        public UInt32 mipLevel;
        public UInt32 arrayLayer;
    }
}
