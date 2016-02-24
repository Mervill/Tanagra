using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayPresentInfoKHR
    {
        public StructureType sType;
        public IntPtr Next;
        public Rect2D srcRect;
        public Rect2D dstRect;
        public Boolean persistent;
    }
}
