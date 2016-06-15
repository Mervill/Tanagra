using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DescriptorImageInfo
    {
        /// <summary>
        /// Sampler to write to the descriptor in case it's a SAMPLER or COMBINED_IMAGE_SAMPLER descriptor. Ignored otherwise.
        /// </summary>
        public UInt64 Sampler;
        /// <summary>
        /// Image view to write to the descriptor in case it's a SAMPLED_IMAGE, STORAGE_IMAGE, COMBINED_IMAGE_SAMPLER, or INPUT_ATTACHMENT descriptor. Ignored otherwise.
        /// </summary>
        public UInt64 ImageView;
        /// <summary>
        /// Layout the image is expected to be in when accessed using this descriptor (only used if imageView is not VK_NULL_HANDLE).
        /// </summary>
        public ImageLayout ImageLayout;
    }
}
