using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SubpassDescription
    {
        public SubpassDescriptionFlags flags;
        public PipelineBindPoint pipelineBindPoint;
        public UInt32 inputAttachmentCount;
        public AttachmentReference[] InputAttachments; // len:inputAttachmentCount
        public UInt32 colorAttachmentCount;
        public AttachmentReference[] ColorAttachments; // len:colorAttachmentCount
        public AttachmentReference[] ResolveAttachments; // len:colorAttachmentCount
        public AttachmentReference DepthStencilAttachment;
        public UInt32 preserveAttachmentCount;
        public UInt32[] PreserveAttachments; // len:preserveAttachmentCount
    }
}
