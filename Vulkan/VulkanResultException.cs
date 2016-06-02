using System;

namespace Vulkan
{
    public class VulkanResultException : Exception
    {
        public readonly string CommandName;
        public readonly Result Result;

        public VulkanResultException(string commandName, Result result)
            : base($"Vulkan command {commandName} failed with error `{result}`")
        {
            CommandName = commandName;
            Result = result;
        }
    }
}
