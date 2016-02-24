using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CommandBufferBeginInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public CommandBufferUsageFlags flags;
        public CommandBufferInheritanceInfo InheritanceInfo;
    }
}
