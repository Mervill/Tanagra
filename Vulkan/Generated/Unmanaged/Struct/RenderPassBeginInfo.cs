using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RenderPassBeginInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_RENDER_PASS_BEGIN_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        public UInt64 RenderPass;
        public UInt64 Framebuffer;
        public Rect2D RenderArea;
        public UInt32 ClearValueCount;
        public IntPtr ClearValues;
    }
}
