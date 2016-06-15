using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Win32SurfaceCreateInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_WIN32_SURFACE_CREATE_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public Win32SurfaceCreateFlagsKHR Flags;
        public IntPtr Hinstance;
        public IntPtr Hwnd;
    }
}
