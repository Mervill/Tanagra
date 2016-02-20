using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineDepthStencilStateCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public PipelineDepthStencilStateCreateFlags flags;
        public Boolean depthTestEnable;
        public Boolean depthWriteEnable;
        public CompareOp depthCompareOp;
        public Boolean depthBoundsTestEnable;
        public Boolean stencilTestEnable;
        public StencilOpState front;
        public StencilOpState back;
        public Single minDepthBounds;
        public Single maxDepthBounds;
    }
}
