using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DrawIndexedIndirectCommand
    {
        public UInt32 indexCount;
        public UInt32 instanceCount;
        public UInt32 firstIndex;
        public Int32 vertexOffset;
        public UInt32 firstInstance;
    }
}
