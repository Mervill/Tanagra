using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageViewCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public ImageViewCreateFlags flags;
        public Image image;
        public ImageViewType viewType;
        public Format format;
        public ComponentMapping components;
        public ImageSubresourceRange subresourceRange;
    }
}
