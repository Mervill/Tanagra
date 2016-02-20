using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AttachmentReference
    {
        public UInt32 attachment;
        public ImageLayout layout;
    }
}
