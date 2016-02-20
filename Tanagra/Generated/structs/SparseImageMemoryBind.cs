using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SparseImageMemoryBind
    {
        public ImageSubresource subresource;
        public Offset3D offset;
        public Extent3D extent;
        public DeviceMemory memory;
        public DeviceSize memoryOffset;
        public SparseMemoryBindFlags flags;
    }
}
