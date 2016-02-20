using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CommandBufferBeginInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public CommandBufferUsageFlags flags;
        public CommandBufferInheritanceInfo pInheritanceInfo;
    }
}
