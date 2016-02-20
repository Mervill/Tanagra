using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PushConstantRange
    {
        public ShaderStageFlags stageFlags;
        public UInt32 offset;
        public UInt32 size;
    }
}
