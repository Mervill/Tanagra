using System;

namespace Vulkan
{
    public enum PresentMode
    {
        ImmediateKhr = 0,
        MailboxKhr = 1,
        FifoKhr = 2,
        FifoRelaxedKhr = 3,
    }
}
