using System;

namespace Vulkan
{
    [Flags]
    public enum DebugReportFlagsEXT
    {
        None = 0,
        DebugReportInformationBitExt = 1 << 0,
        DebugReportWarningBitExt = 1 << 1,
        DebugReportPerformanceWarningBitExt = 1 << 2,
        DebugReportErrorBitExt = 1 << 3,
        DebugReportDebugBitExt = 1 << 4,
    }
}
