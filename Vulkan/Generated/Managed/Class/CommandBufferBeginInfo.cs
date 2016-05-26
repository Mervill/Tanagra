using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class CommandBufferBeginInfo : IDisposable
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
            NativePointer = (Unmanaged.CommandBufferBeginInfo*)MemUtil.Alloc(typeof(Unmanaged.CommandBufferBeginInfo));
            NativePointer->SType = StructureType.CommandBufferBeginInfo;
        }
        
        public void Dispose()
        {
            MemUtil.Free((IntPtr)NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~CommandBufferBeginInfo()
        {
            if(NativePointer != null)
            {
                MemUtil.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
