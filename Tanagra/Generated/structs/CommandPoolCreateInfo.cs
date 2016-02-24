using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CommandPoolCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public CommandPoolCreateFlags flags;
        public UInt32 queueFamilyIndex;
    }
}
