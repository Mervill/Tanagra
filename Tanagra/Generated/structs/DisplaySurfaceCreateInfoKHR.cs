using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplaySurfaceCreateInfoKHR
    {
        public StructureType sType;
        public IntPtr pNext;
        public DisplaySurfaceCreateFlagsKHR flags;
        public DisplayModeKHR displayMode;
        public UInt32 planeIndex;
        public UInt32 planeStackIndex;
        public SurfaceTransformFlagBitsKHR transform;
        public Single globalAlpha;
        public DisplayPlaneAlphaFlagBitsKHR alphaMode;
        public Extent2D imageExtent;
    }
}
