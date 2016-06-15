using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayPresentInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DISPLAY_PRESENT_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Rectangle within the presentable image to read pixel data from when presenting to the display.
        /// </summary>
        public Rect2D SrcRect;
        /// <summary>
        /// Rectangle within the current display mode's visible region to display srcRectangle in.
        /// </summary>
        public Rect2D DstRect;
        /// <summary>
        /// For smart displays, use buffered mode. If the display properties member "persistentMode" is VK_FALSE, this member must always be VK_FALSE.
        /// </summary>
        public Bool32 Persistent;
    }
}
