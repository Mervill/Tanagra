using System;

namespace Vulkan
{
    public enum PresentModeKHR
    {
        IMMEDIATE_KHR = 0,
        MAILBOX_KHR = 1,
        FIFO_KHR = 2,
        FIFO_RELAXED_KHR = 3,
    }
}
