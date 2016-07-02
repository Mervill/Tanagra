using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineColorBlendAttachmentState
    {
        public Bool32 BlendEnable;
        public BlendFactor SrcColorBlendFactor;
        public BlendFactor DstColorBlendFactor;
        public BlendOp ColorBlendOp;
        public BlendFactor SrcAlphaBlendFactor;
        public BlendFactor DstAlphaBlendFactor;
        public BlendOp AlphaBlendOp;
        public ColorComponentFlags ColorWriteMask;
        
        public PipelineColorBlendAttachmentState(Bool32 BlendEnable, BlendFactor SrcColorBlendFactor, BlendFactor DstColorBlendFactor, BlendOp ColorBlendOp, BlendFactor SrcAlphaBlendFactor, BlendFactor DstAlphaBlendFactor, BlendOp AlphaBlendOp)
        {
            this.BlendEnable = BlendEnable;
            this.SrcColorBlendFactor = SrcColorBlendFactor;
            this.DstColorBlendFactor = DstColorBlendFactor;
            this.ColorBlendOp = ColorBlendOp;
            this.SrcAlphaBlendFactor = SrcAlphaBlendFactor;
            this.DstAlphaBlendFactor = DstAlphaBlendFactor;
            this.AlphaBlendOp = AlphaBlendOp;
            ColorWriteMask = default(ColorComponentFlags);
        }
    }
}
