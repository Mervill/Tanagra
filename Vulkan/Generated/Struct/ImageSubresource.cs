using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageSubresource
    {
        public ImageAspectFlags AspectMask;
        public UInt32 MipLevel;
        public UInt32 ArrayLayer;
        
        public ImageSubresource(ImageAspectFlags AspectMask, UInt32 MipLevel, UInt32 ArrayLayer)
        {
            this.AspectMask = AspectMask;
            this.MipLevel = MipLevel;
            this.ArrayLayer = ArrayLayer;
        }
    }
}
