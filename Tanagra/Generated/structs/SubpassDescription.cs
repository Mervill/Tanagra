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
        public AttachmentReference pInputAttachments;
        public UInt32 colorAttachmentCount;
        public AttachmentReference pColorAttachments;
        public AttachmentReference pResolveAttachments;
        public AttachmentReference pDepthStencilAttachment;
        public UInt32 preserveAttachmentCount;
        public UInt32 pPreserveAttachments;
    }
}
