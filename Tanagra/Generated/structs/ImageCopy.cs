using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageCopy
    {
        public ImageSubresourceLayers srcSubresource;
        public Offset3D srcOffset;
        public ImageSubresourceLayers dstSubresource;
        public Offset3D dstOffset;
        public Extent3D extent;
    }
}
