using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class PipelineInputAssemblyStateCreateInfo : IDisposable
    {
        internal Unmanaged.PipelineInputAssemblyStateCreateInfo* NativePointer { get; private set; }
        
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
            NativePointer = (Unmanaged.PipelineInputAssemblyStateCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.PipelineInputAssemblyStateCreateInfo));
            NativePointer->SType = StructureType.PipelineInputAssemblyStateCreateInfo;
        }
        
        internal PipelineInputAssemblyStateCreateInfo(Unmanaged.PipelineInputAssemblyStateCreateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.PipelineInputAssemblyStateCreateInfo));
        }
        
        public PipelineInputAssemblyStateCreateInfo(PrimitiveTopology Topology, Bool32 PrimitiveRestartEnable) : this()
        {
            this.Topology = Topology;
            this.PrimitiveRestartEnable = PrimitiveRestartEnable;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~PipelineInputAssemblyStateCreateInfo()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
