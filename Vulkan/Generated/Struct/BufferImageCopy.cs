using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BufferImageCopy
    {
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize BufferOffset;
        /// <summary>
        /// Specified in texels
        /// </summary>
        public UInt32 BufferRowLength;
        public UInt32 BufferImageHeight;
        public ImageSubresourceLayers ImageSubresource;
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
        public Offset3D ImageOffset;
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
        public Extent3D ImageExtent;
        
        /// <param name="BufferOffset">Specified in bytes</param>
        /// <param name="BufferRowLength">Specified in texels</param>
        /// <param name="ImageOffset">Specified in pixels for both compressed and uncompressed images</param>
        /// <param name="ImageExtent">Specified in pixels for both compressed and uncompressed images</param>
        public BufferImageCopy(DeviceSize BufferOffset, UInt32 BufferRowLength, UInt32 BufferImageHeight, ImageSubresourceLayers ImageSubresource, Offset3D ImageOffset, Extent3D ImageExtent)
        {
            this.BufferOffset = BufferOffset;
            this.BufferRowLength = BufferRowLength;
            this.BufferImageHeight = BufferImageHeight;
            this.ImageSubresource = ImageSubresource;
            this.ImageOffset = ImageOffset;
            this.ImageExtent = ImageExtent;
        }
    }
}
