using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct XcbSurfaceCreateInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_XCB_SURFACE_CREATE_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public XcbSurfaceCreateFlagsKHR Flags;
        public IntPtr Connection;
        public IntPtr Window;
    }
}
