using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BufferImageCopy
    {
        public DeviceSize bufferOffset;
        public UInt32 bufferRowLength;
        public UInt32 bufferImageHeight;
        public ImageSubresourceLayers imageSubresource;
        public Offset3D imageOffset;
        public Extent3D imageExtent;
    }
}
