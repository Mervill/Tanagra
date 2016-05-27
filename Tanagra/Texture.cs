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
        public Image Image { get; set; }
        public ImageLayout ImageLayout { get; set; }
        public DeviceMemory DeviceMemory { get; set; }
        public Sampler Sampler { get; set; }
        public ImageView View { get; set; }
        public uint Width { get; private set; }
        public uint Height { get; private set; }
        public uint MipLevels { get; private set; }
        public uint LayerCount { get; private set; }
    }
}
