using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayModeCreateInfoKHR
    {
        public StructureType sType;
        public IntPtr Next;
        public DisplayModeCreateFlagsKHR flags;
        public DisplayModeParametersKHR parameters;
    }
}
