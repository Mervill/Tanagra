using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ClearAttachment
    {
        public ImageAspectFlags AspectMask;
        public UInt32 ColorAttachment;
        public ClearValue ClearValue;
        
        public ClearAttachment(ImageAspectFlags AspectMask, UInt32 ColorAttachment, ClearValue ClearValue)
        {
            this.AspectMask = AspectMask;
            this.ColorAttachment = ColorAttachment;
            this.ClearValue = ClearValue;
        }
    }
}
