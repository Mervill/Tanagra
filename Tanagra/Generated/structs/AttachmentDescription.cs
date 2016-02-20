using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AttachmentDescription
    {
        public AttachmentDescriptionFlags flags;
        public Format format;
        public SampleCountFlags samples;
        public AttachmentLoadOp loadOp;
        public AttachmentStoreOp storeOp;
        public AttachmentLoadOp stencilLoadOp;
        public AttachmentStoreOp stencilStoreOp;
        public ImageLayout initialLayout;
        public ImageLayout finalLayout;
    }
}
