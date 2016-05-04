using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SubpassDescription
    {
        internal Interop.SubpassDescription* NativePointer;
        
        public SubpassDescriptionFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public PipelineBindPoint PipelineBindPoint
        {
            get { return NativePointer->PipelineBindPoint; }
            set { NativePointer->PipelineBindPoint = value; }
        }
        
        public UInt32 InputAttachmentCount
        {
            get { return NativePointer->InputAttachmentCount; }
            set { NativePointer->InputAttachmentCount = value; }
        }
        
        public AttachmentReference InputAttachments
        {
            get { return NativePointer->InputAttachments; }
            set { NativePointer->InputAttachments = value; }
        }
        
        public UInt32 ColorAttachmentCount
        {
            get { return NativePointer->ColorAttachmentCount; }
            set { NativePointer->ColorAttachmentCount = value; }
        }
        
        public AttachmentReference ColorAttachments
        {
            get { return NativePointer->ColorAttachments; }
            set { NativePointer->ColorAttachments = value; }
        }
        
        public AttachmentReference ResolveAttachments
        {
            get { return NativePointer->ResolveAttachments; }
            set { NativePointer->ResolveAttachments = value; }
        }
        
        public AttachmentReference DepthStencilAttachment
        {
            get { return NativePointer->DepthStencilAttachment; }
            set { NativePointer->DepthStencilAttachment = value; }
        }
        
        public UInt32 PreserveAttachmentCount
        {
            get { return NativePointer->PreserveAttachmentCount; }
            set { NativePointer->PreserveAttachmentCount = value; }
        }
        
        public UInt32 PreserveAttachments
        {
            get { return NativePointer->PreserveAttachments; }
            set { NativePointer->PreserveAttachments = value; }
        }
        
        public SubpassDescription()
        {
            NativePointer = (Interop.SubpassDescription*)Interop.Structure.Allocate(typeof(Interop.SubpassDescription));
        }
    }
}
