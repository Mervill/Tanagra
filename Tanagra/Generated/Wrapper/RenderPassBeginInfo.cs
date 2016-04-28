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
        
        Rect2D _RenderArea;
        public Rect2D RenderArea
        {
            get { return _RenderArea; }
            set { _RenderArea = value; NativePointer->RenderArea = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 ClearValueCount
        {
            get { return NativePointer->ClearValueCount; }
            set { NativePointer->ClearValueCount = value; }
        }
        
        ClearValue _ClearValues;
        public ClearValue ClearValues
        {
            get { return _ClearValues; }
            set { _ClearValues = value; NativePointer->ClearValues = (IntPtr)value.NativePointer; }
        }
        
        public RenderPassBeginInfo()
        {
            NativePointer = (Interop.RenderPassBeginInfo*)Interop.Structure.Allocate(typeof(Interop.RenderPassBeginInfo));
            //NativePointer->SType = StructureType.RenderPassBeginInfo;
        }
    }
}
