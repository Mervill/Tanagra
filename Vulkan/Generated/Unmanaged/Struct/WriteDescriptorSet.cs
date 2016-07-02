using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WriteDescriptorSet
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Destination descriptor set
        /// </summary>
        public UInt64 DstSet;
        /// <summary>
        /// Binding within the destination descriptor set to write
        /// </summary>
        public UInt32 DstBinding;
        /// <summary>
        /// Array element within the destination binding to write
        /// </summary>
        public UInt32 DstArrayElement;
        /// <summary>
        /// Number of descriptors to write (determines the size of the array pointed by pDescriptors)
        /// </summary>
        public UInt32 DescriptorCount;
        /// <summary>
        /// Descriptor type to write (determines which members of the array pointed by pDescriptors are going to be used)
        /// </summary>
        public DescriptorType DescriptorType;
        /// <summary>
        /// Sampler, image view, and layout for SAMPLER, COMBINED_IMAGE_SAMPLER, {SAMPLED,STORAGE}_IMAGE, and INPUT_ATTACHMENT descriptor types.
        /// </summary>
        public IntPtr ImageInfo;
        /// <summary>
        /// Raw buffer, size, and offset for {UNIFORM,STORAGE}_BUFFER[_DYNAMIC] descriptor types.
        /// </summary>
        public IntPtr BufferInfo;
        /// <summary>
        /// Buffer view to write to the descriptor for {UNIFORM,STORAGE}_TEXEL_BUFFER descriptor types.
        /// </summary>
        public IntPtr TexelBufferView;
    }
}
