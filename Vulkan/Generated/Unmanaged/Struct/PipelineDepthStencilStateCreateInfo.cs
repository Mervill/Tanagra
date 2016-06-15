using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineDepthStencilStateCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_DEPTH_STENCIL_STATE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineDepthStencilStateCreateFlags Flags;
        public Bool32 DepthTestEnable;
        public Bool32 DepthWriteEnable;
        public CompareOp DepthCompareOp;
        /// <summary>
        /// Optional (depth_bounds_test)
        /// </summary>
        public Bool32 DepthBoundsTestEnable;
        public Bool32 StencilTestEnable;
        public StencilOpState Front;
        public StencilOpState Back;
        public Single MinDepthBounds;
        public Single MaxDepthBounds;
    }
}
