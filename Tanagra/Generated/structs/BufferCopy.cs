using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BufferCopy
    {
        public DeviceSize srcOffset;
        public DeviceSize dstOffset;
        public DeviceSize size;
    }
}
