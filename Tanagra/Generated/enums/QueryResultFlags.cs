using System;

namespace Vulkan
{
    [Flags]
    public enum QueryResultFlags
    {
        QUERY_RESULT_64_BIT = 0,
        QUERY_RESULT_WAIT_BIT = 1,
        QUERY_RESULT_WITH_AVAILABILITY_BIT = 2,
        QUERY_RESULT_PARTIAL_BIT = 3,
    }
}
