using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DebugMarkerMarkerInfoEXT
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct ColorInfo
        {
            public Single R;
            public Single G;
            public Single B;
            public Single A;
        }
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DEBUG_MARKER_MARKER_INFO_EXT
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Name of the debug marker
        /// </summary>
        public IntPtr MarkerName;
        /// <summary>
        /// Optional color for debug marker (Optional)
        /// </summary>
        public ColorInfo Color;
    }
}
