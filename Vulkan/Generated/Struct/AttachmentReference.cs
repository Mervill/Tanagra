using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AttachmentReference
    {
        public UInt32 Attachment;
        public ImageLayout Layout;
        
        public AttachmentReference(UInt32 Attachment, ImageLayout Layout)
        {
            this.Attachment = Attachment;
            this.Layout = Layout;
        }
    }
}
