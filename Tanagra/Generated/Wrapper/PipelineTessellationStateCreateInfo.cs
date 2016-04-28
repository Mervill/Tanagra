using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineTessellationStateCreateInfo
    {
        internal Interop.PipelineTessellationStateCreateInfo* NativePointer;
        
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
            NativePointer = (Interop.PipelineTessellationStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineTessellationStateCreateInfo));
            //NativePointer->SType = StructureType.PipelineTessellationStateCreateInfo;
        }
    }
}
