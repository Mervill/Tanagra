using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SemaphoreCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public SemaphoreCreateFlags flags;
    }
}
