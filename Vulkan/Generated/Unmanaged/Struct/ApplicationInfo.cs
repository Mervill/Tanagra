using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ApplicationInfo
    {
        /// <summary>
        /// Type of structure. Should be VK_STRUCTURE_TYPE_APPLICATION_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        public IntPtr ApplicationName;
        public UInt32 ApplicationVersion;
        public IntPtr EngineName;
        public UInt32 EngineVersion;
        public UInt32 ApiVersion;
    }
}
