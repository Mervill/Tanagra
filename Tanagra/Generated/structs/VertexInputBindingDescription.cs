using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VertexInputBindingDescription
    {
        public UInt32 binding;
        public UInt32 stride;
        public VertexInputRate inputRate;
    }
}
