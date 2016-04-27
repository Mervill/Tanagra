using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineInputAssemblyStateCreateInfo
    {
        internal Interop.PipelineInputAssemblyStateCreateInfo* NativeHandle;
        
        public PipelineInputAssemblyStateCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public PrimitiveTopology Topology
        {
            get { return NativeHandle->Topology; }
            set { NativeHandle->Topology = value; }
        }
        
        public Boolean PrimitiveRestartEnable
        {
            get { return NativeHandle->PrimitiveRestartEnable; }
            set { NativeHandle->PrimitiveRestartEnable = value; }
        }
        
        public PipelineInputAssemblyStateCreateInfo()
        {
            NativeHandle = (Interop.PipelineInputAssemblyStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineInputAssemblyStateCreateInfo));
            //NativeHandle->SType = StructureType.PipelineInputAssemblyStateCreateInfo;
        }
    }
}
