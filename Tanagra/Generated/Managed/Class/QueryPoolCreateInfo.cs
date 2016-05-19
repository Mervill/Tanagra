using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class QueryPoolCreateInfo
    {
        internal Unmanaged.QueryPoolCreateInfo* NativePointer;
        
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
            NativePointer = (Unmanaged.QueryPoolCreateInfo*)MemoryUtils.Allocate(typeof(Unmanaged.QueryPoolCreateInfo));
            NativePointer->SType = StructureType.QueryPoolCreateInfo;
        }
        
        public QueryPoolCreateInfo(QueryType QueryType, UInt32 QueryCount) : this()
        {
            this.QueryType = QueryType;
            this.QueryCount = QueryCount;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.QueryPoolCreateInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
