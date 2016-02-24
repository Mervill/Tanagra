using System;

namespace Vulkan
{
    [Flags]
    public enum QueryResultFlags
    {
        /// <summary>
        /// Results of the queries are written to the destination buffer as 64-bit values
        /// </summary>
        QUERY_RESULT_64_BIT = 0,
        /// <summary>
        /// Results of the queries are waited on before proceeding with the result copy
        /// </summary>
        QUERY_RESULT_WAIT_BIT = 1,
        /// <summary>
        /// Besides the results of the query, the availability of the results is also written
        /// </summary>
        QUERY_RESULT_WITH_AVAILABILITY_BIT = 2,
        /// <summary>
        /// Copy the partial results of the query even if the final results aren't available
        /// </summary>
        QUERY_RESULT_PARTIAL_BIT = 3,
    }
}
