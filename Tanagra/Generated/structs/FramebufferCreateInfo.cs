using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FramebufferCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public FramebufferCreateFlags flags;
        public RenderPass renderPass;
        public UInt32 attachmentCount;
        public ImageView pAttachments;
        public UInt32 width;
        public UInt32 height;
        public UInt32 layers;
    }
}
