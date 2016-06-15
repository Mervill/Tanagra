using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageSubresourceLayers
    {
        public ImageAspectFlags AspectMask;
        public UInt32 MipLevel;
        public UInt32 BaseArrayLayer;
        public UInt32 LayerCount;
        
        public ImageSubresourceLayers(ImageAspectFlags AspectMask, UInt32 MipLevel, UInt32 BaseArrayLayer, UInt32 LayerCount)
        {
            this.AspectMask = AspectMask;
            this.MipLevel = MipLevel;
            this.BaseArrayLayer = BaseArrayLayer;
            this.LayerCount = LayerCount;
        }
    }
}
