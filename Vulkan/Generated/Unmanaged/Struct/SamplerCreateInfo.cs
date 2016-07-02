using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SamplerCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_SAMPLER_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public SamplerCreateFlags Flags;
        /// <summary>
        /// Filter mode for magnification
        /// </summary>
        public Filter MagFilter;
        /// <summary>
        /// Filter mode for minifiation
        /// </summary>
        public Filter MinFilter;
        /// <summary>
        /// Mipmap selection mode
        /// </summary>
        public SamplerMipmapMode MipmapMode;
        public SamplerAddressMode AddressModeU;
        public SamplerAddressMode AddressModeV;
        public SamplerAddressMode AddressModeW;
        public Single MipLodBias;
        public Bool32 AnisotropyEnable;
        public Single MaxAnisotropy;
        public Bool32 CompareEnable;
        public CompareOp CompareOp;
        public Single MinLod;
        public Single MaxLod;
        public BorderColor BorderColor;
        public Bool32 UnnormalizedCoordinates;
    }
}
