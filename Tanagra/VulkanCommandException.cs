using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vulkan
{
    public class VulkanCommandException : Exception
    {
        public VulkanCommandException(string commandName, Result resultValue)
            : base($"Vulkan command {commandName} failed with error `{resultValue}`")
        {

        }
    }
}
