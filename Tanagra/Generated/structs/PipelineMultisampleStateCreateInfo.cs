using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineMultisampleStateCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public PipelineMultisampleStateCreateFlags flags;
        public SampleCountFlags rasterizationSamples;
        public Boolean sampleShadingEnable;
        public Single minSampleShading;
        public SampleMask[] SampleMask; // len:latexmath:[$\lceil{\mathit{rasterizationSamples} \over 32}\rceil$]
        public Boolean alphaToCoverageEnable;
        public Boolean alphaToOneEnable;
    }
}
