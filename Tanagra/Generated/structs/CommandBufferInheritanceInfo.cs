using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CommandBufferInheritanceInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public RenderPass renderPass;
        public UInt32 subpass;
        public Framebuffer framebuffer;
        public Boolean occlusionQueryEnable;
        public QueryControlFlags queryFlags;
        public QueryPipelineStatisticFlags pipelineStatistics;
    }
}
