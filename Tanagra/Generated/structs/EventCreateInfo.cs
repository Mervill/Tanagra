using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct EventCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public EventCreateFlags flags;
    }
}
