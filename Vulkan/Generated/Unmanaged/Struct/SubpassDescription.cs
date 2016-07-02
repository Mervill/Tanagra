using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SubpassDescription
    {
        public SubpassDescriptionFlags Flags;
        /// <summary>
        /// Must be VK_PIPELINE_BIND_POINT_GRAPHICS for now
        /// </summary>
        public PipelineBindPoint PipelineBindPoint;
        public UInt32 InputAttachmentCount;
        public IntPtr InputAttachments;
        public UInt32 ColorAttachmentCount;
        public IntPtr ColorAttachments;
        public IntPtr ResolveAttachments;
        public IntPtr DepthStencilAttachment;
        public UInt32 PreserveAttachmentCount;
        public IntPtr PreserveAttachments;
    }
}
