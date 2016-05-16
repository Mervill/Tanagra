using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseImageMemoryBind
    {
        internal Interop.SparseImageMemoryBind* NativePointer;
        
        public ImageSubresource Subresource
        {
            get { return NativePointer->Subresource; }
            set { NativePointer->Subresource = value; }
        }
        
        public Offset3D Offset
        {
            get { return NativePointer->Offset; }
            set { NativePointer->Offset = value; }
        }
        
        public Extent3D Extent
        {
            get { return NativePointer->Extent; }
            set { NativePointer->Extent = value; }
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
        /// Reserved for future
        /// </summary>
        public SparseMemoryBindFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public SparseImageMemoryBind()
        {
            NativePointer = (Interop.SparseImageMemoryBind*)Interop.Structure.Allocate(typeof(Interop.SparseImageMemoryBind));
        }
        
        public SparseImageMemoryBind(ImageSubresource Subresource, Offset3D Offset, Extent3D Extent, DeviceSize MemoryOffset) : this()
        {
            this.Subresource = Subresource;
            this.Offset = Offset;
            this.Extent = Extent;
            this.MemoryOffset = MemoryOffset;
        }
    }
}
