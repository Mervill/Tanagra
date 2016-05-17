using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageBlit
    {
        internal Interop.ImageBlit* NativePointer;
        
        public ImageSubresourceLayers SrcSubresource
        {
            get { return NativePointer->SrcSubresource; }
            set { NativePointer->SrcSubresource = value; }
        }
        
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
        public Offset3D[] SrcOffsets
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
            set
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        public ImageSubresourceLayers DstSubresource
        {
            get { return NativePointer->DstSubresource; }
            set { NativePointer->DstSubresource = value; }
        }
        
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
        public Offset3D[] DstOffsets
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
            set
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        public ImageBlit()
        {
            NativePointer = (Interop.ImageBlit*)MemoryUtils.Allocate(typeof(Interop.ImageBlit));
        }
        
        public ImageBlit(ImageSubresourceLayers SrcSubresource, Offset3D[] SrcOffsets, ImageSubresourceLayers DstSubresource, Offset3D[] DstOffsets) : this()
        {
            this.SrcSubresource = SrcSubresource;
            this.SrcOffsets = SrcOffsets;
            this.DstSubresource = DstSubresource;
            this.DstOffsets = DstOffsets;
        }
    }
}
