using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineMultisampleStateCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_MULTISAMPLE_STATE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineMultisampleStateCreateFlags Flags;
        /// <summary>
        /// Number of samples used for rasterization
        /// </summary>
        public SampleCountFlags RasterizationSamples;
        /// <summary>
        /// Optional (GL45)
        /// </summary>
        public Bool32 SampleShadingEnable;
        /// <summary>
        /// Optional (GL45)
        /// </summary>
        public Single MinSampleShading;
        /// <summary>
        /// Array of sampleMask words (Optional)
        /// </summary>
        public IntPtr SampleMask;
        public Bool32 AlphaToCoverageEnable;
        public Bool32 AlphaToOneEnable;
    }
}
