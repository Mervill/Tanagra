using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CommandBufferInheritanceInfo
    {
        internal Interop.CommandBufferInheritanceInfo* NativeHandle;
        
        RenderPass _RenderPass;
        public RenderPass RenderPass
        {
            get { return _RenderPass; }
            set { _RenderPass = value; NativeHandle->RenderPass = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 Subpass
        {
            get { return NativeHandle->Subpass; }
            set { NativeHandle->Subpass = value; }
        }
        
        Framebuffer _Framebuffer;
        public Framebuffer Framebuffer
        {
            get { return _Framebuffer; }
            set { _Framebuffer = value; NativeHandle->Framebuffer = (IntPtr)value.NativeHandle; }
        }
        
        public Boolean OcclusionQueryEnable
        {
            get { return NativeHandle->OcclusionQueryEnable; }
            set { NativeHandle->OcclusionQueryEnable = value; }
        }
        
        public QueryControlFlags QueryFlags
        {
            get { return NativeHandle->QueryFlags; }
            set { NativeHandle->QueryFlags = value; }
        }
        
        public QueryPipelineStatisticFlags PipelineStatistics
        {
            get { return NativeHandle->PipelineStatistics; }
            set { NativeHandle->PipelineStatistics = value; }
        }
        
        public CommandBufferInheritanceInfo()
        {
            NativeHandle = (Interop.CommandBufferInheritanceInfo*)Interop.Structure.Allocate(typeof(Interop.CommandBufferInheritanceInfo));
            //NativeHandle->SType = StructureType.CommandBufferInheritanceInfo;
        }
    }
}
