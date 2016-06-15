using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DebugReportCallbackCreateInfoEXT
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DEBUG_REPORT_CALLBACK_CREATE_INFO_EXT
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Indicates which events call this callback
        /// </summary>
        public DebugReportFlagsEXT Flags;
        /// <summary>
        /// Function pointer of a callback function
        /// </summary>
        public IntPtr Callback;
        /// <summary>
        /// User data provided to callback function (Optional)
        /// </summary>
        public IntPtr UserData;
    }
}
