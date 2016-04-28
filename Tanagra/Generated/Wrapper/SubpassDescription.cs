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
        
        AttachmentReference _InputAttachments;
        public AttachmentReference InputAttachments
        {
            get { return _InputAttachments; }
            set { _InputAttachments = value; NativePointer->InputAttachments = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 ColorAttachmentCount
        {
            get { return NativePointer->ColorAttachmentCount; }
            set { NativePointer->ColorAttachmentCount = value; }
        }
        
        AttachmentReference _ColorAttachments;
        public AttachmentReference ColorAttachments
        {
            get { return _ColorAttachments; }
            set { _ColorAttachments = value; NativePointer->ColorAttachments = (IntPtr)value.NativePointer; }
        }
        
        AttachmentReference _ResolveAttachments;
        public AttachmentReference ResolveAttachments
        {
            get { return _ResolveAttachments; }
            set { _ResolveAttachments = value; NativePointer->ResolveAttachments = (IntPtr)value.NativePointer; }
        }
        
        AttachmentReference _DepthStencilAttachment;
        public AttachmentReference DepthStencilAttachment
        {
            get { return _DepthStencilAttachment; }
            set { _DepthStencilAttachment = value; NativePointer->DepthStencilAttachment = (IntPtr)value.NativePointer; }
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
