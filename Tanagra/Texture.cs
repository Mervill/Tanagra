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
        public Sampler sampler;
        public Image image;
        public ImageLayout imageLayout;
        public DeviceMemory deviceMemory;
        public ImageView view;
        public uint Width { get; private set; }
        public uint Height { get; private set; }
        public uint MipLevels { get; private set; }
        public uint LayerCount { get; private set; }
    }
}
