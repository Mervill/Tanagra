using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayPlanePropertiesKHR
    {
        /// <summary>
        /// Display the plane is currently associated with. Will be VK_NULL_HANDLE if the plane is not in use.
        /// </summary>
        public UInt64 CurrentDisplay;
        /// <summary>
        /// Current z-order of the plane.
        /// </summary>
        public UInt32 CurrentStackIndex;
    }
}
