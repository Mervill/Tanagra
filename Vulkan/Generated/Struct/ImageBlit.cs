using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageBlit
    {
        public struct SrcOffsetsInfo
        {
            public const UInt32 Length = 2;
            
            public Offset3D Value00;
            public Offset3D Value01;
            
            public Offset3D this[uint key]
            {
                get
                {
                    switch(key)
                    {
                        default: throw new IndexOutOfRangeException();
                        case 0: return Value00;
                        case 1: return Value01;
                    }
                }
            }
        }
        public struct DstOffsetsInfo
        {
            public const UInt32 Length = 2;
            
            public Offset3D Value00;
            public Offset3D Value01;
            
            public Offset3D this[uint key]
            {
                get
                {
                    switch(key)
                    {
                        default: throw new IndexOutOfRangeException();
                        case 0: return Value00;
                        case 1: return Value01;
                    }
                }
            }
        }
        public ImageSubresourceLayers SrcSubresource;
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
        public SrcOffsetsInfo SrcOffsets;
        public ImageSubresourceLayers DstSubresource;
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
        public DstOffsetsInfo DstOffsets;
        
        /// <param name="SrcOffsets">Specified in pixels for both compressed and uncompressed images</param>
        /// <param name="DstOffsets">Specified in pixels for both compressed and uncompressed images</param>
        public ImageBlit(ImageSubresourceLayers SrcSubresource, SrcOffsetsInfo SrcOffsets, ImageSubresourceLayers DstSubresource, DstOffsetsInfo DstOffsets)
        {
            this.SrcSubresource = SrcSubresource;
            this.SrcOffsets = SrcOffsets;
            this.DstSubresource = DstSubresource;
            this.DstOffsets = DstOffsets;
        }
    }
}
