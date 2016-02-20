using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DrawIndirectCommand
    {
        public UInt32 vertexCount;
        public UInt32 instanceCount;
        public UInt32 firstVertex;
        public UInt32 firstInstance;
    }
}
