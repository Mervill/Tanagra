using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// IExtensible
    /// </summary>
    unsafe public class CommandBufferInheritanceInfo : IDisposable
    {
        internal Unmanaged.CommandBufferInheritanceInfo* NativePointer { get; private set; }
        
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
            NativePointer = (Unmanaged.CommandBufferInheritanceInfo*)MemUtil.Alloc(typeof(Unmanaged.CommandBufferInheritanceInfo));
            NativePointer->SType = StructureType.CommandBufferInheritanceInfo;
        }
        
        internal CommandBufferInheritanceInfo(Unmanaged.CommandBufferInheritanceInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.CommandBufferInheritanceInfo));
        }
        
        /// <param name="OcclusionQueryEnable">Whether this secondary command buffer may be executed during an occlusion query</param>
        public CommandBufferInheritanceInfo(UInt32 Subpass, Bool32 OcclusionQueryEnable) : this()
        {
            this.Subpass = Subpass;
            this.OcclusionQueryEnable = OcclusionQueryEnable;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~CommandBufferInheritanceInfo()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
