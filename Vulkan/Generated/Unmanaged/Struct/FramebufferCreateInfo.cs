using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FramebufferCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_FRAMEBUFFER_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public FramebufferCreateFlags Flags;
        public UInt64 RenderPass;
        public UInt32 AttachmentCount;
        public IntPtr Attachments;
        public UInt32 Width;
        public UInt32 Height;
        public UInt32 Layers;
    }
}
