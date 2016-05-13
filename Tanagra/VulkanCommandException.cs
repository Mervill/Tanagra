using System;

namespace Vulkan
{
    public class VulkanCommandException : Exception
    {
        public readonly String CommandName;
        public readonly Result Result;

        public VulkanCommandException(string commandName, Result result)
            : base($"Vulkan command {commandName} failed with error `{result}`")
        {
            CommandName = commandName;
            Result = result;
        }
    }
}
