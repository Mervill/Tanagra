using System;

namespace Vulkan
{
    [Flags]
    public enum BufferCreateFlags
    {
        BUFFER_CREATE_SPARSE_BINDING_BIT = 0,
        BUFFER_CREATE_SPARSE_RESIDENCY_BIT = 1,
        BUFFER_CREATE_SPARSE_ALIASED_BIT = 2,
    }
}
