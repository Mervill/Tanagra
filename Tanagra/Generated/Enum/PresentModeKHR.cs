using System;

namespace Vulkan
{
    public enum PresentModeKHR
    {
        Immediate = 0,
        Mailbox = 1,
        Fifo = 2,
        FifoRelaxed = 3,
    }
}
