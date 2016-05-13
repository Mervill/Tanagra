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
        
        public DeviceSize MemoryOffset
        {
            get { return NativePointer->MemoryOffset; }
            set { NativePointer->MemoryOffset = value; }
        }
        
        public SparseMemoryBindFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public SparseImageMemoryBind()
        {
            NativePointer = (Interop.SparseImageMemoryBind*)Interop.Structure.Allocate(typeof(Interop.SparseImageMemoryBind));
        }
    }
}
