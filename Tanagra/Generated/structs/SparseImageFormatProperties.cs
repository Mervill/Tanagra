using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SparseImageFormatProperties
    {
        public ImageAspectFlags aspectMask;
        public Extent3D imageGranularity;
        public SparseImageFormatFlags flags;
    }
}
