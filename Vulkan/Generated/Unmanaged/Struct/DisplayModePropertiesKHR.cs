using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayModePropertiesKHR
    {
        /// <summary>
        /// Handle of this display mode.
        /// </summary>
        public UInt64 DisplayMode;
        /// <summary>
        /// The parameters this mode uses.
        /// </summary>
        public DisplayModeParametersKHR Parameters;
    }
}
