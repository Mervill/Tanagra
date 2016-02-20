using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VertexInputAttributeDescription
    {
        public UInt32 location;
        public UInt32 binding;
        public Format format;
        public UInt32 offset;
    }
}
