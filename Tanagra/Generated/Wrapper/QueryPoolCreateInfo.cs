using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class QueryPoolCreateInfo
    {
        internal Interop.QueryPoolCreateInfo* NativeHandle;
        
        public QueryPoolCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public QueryType QueryType
        {
            get { return NativeHandle->QueryType; }
            set { NativeHandle->QueryType = value; }
        }
        
        public UInt32 QueryCount
        {
            get { return NativeHandle->QueryCount; }
            set { NativeHandle->QueryCount = value; }
        }
        
        public QueryPipelineStatisticFlags PipelineStatistics
        {
            get { return NativeHandle->PipelineStatistics; }
            set { NativeHandle->PipelineStatistics = value; }
        }
        
        public QueryPoolCreateInfo()
        {
            NativeHandle = (Interop.QueryPoolCreateInfo*)Interop.Structure.Allocate(typeof(Interop.QueryPoolCreateInfo));
            //NativeHandle->SType = StructureType.QueryPoolCreateInfo;
        }
    }
}
