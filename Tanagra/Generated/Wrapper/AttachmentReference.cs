using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class AttachmentReference
    {
        internal Interop.AttachmentReference* NativeHandle;
        
        public UInt32 Attachment
        {
            get { return NativeHandle->Attachment; }
            set { NativeHandle->Attachment = value; }
        }
        
        public ImageLayout Layout
        {
            get { return NativeHandle->Layout; }
            set { NativeHandle->Layout = value; }
        }
        
        public AttachmentReference()
        {
            NativeHandle = (Interop.AttachmentReference*)Interop.Structure.Allocate(typeof(Interop.AttachmentReference));
        }
    }
}
