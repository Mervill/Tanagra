using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SparseBufferMemoryBindInfo
    {
        public UInt64 Buffer;
        public UInt32 BindCount;
        public IntPtr Binds;
    }
}
