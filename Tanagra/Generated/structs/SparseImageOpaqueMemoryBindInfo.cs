using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SparseImageOpaqueMemoryBindInfo
    {
        public Image image;
        public UInt32 bindCount;
        public SparseMemoryBind pBinds;
    }
}
