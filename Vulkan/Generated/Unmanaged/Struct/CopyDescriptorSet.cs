using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CopyDescriptorSet
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_COPY_DESCRIPTOR_SET
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Source descriptor set
        /// </summary>
        public UInt64 SrcSet;
        /// <summary>
        /// Binding within the source descriptor set to copy from
        /// </summary>
        public UInt32 SrcBinding;
        /// <summary>
        /// Array element within the source binding to copy from
        /// </summary>
        public UInt32 SrcArrayElement;
        /// <summary>
        /// Destination descriptor set
        /// </summary>
        public UInt64 DstSet;
        /// <summary>
        /// Binding within the destination descriptor set to copy to
        /// </summary>
        public UInt32 DstBinding;
        /// <summary>
        /// Array element within the destination binding to copy to
        /// </summary>
        public UInt32 DstArrayElement;
        /// <summary>
        /// Number of descriptors to write (determines the size of the array pointed by pDescriptors)
        /// </summary>
        public UInt32 DescriptorCount;
    }
}
