using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class FramebufferCreateInfo
    {
        internal Interop.FramebufferCreateInfo* NativePointer;
        
        public FramebufferCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        RenderPass _RenderPass;
        public RenderPass RenderPass
        {
            get { return _RenderPass; }
            set { _RenderPass = value; NativePointer->RenderPass = value.NativePointer; }
        }
        
        public UInt32 AttachmentCount
        {
            get { return NativePointer->AttachmentCount; }
            set { NativePointer->AttachmentCount = value; }
        }
        
        ImageView _Attachments;
        public ImageView Attachments
        {
            get { return _Attachments; }
            set { _Attachments = value; NativePointer->Attachments = (UInt32)value.NativePointer; }
        }
        
        public UInt32 Width
        {
            get { return NativePointer->Width; }
            set { NativePointer->Width = value; }
        }
        
        public UInt32 Height
        {
            get { return NativePointer->Height; }
            set { NativePointer->Height = value; }
        }
        
        public UInt32 Layers
        {
            get { return NativePointer->Layers; }
            set { NativePointer->Layers = value; }
        }
        
        public FramebufferCreateInfo()
        {
            NativePointer = (Interop.FramebufferCreateInfo*)Interop.Structure.Allocate(typeof(Interop.FramebufferCreateInfo));
            NativePointer->SType = StructureType.FramebufferCreateInfo;
        }
    }
}
