using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FramebufferCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public FramebufferCreateFlags flags;
        public RenderPass renderPass;
        public UInt32 attachmentCount;
        public ImageView[] Attachments; // len:attachmentCount
        public UInt32 width;
        public UInt32 height;
        public UInt32 layers;
    }
}
