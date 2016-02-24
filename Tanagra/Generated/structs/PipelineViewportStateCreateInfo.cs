using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineViewportStateCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public PipelineViewportStateCreateFlags flags;
        public UInt32 viewportCount;
        public Viewport[] Viewports; // len:viewportCount
        public UInt32 scissorCount;
        public Rect2D[] Scissors; // len:scissorCount
    }
}
