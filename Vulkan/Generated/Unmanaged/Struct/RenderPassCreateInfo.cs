using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RenderPassCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public RenderPassCreateFlags Flags;
        public UInt32 AttachmentCount;
        public IntPtr Attachments;
        public UInt32 SubpassCount;
        public IntPtr Subpasses;
        public UInt32 DependencyCount;
        public IntPtr Dependencies;
    }
}
