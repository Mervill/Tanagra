using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RenderPassBeginInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public RenderPass renderPass;
        public Framebuffer framebuffer;
        public Rect2D renderArea;
        public UInt32 clearValueCount;
        public ClearValue[] ClearValues; // len:clearValueCount
    }
}
