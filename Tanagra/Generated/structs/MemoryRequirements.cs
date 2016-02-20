using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryRequirements
    {
        public DeviceSize size;
        public DeviceSize alignment;
        public UInt32 memoryTypeBits;
    }
}
