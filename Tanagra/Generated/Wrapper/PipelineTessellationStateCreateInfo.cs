using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineTessellationStateCreateInfo
    {
        internal Interop.PipelineTessellationStateCreateInfo* NativePointer;
        
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
            NativePointer = (Interop.PipelineTessellationStateCreateInfo*)MemoryUtils.Allocate(typeof(Interop.PipelineTessellationStateCreateInfo));
            NativePointer->SType = StructureType.PipelineTessellationStateCreateInfo;
        }
        
        public PipelineTessellationStateCreateInfo(UInt32 PatchControlPoints) : this()
        {
            this.PatchControlPoints = PatchControlPoints;
        }
    }
}
