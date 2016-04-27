using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineTessellationStateCreateInfo
    {
        internal Interop.PipelineTessellationStateCreateInfo* NativeHandle;
        
        public PipelineTessellationStateCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public UInt32 PatchControlPoints
        {
            get { return NativeHandle->PatchControlPoints; }
            set { NativeHandle->PatchControlPoints = value; }
        }
        
        public PipelineTessellationStateCreateInfo()
        {
            NativeHandle = (Interop.PipelineTessellationStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineTessellationStateCreateInfo));
            //NativeHandle->SType = StructureType.PipelineTessellationStateCreateInfo;
        }
    }
}
