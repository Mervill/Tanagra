using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DedicatedAllocationImageCreateInfoNV
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DEDICATED_ALLOCATION_IMAGE_CREATE_INFO_NV
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Whether this image uses a dedicated allocation
        /// </summary>
        public Bool32 DedicatedAllocation;
    }
}
