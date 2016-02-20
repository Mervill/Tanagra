using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ClearAttachment
    {
        public ImageAspectFlags aspectMask;
        public UInt32 colorAttachment;
        public ClearValue clearValue;
    }
}
