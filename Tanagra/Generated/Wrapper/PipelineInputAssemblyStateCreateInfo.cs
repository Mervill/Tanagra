using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineInputAssemblyStateCreateInfo
    {
        internal Interop.PipelineInputAssemblyStateCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
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
        
        public Bool32 PrimitiveRestartEnable
        {
            get { return NativePointer->PrimitiveRestartEnable; }
            set { NativePointer->PrimitiveRestartEnable = value; }
        }
        
        public PipelineInputAssemblyStateCreateInfo()
        {
            NativePointer = (Interop.PipelineInputAssemblyStateCreateInfo*)MemoryUtils.Allocate(typeof(Interop.PipelineInputAssemblyStateCreateInfo));
            NativePointer->SType = StructureType.PipelineInputAssemblyStateCreateInfo;
        }
        
        public PipelineInputAssemblyStateCreateInfo(PrimitiveTopology Topology, Bool32 PrimitiveRestartEnable) : this()
        {
            this.Topology = Topology;
            this.PrimitiveRestartEnable = PrimitiveRestartEnable;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.PipelineInputAssemblyStateCreateInfo*)IntPtr.Zero;
        }
    }
}
