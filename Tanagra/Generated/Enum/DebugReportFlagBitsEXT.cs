using System;

namespace Vulkan
{
    [Flags]
    public enum DebugReportFlagBitsEXT
    {
        DEBUG_REPORT_INFORMATION_BIT_EXT = 1 << 0,
        DEBUG_REPORT_WARNING_BIT_EXT = 1 << 1,
        DEBUG_REPORT_PERFORMANCE_WARNING_BIT_EXT = 1 << 2,
        DEBUG_REPORT_ERROR_BIT_EXT = 1 << 3,
        DEBUG_REPORT_DEBUG_BIT_EXT = 1 << 4,
    }
}
