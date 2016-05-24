using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vulkan;

namespace Tanagra
{
    public class Texture
    {
        Sampler sampler;
        Image image;
        ImageLayout imageLayout;
        DeviceMemory deviceMemory;
        ImageView view;
        public uint Width { get; private set; }
        public uint Height { get; private set; }
        public uint MipLevels { get; private set; }
        public uint LayerCount { get; private set; }
    }
}
