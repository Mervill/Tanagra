using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorBufferInfo
    {
        internal Interop.DescriptorBufferInfo* NativePointer;
        
        Buffer _Buffer;
        /// <summary>
        /// Buffer used for this descriptor slot when the descriptor is UNIFORM_BUFFER[_DYNAMIC] or STORAGE_BUFFER[_DYNAMIC]. VK_NULL_HANDLE otherwise.
        /// </summary>
        public Buffer Buffer
        {
            get { return _Buffer; }
            set { _Buffer = value; NativePointer->Buffer = value.NativePointer; }
        }
        
        /// <summary>
        /// Base offset from buffer start in bytes to update in the descriptor set.
        /// </summary>
        public DeviceSize Offset
        {
            get { return NativePointer->Offset; }
            set { NativePointer->Offset = value; }
        }
        
        /// <summary>
        /// Size in bytes of the buffer resource for this descriptor update.
        /// </summary>
        public DeviceSize Range
        {
            get { return NativePointer->Range; }
            set { NativePointer->Range = value; }
        }
        
        public DescriptorBufferInfo()
        {
            NativePointer = (Interop.DescriptorBufferInfo*)MemoryUtils.Allocate(typeof(Interop.DescriptorBufferInfo));
        }
        
        public DescriptorBufferInfo(Buffer Buffer, DeviceSize Offset, DeviceSize Range) : this()
        {
            this.Buffer = Buffer;
            this.Offset = Offset;
            this.Range = Range;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.DescriptorBufferInfo*)IntPtr.Zero;
        }
    }
}
