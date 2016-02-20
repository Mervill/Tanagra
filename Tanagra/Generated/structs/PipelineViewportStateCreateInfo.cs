using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineViewportStateCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public PipelineViewportStateCreateFlags flags;
        public UInt32 viewportCount;
        public Viewport pViewports;
        public UInt32 scissorCount;
        public Rect2D pScissors;
    }
}
