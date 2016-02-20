using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SubpassDependency
    {
        public UInt32 srcSubpass;
        public UInt32 dstSubpass;
        public PipelineStageFlags srcStageMask;
        public PipelineStageFlags dstStageMask;
        public AccessFlags srcAccessMask;
        public AccessFlags dstAccessMask;
        public DependencyFlags dependencyFlags;
    }
}
