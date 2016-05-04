using System;

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
