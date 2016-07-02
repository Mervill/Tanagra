using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CommandBufferInheritanceInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_COMMAND_BUFFER_INHERITANCE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Render pass for secondary command buffers (Optional)
        /// </summary>
        public UInt64 RenderPass;
        public UInt32 Subpass;
        /// <summary>
        /// Framebuffer for secondary command buffers (Optional)
        /// </summary>
        public UInt64 Framebuffer;
        /// <summary>
        /// Whether this secondary command buffer may be executed during an occlusion query
        /// </summary>
        public Bool32 OcclusionQueryEnable;
        /// <summary>
        /// Query flags used by this secondary command buffer, if executed during an occlusion query (Optional)
        /// </summary>
        public QueryControlFlags QueryFlags;
        /// <summary>
        /// Pipeline statistics that may be counted for this secondary command buffer (Optional)
        /// </summary>
        public QueryPipelineStatisticFlags PipelineStatistics;
    }
}
