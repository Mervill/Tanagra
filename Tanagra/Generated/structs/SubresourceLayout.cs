using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SubresourceLayout
    {
        public DeviceSize offset;
        public DeviceSize size;
        public DeviceSize rowPitch;
        public DeviceSize arrayPitch;
        public DeviceSize depthPitch;
    }
}
