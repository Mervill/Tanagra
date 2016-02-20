using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineMultisampleStateCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public PipelineMultisampleStateCreateFlags flags;
        public SampleCountFlags rasterizationSamples;
        public Boolean sampleShadingEnable;
        public Single minSampleShading;
        public SampleMask pSampleMask;
        public Boolean alphaToCoverageEnable;
        public Boolean alphaToOneEnable;
    }
}
