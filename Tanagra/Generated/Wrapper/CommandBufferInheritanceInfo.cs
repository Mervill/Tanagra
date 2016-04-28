using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CommandBufferInheritanceInfo
    {
        internal Interop.CommandBufferInheritanceInfo* NativePointer;
        
        RenderPass _RenderPass;
        public RenderPass RenderPass
        {
            get { return _RenderPass; }
            set { _RenderPass = value; NativePointer->RenderPass = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 Subpass
        {
            get { return NativePointer->Subpass; }
            set { NativePointer->Subpass = value; }
        }
        
        Framebuffer _Framebuffer;
        public Framebuffer Framebuffer
        {
            get { return _Framebuffer; }
            set { _Framebuffer = value; NativePointer->Framebuffer = (IntPtr)value.NativePointer; }
        }
        
        public Boolean OcclusionQueryEnable
        {
            get { return NativePointer->OcclusionQueryEnable; }
            set { NativePointer->OcclusionQueryEnable = value; }
        }
        
        public QueryControlFlags QueryFlags
        {
            get { return NativePointer->QueryFlags; }
            set { NativePointer->QueryFlags = value; }
        }
        
        public QueryPipelineStatisticFlags PipelineStatistics
        {
            get { return NativePointer->PipelineStatistics; }
            set { NativePointer->PipelineStatistics = value; }
        }
        
        public CommandBufferInheritanceInfo()
        {
            NativePointer = (Interop.CommandBufferInheritanceInfo*)Interop.Structure.Allocate(typeof(Interop.CommandBufferInheritanceInfo));
            //NativePointer->SType = StructureType.CommandBufferInheritanceInfo;
        }
    }
}
