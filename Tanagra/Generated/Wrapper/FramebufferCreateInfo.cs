using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class FramebufferCreateInfo
    {
        internal Interop.FramebufferCreateInfo* NativeHandle;
        
        public FramebufferCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        RenderPass _RenderPass;
        public RenderPass RenderPass
        {
            get { return _RenderPass; }
            set { _RenderPass = value; NativeHandle->RenderPass = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 AttachmentCount
        {
            get { return NativeHandle->AttachmentCount; }
            set { NativeHandle->AttachmentCount = value; }
        }
        
        ImageView _Attachments;
        public ImageView Attachments
        {
            get { return _Attachments; }
            set { _Attachments = value; NativeHandle->Attachments = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 Width
        {
            get { return NativeHandle->Width; }
            set { NativeHandle->Width = value; }
        }
        
        public UInt32 Height
        {
            get { return NativeHandle->Height; }
            set { NativeHandle->Height = value; }
        }
        
        public UInt32 Layers
        {
            get { return NativeHandle->Layers; }
            set { NativeHandle->Layers = value; }
        }
        
        public FramebufferCreateInfo()
        {
            NativeHandle = (Interop.FramebufferCreateInfo*)Interop.Structure.Allocate(typeof(Interop.FramebufferCreateInfo));
            //NativeHandle->SType = StructureType.FramebufferCreateInfo;
        }
    }
}
