using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageBlit
    {
        public ImageSubresourceLayers srcSubresource;
        public Offset3D srcOffsets[2];
        public ImageSubresourceLayers dstSubresource;
        public Offset3D dstOffsets[2];
    }
}
