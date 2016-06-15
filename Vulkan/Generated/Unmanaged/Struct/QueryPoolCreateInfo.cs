using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct QueryPoolCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_QUERY_POOL_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public QueryPoolCreateFlags Flags;
        public QueryType QueryType;
        public UInt32 QueryCount;
        /// <summary>
        /// Optional (Optional)
        /// </summary>
        public QueryPipelineStatisticFlags PipelineStatistics;
    }
}
