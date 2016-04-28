using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class AttachmentDescription
    {
        internal Interop.AttachmentDescription* NativePointer;
        
        public AttachmentDescriptionFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public Format Format
        {
            get { return NativePointer->Format; }
            set { NativePointer->Format = value; }
        }
        
        public SampleCountFlags Samples
        {
            get { return NativePointer->Samples; }
            set { NativePointer->Samples = value; }
        }
        
        public AttachmentLoadOp LoadOp
        {
            get { return NativePointer->LoadOp; }
            set { NativePointer->LoadOp = value; }
        }
        
        public AttachmentStoreOp StoreOp
        {
            get { return NativePointer->StoreOp; }
            set { NativePointer->StoreOp = value; }
        }
        
        public AttachmentLoadOp StencilLoadOp
        {
            get { return NativePointer->StencilLoadOp; }
            set { NativePointer->StencilLoadOp = value; }
        }
        
        public AttachmentStoreOp StencilStoreOp
        {
            get { return NativePointer->StencilStoreOp; }
            set { NativePointer->StencilStoreOp = value; }
        }
        
        public ImageLayout InitialLayout
        {
            get { return NativePointer->InitialLayout; }
            set { NativePointer->InitialLayout = value; }
        }
        
        public ImageLayout FinalLayout
        {
            get { return NativePointer->FinalLayout; }
            set { NativePointer->FinalLayout = value; }
        }
        
        public AttachmentDescription()
        {
            NativePointer = (Interop.AttachmentDescription*)Interop.Structure.Allocate(typeof(Interop.AttachmentDescription));
        }
    }
}
