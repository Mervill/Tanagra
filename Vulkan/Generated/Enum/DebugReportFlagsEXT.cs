using System;

namespace Vulkan
{
    [Flags]
    public enum DebugReportFlagsEXT
    {
        None = 0,
        Information = 1 << 0,
        Warning = 1 << 1,
        PerformanceWarning = 1 << 2,
        Error = 1 << 3,
        Debug = 1 << 4,
    }
}
