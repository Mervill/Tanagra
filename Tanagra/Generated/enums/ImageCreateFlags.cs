using System;

namespace Vulkan
{
    [Flags]
    public enum ImageCreateFlags
    {
        IMAGE_CREATE_SPARSE_BINDING_BIT = 0,
        IMAGE_CREATE_SPARSE_RESIDENCY_BIT = 1,
        IMAGE_CREATE_SPARSE_ALIASED_BIT = 2,
        IMAGE_CREATE_MUTABLE_FORMAT_BIT = 3,
        IMAGE_CREATE_CUBE_COMPATIBLE_BIT = 4,
    }
}
