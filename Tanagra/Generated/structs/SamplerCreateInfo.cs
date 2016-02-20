using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SamplerCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public SamplerCreateFlags flags;
        public Filter magFilter;
        public Filter minFilter;
        public SamplerMipmapMode mipmapMode;
        public SamplerAddressMode addressModeU;
        public SamplerAddressMode addressModeV;
        public SamplerAddressMode addressModeW;
        public Single mipLodBias;
        public Boolean anisotropyEnable;
        public Single maxAnisotropy;
        public Boolean compareEnable;
        public CompareOp compareOp;
        public Single minLod;
        public Single maxLod;
        public BorderColor borderColor;
        public Boolean unnormalizedCoordinates;
    }
}
