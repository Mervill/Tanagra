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
        
        public AttachmentReference[] InputAttachments
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        public UInt32 ColorAttachmentCount
        {
            get { return NativePointer->ColorAttachmentCount; }
            set { NativePointer->ColorAttachmentCount = value; }
        }
        
        public AttachmentReference[] ColorAttachments
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        public AttachmentReference[] ResolveAttachments
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        AttachmentReference _DepthStencilAttachment;
        public AttachmentReference DepthStencilAttachment
        {
            get { return _DepthStencilAttachment; }
            set { _DepthStencilAttachment = value; NativePointer->DepthStencilAttachment = (IntPtr)(&value); }
        }
        
        public UInt32 PreserveAttachmentCount
        {
            get { return NativePointer->PreserveAttachmentCount; }
            set { NativePointer->PreserveAttachmentCount = value; }
        }
        
        public UInt32[] PreserveAttachments
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        public SubpassDescription()
        {
            NativePointer = (Interop.SubpassDescription*)Interop.Structure.Allocate(typeof(Interop.SubpassDescription));
        }
    }
}
