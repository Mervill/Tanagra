using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayModeCreateInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DISPLAY_MODE_CREATE_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public DisplayModeCreateFlagsKHR Flags;
        /// <summary>
        /// The parameters this mode uses.
        /// </summary>
        public DisplayModeParametersKHR Parameters;
    }
}
