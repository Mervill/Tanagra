using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayModePropertiesKHR
    {
        public DisplayModeKHR displayMode;
        public DisplayModeParametersKHR parameters;
    }
}
