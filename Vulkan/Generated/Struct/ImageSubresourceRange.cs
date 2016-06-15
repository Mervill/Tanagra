using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageSubresourceRange
    {
        public ImageAspectFlags AspectMask;
        public UInt32 BaseMipLevel;
        public UInt32 LevelCount;
        public UInt32 BaseArrayLayer;
        public UInt32 LayerCount;
        
        public ImageSubresourceRange(ImageAspectFlags AspectMask, UInt32 BaseMipLevel, UInt32 LevelCount, UInt32 BaseArrayLayer, UInt32 LayerCount)
        {
            this.AspectMask = AspectMask;
            this.BaseMipLevel = BaseMipLevel;
            this.LevelCount = LevelCount;
            this.BaseArrayLayer = BaseArrayLayer;
            this.LayerCount = LayerCount;
        }
    }
}
