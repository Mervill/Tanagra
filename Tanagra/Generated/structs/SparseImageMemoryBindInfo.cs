using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SparseImageMemoryBindInfo
    {
        public Image image;
        public UInt32 bindCount;
        public SparseImageMemoryBind pBinds;
    }
}
