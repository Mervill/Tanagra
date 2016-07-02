using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageCopy
    {
        public ImageSubresourceLayers SrcSubresource;
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
        public Offset3D SrcOffset;
        public ImageSubresourceLayers DstSubresource;
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
        public Offset3D DstOffset;
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
        public Extent3D Extent;
        
        /// <param name="SrcOffset">Specified in pixels for both compressed and uncompressed images</param>
        /// <param name="DstOffset">Specified in pixels for both compressed and uncompressed images</param>
        /// <param name="Extent">Specified in pixels for both compressed and uncompressed images</param>
        public ImageCopy(ImageSubresourceLayers SrcSubresource, Offset3D SrcOffset, ImageSubresourceLayers DstSubresource, Offset3D DstOffset, Extent3D Extent)
        {
            this.SrcSubresource = SrcSubresource;
            this.SrcOffset = SrcOffset;
            this.DstSubresource = DstSubresource;
            this.DstOffset = DstOffset;
            this.Extent = Extent;
        }
    }
}
