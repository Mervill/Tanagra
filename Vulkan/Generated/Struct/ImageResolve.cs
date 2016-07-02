using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageResolve
    {
        public ImageSubresourceLayers SrcSubresource;
        public Offset3D SrcOffset;
        public ImageSubresourceLayers DstSubresource;
        public Offset3D DstOffset;
        public Extent3D Extent;
        
        public ImageResolve(ImageSubresourceLayers SrcSubresource, Offset3D SrcOffset, ImageSubresourceLayers DstSubresource, Offset3D DstOffset, Extent3D Extent)
        {
            this.SrcSubresource = SrcSubresource;
            this.SrcOffset = SrcOffset;
            this.DstSubresource = DstSubresource;
            this.DstOffset = DstOffset;
            this.Extent = Extent;
        }
    }
}
