using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class PipelineTessellationStateCreateInfo : IDisposable
    {
        internal Unmanaged.PipelineTessellationStateCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineTessellationStateCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public UInt32 PatchControlPoints
        {
            get { return NativePointer->PatchControlPoints; }
            set { NativePointer->PatchControlPoints = value; }
        }
        
        public PipelineTessellationStateCreateInfo()
        {
            NativePointer = (Unmanaged.PipelineTessellationStateCreateInfo*)MemoryUtils.Allocate(typeof(Unmanaged.PipelineTessellationStateCreateInfo));
            NativePointer->SType = StructureType.PipelineTessellationStateCreateInfo;
        }
        
        public PipelineTessellationStateCreateInfo(UInt32 PatchControlPoints) : this()
        {
            this.PatchControlPoints = PatchControlPoints;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~PipelineTessellationStateCreateInfo()
        {
            if(NativePointer != null)
            {
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
