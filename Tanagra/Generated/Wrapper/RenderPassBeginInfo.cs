using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class RenderPassBeginInfo
    {
        internal Interop.RenderPassBeginInfo* NativePointer;
        
        RenderPass _RenderPass;
        public RenderPass RenderPass
        {
            get { return _RenderPass; }
            set { _RenderPass = value; NativePointer->RenderPass = (IntPtr)value.NativePointer; }
        }
        
        Framebuffer _Framebuffer;
        public Framebuffer Framebuffer
        {
            get { return _Framebuffer; }
            set { _Framebuffer = value; NativePointer->Framebuffer = (IntPtr)value.NativePointer; }
        }
        
        public Rect2D RenderArea
        {
            get { return NativePointer->RenderArea; }
            set { NativePointer->RenderArea = value; }
        }
        
        public UInt32 ClearValueCount
        {
            get { return NativePointer->ClearValueCount; }
            set { NativePointer->ClearValueCount = value; }
        }
        
        public ClearValue ClearValues
        {
            get { return NativePointer->ClearValues; }
            set { NativePointer->ClearValues = value; }
        }
        
        public RenderPassBeginInfo()
        {
            NativePointer = (Interop.RenderPassBeginInfo*)Interop.Structure.Allocate(typeof(Interop.RenderPassBeginInfo));
            NativePointer->SType = StructureType.RenderPassBeginInfo;
        }
    }
}
