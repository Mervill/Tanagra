using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class AttachmentReference
    {
        internal Interop.AttachmentReference* NativePointer;
        
        public UInt32 Attachment
        {
            get { return NativePointer->Attachment; }
            set { NativePointer->Attachment = value; }
        }
        
        public ImageLayout Layout
        {
            get { return NativePointer->Layout; }
            set { NativePointer->Layout = value; }
        }
        
        public AttachmentReference()
        {
            NativePointer = (Interop.AttachmentReference*)Interop.Structure.Allocate(typeof(Interop.AttachmentReference));
        }
    }
}
