using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct QueryPoolCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public QueryPoolCreateFlags flags;
        public QueryType queryType;
        public UInt32 queryCount;
        public QueryPipelineStatisticFlags pipelineStatistics;
    }
}
