using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SparseBufferMemoryBindInfo
    {
        public Buffer buffer;
        public UInt32 bindCount;
        public SparseMemoryBind pBinds;
    }
}
