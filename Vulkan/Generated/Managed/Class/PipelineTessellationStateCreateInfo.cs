using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// [<see cref="IExtensible"/>: None]
    /// </summary>
    unsafe public class PipelineTessellationStateCreateInfo : IDisposable
    {
        internal Unmanaged.PipelineTessellationStateCreateInfo* NativePointer { get; private set; }
        
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
            NativePointer = (Unmanaged.PipelineTessellationStateCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.PipelineTessellationStateCreateInfo));
            NativePointer->SType = StructureType.PipelineTessellationStateCreateInfo;
        }
        
        internal PipelineTessellationStateCreateInfo(Unmanaged.PipelineTessellationStateCreateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.PipelineTessellationStateCreateInfo));
        }
        
        public PipelineTessellationStateCreateInfo(UInt32 PatchControlPoints) : this()
        {
            this.PatchControlPoints = PatchControlPoints;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~PipelineTessellationStateCreateInfo()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
