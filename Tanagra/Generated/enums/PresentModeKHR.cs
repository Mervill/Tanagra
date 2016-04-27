using System;

namespace Vulkan
{
    public enum PresentModeKHR
    {
        PRESENT_MODE_IMMEDIATE_KHR = 0,
        PRESENT_MODE_MAILBOX_KHR = 1,
        PRESENT_MODE_FIFO_KHR = 2,
        PRESENT_MODE_FIFO_RELAXED_KHR = 3,
    }
}
