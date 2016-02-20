using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayModeParametersKHR
    {
        public Extent2D visibleRegion;
        public UInt32 refreshRate;
    }
}
