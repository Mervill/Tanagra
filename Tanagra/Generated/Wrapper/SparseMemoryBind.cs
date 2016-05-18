using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseMemoryBind
    {
        internal Interop.SparseMemoryBind* NativePointer;
        
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize ResourceOffset
        {
            get { return NativePointer->ResourceOffset; }
            set { NativePointer->ResourceOffset = value; }
        }
        
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Size
        {
            get { return NativePointer->Size; }
            set { NativePointer->Size = value; }
        }
        
        DeviceMemory _Memory;
        public DeviceMemory Memory
        {
            get { return _Memory; }
            set { _Memory = value; NativePointer->Memory = value.NativePointer; }
        }
        
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize MemoryOffset
        {
            get { return NativePointer->MemoryOffset; }
            set { NativePointer->MemoryOffset = value; }
        }
        
        /// <summary>
        /// Reserved for future (Optional)
        /// </summary>
        public SparseMemoryBindFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public SparseMemoryBind()
        {
            NativePointer = (Interop.SparseMemoryBind*)MemoryUtils.Allocate(typeof(Interop.SparseMemoryBind));
        }
        
        public SparseMemoryBind(DeviceSize ResourceOffset, DeviceSize Size, DeviceSize MemoryOffset) : this()
        {
            this.ResourceOffset = ResourceOffset;
            this.Size = Size;
            this.MemoryOffset = MemoryOffset;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.SparseMemoryBind*)IntPtr.Zero;
        }
    }
}
