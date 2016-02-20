using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DescriptorImageInfo
    {
        public Sampler sampler;
        public ImageView imageView;
        public ImageLayout imageLayout;
    }
}
