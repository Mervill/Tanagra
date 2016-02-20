using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RenderPassCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public RenderPassCreateFlags flags;
        public UInt32 attachmentCount;
        public AttachmentDescription pAttachments;
        public UInt32 subpassCount;
        public SubpassDescription pSubpasses;
        public UInt32 dependencyCount;
        public SubpassDependency pDependencies;
    }
}
