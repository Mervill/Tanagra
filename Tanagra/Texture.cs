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
        public Image Image { get; private set; }
        public ImageLayout ImageLayout { get; private set; }
        public DeviceMemory DeviceMemory { get; private set; }
        public Sampler Sampler { get; private set; }
        public ImageView View { get; private set; }
        public uint Width { get; private set; }
        public uint Height { get; private set; }
        public uint MipLevels { get; private set; }
        public uint LayerCount { get; private set; }
    }
}
