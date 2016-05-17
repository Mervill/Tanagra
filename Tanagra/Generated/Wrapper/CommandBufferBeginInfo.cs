using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CommandBufferBeginInfo
    {
        internal Interop.CommandBufferBeginInfo* NativePointer;
        
        /// <summary>
        /// Command buffer usage flags (Optional)
        /// </summary>
        public CommandBufferUsageFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        CommandBufferInheritanceInfo _InheritanceInfo;
        /// <summary>
        /// Pointer to inheritance info for secondary command buffers (Optional)
        /// </summary>
        public CommandBufferInheritanceInfo InheritanceInfo
        {
            get { return _InheritanceInfo; }
            set { _InheritanceInfo = value; NativePointer->InheritanceInfo = (IntPtr)value.NativePointer; }
        }
        
        public CommandBufferBeginInfo()
        {
            NativePointer = (Interop.CommandBufferBeginInfo*)MemoryUtils.Allocate(typeof(Interop.CommandBufferBeginInfo));
            NativePointer->SType = StructureType.CommandBufferBeginInfo;
        }
    }
}
