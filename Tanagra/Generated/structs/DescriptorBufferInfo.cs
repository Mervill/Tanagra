using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DescriptorBufferInfo
    {
        public Buffer buffer;
        public DeviceSize offset;
        public DeviceSize range;
    }
}
