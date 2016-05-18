using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class QueryPoolCreateInfo
    {
        internal Interop.QueryPoolCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public QueryPoolCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public QueryType QueryType
        {
            get { return NativePointer->QueryType; }
            set { NativePointer->QueryType = value; }
        }
        
        public UInt32 QueryCount
        {
            get { return NativePointer->QueryCount; }
            set { NativePointer->QueryCount = value; }
        }
        
        /// <summary>
        /// Optional (Optional)
        /// </summary>
        public QueryPipelineStatisticFlags PipelineStatistics
        {
            get { return NativePointer->PipelineStatistics; }
            set { NativePointer->PipelineStatistics = value; }
        }
        
        public QueryPoolCreateInfo()
        {
            NativePointer = (Interop.QueryPoolCreateInfo*)MemoryUtils.Allocate(typeof(Interop.QueryPoolCreateInfo));
            NativePointer->SType = StructureType.QueryPoolCreateInfo;
        }
        
        public QueryPoolCreateInfo(QueryType QueryType, UInt32 QueryCount) : this()
        {
            this.QueryType = QueryType;
            this.QueryCount = QueryCount;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.QueryPoolCreateInfo*)IntPtr.Zero;
        }
    }
}
