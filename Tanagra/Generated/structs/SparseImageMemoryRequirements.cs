using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SparseImageMemoryRequirements
    {
        public SparseImageFormatProperties formatProperties;
        public UInt32 imageMipTailFirstLod;
        public DeviceSize imageMipTailSize;
        public DeviceSize imageMipTailOffset;
        public DeviceSize imageMipTailStride;
    }
}
