using System;

namespace Vulkan
{
    [Flags]
    public enum QueryResultFlags
    {
        None = 0,
        /// <summary>
        /// Results of the queries are written to the destination buffer as 64-bit values
        /// </summary>
        QueryResultFlags64 = 1 << 0,
        /// <summary>
        /// Results of the queries are waited on before proceeding with the result copy
        /// </summary>
        QueryResultFlagsWait = 1 << 1,
        /// <summary>
        /// Besides the results of the query, the availability of the results is also written
        /// </summary>
        QueryResultFlagsWithAvailability = 1 << 2,
        /// <summary>
        /// Copy the partial results of the query even if the final results aren't available
        /// </summary>
        QueryResultFlagsPartial = 1 << 3,
    }
}
