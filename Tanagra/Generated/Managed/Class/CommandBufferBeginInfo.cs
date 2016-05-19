using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CommandBufferBeginInfo
    {
        internal Unmanaged.CommandBufferBeginInfo* NativePointer;
        
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
            NativePointer = (Unmanaged.CommandBufferBeginInfo*)MemoryUtils.Allocate(typeof(Unmanaged.CommandBufferBeginInfo));
            NativePointer->SType = StructureType.CommandBufferBeginInfo;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.CommandBufferBeginInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
