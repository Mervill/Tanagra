using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineTessellationStateCreateInfo
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
            NativePointer = (Unmanaged.PipelineTessellationStateCreateInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
