using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RenderPassCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public RenderPassCreateFlags flags;
        public UInt32 attachmentCount;
        public AttachmentDescription[] Attachments; // len:attachmentCount
        public UInt32 subpassCount;
        public SubpassDescription[] Subpasses; // len:subpassCount
        public UInt32 dependencyCount;
        public SubpassDependency[] Dependencies; // len:dependencyCount
    }
}
