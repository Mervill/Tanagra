using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class AttachmentDescription
    {
        internal Interop.AttachmentDescription* NativeHandle;
        
        public AttachmentDescriptionFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public Format Format
        {
            get { return NativeHandle->Format; }
            set { NativeHandle->Format = value; }
        }
        
        public SampleCountFlags Samples
        {
            get { return NativeHandle->Samples; }
            set { NativeHandle->Samples = value; }
        }
        
        public AttachmentLoadOp LoadOp
        {
            get { return NativeHandle->LoadOp; }
            set { NativeHandle->LoadOp = value; }
        }
        
        public AttachmentStoreOp StoreOp
        {
            get { return NativeHandle->StoreOp; }
            set { NativeHandle->StoreOp = value; }
        }
        
        public AttachmentLoadOp StencilLoadOp
        {
            get { return NativeHandle->StencilLoadOp; }
            set { NativeHandle->StencilLoadOp = value; }
        }
        
        public AttachmentStoreOp StencilStoreOp
        {
            get { return NativeHandle->StencilStoreOp; }
            set { NativeHandle->StencilStoreOp = value; }
        }
        
        public ImageLayout InitialLayout
        {
            get { return NativeHandle->InitialLayout; }
            set { NativeHandle->InitialLayout = value; }
        }
        
        public ImageLayout FinalLayout
        {
            get { return NativeHandle->FinalLayout; }
            set { NativeHandle->FinalLayout = value; }
        }
        
        public AttachmentDescription()
        {
            NativeHandle = (Interop.AttachmentDescription*)Interop.Structure.Allocate(typeof(Interop.AttachmentDescription));
        }
    }
}
