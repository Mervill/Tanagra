using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DescriptorPoolCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        public DescriptorPoolCreateFlags Flags;
        public UInt32 MaxSets;
        public UInt32 PoolSizeCount;
        public IntPtr PoolSizes;
    }
}
