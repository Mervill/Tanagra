using System;

namespace Vulkan
{
    [Flags]
    public enum PipelineCreateFlags
    {
        DisableOptimization = 1 << 0,
        AllowDerivatives = 1 << 1,
        Derivative = 1 << 2,
    }
}
