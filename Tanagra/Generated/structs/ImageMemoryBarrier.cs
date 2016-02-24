using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageMemoryBarrier
    {
        public StructureType sType;
        public IntPtr Next;
        public AccessFlags srcAccessMask;
        public AccessFlags dstAccessMask;
        public ImageLayout oldLayout;
        public ImageLayout newLayout;
        public UInt32 srcQueueFamilyIndex;
        public UInt32 dstQueueFamilyIndex;
        public Image image;
        public ImageSubresourceRange subresourceRange;
    }
}
