using System;

namespace Vulkan
{
    public enum PhysicalDeviceType
    {
        PHYSICAL_DEVICE_TYPE_OTHER = 0,
        PHYSICAL_DEVICE_TYPE_INTEGRATED_GPU = 1,
        PHYSICAL_DEVICE_TYPE_DISCRETE_GPU = 2,
        PHYSICAL_DEVICE_TYPE_VIRTUAL_GPU = 3,
        PHYSICAL_DEVICE_TYPE_CPU = 4,
    }
}
