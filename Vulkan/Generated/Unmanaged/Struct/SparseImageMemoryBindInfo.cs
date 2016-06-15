using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SparseImageMemoryBindInfo
    {
        public UInt64 Image;
        public UInt32 BindCount;
        public IntPtr Binds;
    }
}
