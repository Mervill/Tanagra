using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineColorBlendAttachmentState
    {
        public Boolean blendEnable;
        public BlendFactor srcColorBlendFactor;
        public BlendFactor dstColorBlendFactor;
        public BlendOp colorBlendOp;
        public BlendFactor srcAlphaBlendFactor;
        public BlendFactor dstAlphaBlendFactor;
        public BlendOp alphaBlendOp;
        public ColorComponentFlags colorWriteMask;
    }
}
