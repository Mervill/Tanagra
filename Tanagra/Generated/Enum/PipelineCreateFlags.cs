using System;

namespace Vulkan
{
    [Flags]
    public enum PipelineCreateFlags
    {
        PIPELINE_CREATE_DISABLE_OPTIMIZATION_BIT = 1 << 0,
        PIPELINE_CREATE_ALLOW_DERIVATIVES_BIT = 1 << 1,
        PIPELINE_CREATE_DERIVATIVE_BIT = 1 << 2,
    }
}
