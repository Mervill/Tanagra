using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DebugMarkerObjectTagInfoEXT
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DEBUG_MARKER_OBJECT_TAG_INFO_EXT
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// The type of the object
        /// </summary>
        public DebugReportObjectTypeEXT ObjectType;
        /// <summary>
        /// The handle of the object, cast to uint64_t
        /// </summary>
        public UInt64 Object;
        /// <summary>
        /// The name of the tag to set on the object
        /// </summary>
        public UInt64 TagName;
        /// <summary>
        /// The length in bytes of the tag data
        /// </summary>
        public UInt32 TagSize;
        /// <summary>
        /// Tag data to attach to the object
        /// </summary>
        public IntPtr Tag;
    }
}
