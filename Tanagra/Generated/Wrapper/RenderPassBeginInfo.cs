using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class RenderPassBeginInfo
    {
        internal Interop.RenderPassBeginInfo* NativeHandle;
        
        RenderPass _RenderPass;
        public RenderPass RenderPass
        {
            get { return _RenderPass; }
            set { _RenderPass = value; NativeHandle->RenderPass = (IntPtr)value.NativeHandle; }
        }
        
        Framebuffer _Framebuffer;
        public Framebuffer Framebuffer
        {
            get { return _Framebuffer; }
            set { _Framebuffer = value; NativeHandle->Framebuffer = (IntPtr)value.NativeHandle; }
        }
        
        Rect2D _RenderArea;
        public Rect2D RenderArea
        {
            get { return _RenderArea; }
            set { _RenderArea = value; NativeHandle->RenderArea = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 ClearValueCount
        {
            get { return NativeHandle->ClearValueCount; }
            set { NativeHandle->ClearValueCount = value; }
        }
        
        ClearValue _ClearValues;
        public ClearValue ClearValues
        {
            get { return _ClearValues; }
            set { _ClearValues = value; NativeHandle->ClearValues = (IntPtr)value.NativeHandle; }
        }
        
        public RenderPassBeginInfo()
        {
            NativeHandle = (Interop.RenderPassBeginInfo*)Interop.Structure.Allocate(typeof(Interop.RenderPassBeginInfo));
            //NativeHandle->SType = StructureType.RenderPassBeginInfo;
        }
    }
}
