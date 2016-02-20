using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FenceCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public FenceCreateFlags flags;
    }
}
