using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DescriptorSetAllocateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        public UInt64 DescriptorPool;
        public UInt32 DescriptorSetCount;
        public IntPtr SetLayouts;
    }
}
