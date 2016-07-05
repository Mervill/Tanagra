using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineCacheCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_CACHE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineCacheCreateFlags Flags;
        /// <summary>
        /// Size of initial data to populate cache, in bytes (Optional)
        /// </summary>
        public IntPtr InitialDataSize;
        /// <summary>
        /// Initial data to populate cache
        /// </summary>
        public IntPtr InitialData;
    }
}
