using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineRasterizationStateCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public PipelineRasterizationStateCreateFlags flags;
        public Boolean depthClampEnable;
        public Boolean rasterizerDiscardEnable;
        public PolygonMode polygonMode;
        public CullModeFlags cullMode;
        public FrontFace frontFace;
        public Boolean depthBiasEnable;
        public Single depthBiasConstantFactor;
        public Single depthBiasClamp;
        public Single depthBiasSlopeFactor;
        public Single lineWidth;
    }
}
