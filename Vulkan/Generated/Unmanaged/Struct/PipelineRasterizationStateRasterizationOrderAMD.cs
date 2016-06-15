using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineRasterizationStateRasterizationOrderAMD
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_RASTERIZATION_ORDER_AMD
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Rasterization order to use for the pipeline
        /// </summary>
        public RasterizationOrderAMD RasterizationOrder;
    }
}
