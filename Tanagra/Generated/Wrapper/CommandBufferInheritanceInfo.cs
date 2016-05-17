using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CommandBufferInheritanceInfo
    {
        internal Interop.CommandBufferInheritanceInfo* NativePointer;
        
        RenderPass _RenderPass;
        /// <summary>
        /// Render pass for secondary command buffers (Optional)
        /// </summary>
        public RenderPass RenderPass
        {
            get { return _RenderPass; }
            set { _RenderPass = value; NativePointer->RenderPass = value.NativePointer; }
        }
        
        public UInt32 Subpass
        {
            get { return NativePointer->Subpass; }
            set { NativePointer->Subpass = value; }
        }
        
        Framebuffer _Framebuffer;
        /// <summary>
        /// Framebuffer for secondary command buffers (Optional)
        /// </summary>
        public Framebuffer Framebuffer
        {
            get { return _Framebuffer; }
            set { _Framebuffer = value; NativePointer->Framebuffer = value.NativePointer; }
        }
        
        /// <summary>
        /// Whether this secondary command buffer may be executed during an occlusion query
        /// </summary>
        public Bool32 OcclusionQueryEnable
        {
            get { return NativePointer->OcclusionQueryEnable; }
            set { NativePointer->OcclusionQueryEnable = value; }
        }
        
        /// <summary>
        /// Query flags used by this secondary command buffer, if executed during an occlusion query (Optional)
        /// </summary>
        public QueryControlFlags QueryFlags
        {
            get { return NativePointer->QueryFlags; }
            set { NativePointer->QueryFlags = value; }
        }
        
        /// <summary>
        /// Pipeline statistics that may be counted for this secondary command buffer (Optional)
        /// </summary>
        public QueryPipelineStatisticFlags PipelineStatistics
        {
            get { return NativePointer->PipelineStatistics; }
            set { NativePointer->PipelineStatistics = value; }
        }
        
        public CommandBufferInheritanceInfo()
        {
            NativePointer = (Interop.CommandBufferInheritanceInfo*)Interop.Structure.Allocate(typeof(Interop.CommandBufferInheritanceInfo));
            NativePointer->SType = StructureType.CommandBufferInheritanceInfo;
        }
        
        public CommandBufferInheritanceInfo(UInt32 Subpass, Bool32 OcclusionQueryEnable) : this()
        {
            this.Subpass = Subpass;
            this.OcclusionQueryEnable = OcclusionQueryEnable;
        }
    }
}
