using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DescriptorSetLayoutCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public DescriptorSetLayoutCreateFlags Flags;
        /// <summary>
        /// Number of bindings in the descriptor set layout (Optional)
        /// </summary>
        public UInt32 BindingCount;
        /// <summary>
        /// Array of descriptor set layout bindings
        /// </summary>
        public IntPtr Bindings;
    }
}
