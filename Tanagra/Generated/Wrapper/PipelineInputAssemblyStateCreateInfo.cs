using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineInputAssemblyStateCreateInfo
    {
        internal Interop.PipelineInputAssemblyStateCreateInfo* NativePointer;
        
        public PipelineInputAssemblyStateCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public PrimitiveTopology Topology
        {
            get { return NativePointer->Topology; }
            set { NativePointer->Topology = value; }
        }
        
        public Boolean PrimitiveRestartEnable
        {
            get { return NativePointer->PrimitiveRestartEnable; }
            set { NativePointer->PrimitiveRestartEnable = value; }
        }
        
        public PipelineInputAssemblyStateCreateInfo()
        {
            NativePointer = (Interop.PipelineInputAssemblyStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineInputAssemblyStateCreateInfo));
            NativePointer->SType = StructureType.PipelineInputAssemblyStateCreateInfo;
        }
    }
}
