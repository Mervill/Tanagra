using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MirSurfaceCreateInfoKHR
    {
        public StructureType sType;
        public IntPtr Next;
        public MirSurfaceCreateFlagsKHR flags;
        public MirConnection connection;
        public MirSurface mirSurface;
    }
}
