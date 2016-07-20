using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// [<see cref="IExtensible"/>: None]
    /// </summary>
    unsafe public class QueryPoolCreateInfo : IDisposable
    {
        internal Unmanaged.QueryPoolCreateInfo* NativePointer { get; private set; }
        
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
            NativePointer = (Unmanaged.QueryPoolCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.QueryPoolCreateInfo));
            NativePointer->SType = StructureType.QueryPoolCreateInfo;
        }
        
        internal QueryPoolCreateInfo(Unmanaged.QueryPoolCreateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.QueryPoolCreateInfo));
        }
        
        public QueryPoolCreateInfo(QueryType QueryType, UInt32 QueryCount) : this()
        {
            this.QueryType = QueryType;
            this.QueryCount = QueryCount;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~QueryPoolCreateInfo()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
