using System;

namespace Vulkan
{
    [Flags]
    public enum PipelineCreateFlags
    {
        PIPELINE_CREATE_DISABLE_OPTIMIZATION_BIT = 0,
        PIPELINE_CREATE_ALLOW_DERIVATIVES_BIT = 1,
        PIPELINE_CREATE_DERIVATIVE_BIT = 2,
    }
}
