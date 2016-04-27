using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SubpassDescription
    {
        internal Interop.SubpassDescription* NativeHandle;
        
        public SubpassDescriptionFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public PipelineBindPoint PipelineBindPoint
        {
            get { return NativeHandle->PipelineBindPoint; }
            set { NativeHandle->PipelineBindPoint = value; }
        }
        
        public UInt32 InputAttachmentCount
        {
            get { return NativeHandle->InputAttachmentCount; }
            set { NativeHandle->InputAttachmentCount = value; }
        }
        
        AttachmentReference _InputAttachments;
        public AttachmentReference InputAttachments
        {
            get { return _InputAttachments; }
            set { _InputAttachments = value; NativeHandle->InputAttachments = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 ColorAttachmentCount
        {
            get { return NativeHandle->ColorAttachmentCount; }
            set { NativeHandle->ColorAttachmentCount = value; }
        }
        
        AttachmentReference _ColorAttachments;
        public AttachmentReference ColorAttachments
        {
            get { return _ColorAttachments; }
            set { _ColorAttachments = value; NativeHandle->ColorAttachments = (IntPtr)value.NativeHandle; }
        }
        
        AttachmentReference _ResolveAttachments;
        public AttachmentReference ResolveAttachments
        {
            get { return _ResolveAttachments; }
            set { _ResolveAttachments = value; NativeHandle->ResolveAttachments = (IntPtr)value.NativeHandle; }
        }
        
        AttachmentReference _DepthStencilAttachment;
        public AttachmentReference DepthStencilAttachment
        {
            get { return _DepthStencilAttachment; }
            set { _DepthStencilAttachment = value; NativeHandle->DepthStencilAttachment = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 PreserveAttachmentCount
        {
            get { return NativeHandle->PreserveAttachmentCount; }
            set { NativeHandle->PreserveAttachmentCount = value; }
        }
        
        public UInt32 PreserveAttachments
        {
            get { return NativeHandle->PreserveAttachments; }
            set { NativeHandle->PreserveAttachments = value; }
        }
        
        public SubpassDescription()
        {
            NativeHandle = (Interop.SubpassDescription*)Interop.Structure.Allocate(typeof(Interop.SubpassDescription));
        }
    }
}
