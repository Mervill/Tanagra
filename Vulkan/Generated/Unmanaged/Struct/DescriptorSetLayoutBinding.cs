using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DescriptorSetLayoutBinding
    {
        /// <summary>
        /// Binding number for this entry
        /// </summary>
        public UInt32 Binding;
        /// <summary>
        /// Type of the descriptors in this binding
        /// </summary>
        public DescriptorType DescriptorType;
        /// <summary>
        /// Number of descriptors in this binding (Optional)
        /// </summary>
        public UInt32 DescriptorCount;
        /// <summary>
        /// Shader stages this binding is visible to
        /// </summary>
        public ShaderStageFlags StageFlags;
        /// <summary>
        /// Immutable samplers (used if descriptor type is SAMPLER or COMBINED_IMAGE_SAMPLER, is either NULL or contains count number of elements) (Optional)
        /// </summary>
        public IntPtr ImmutableSamplers;
    }
}
