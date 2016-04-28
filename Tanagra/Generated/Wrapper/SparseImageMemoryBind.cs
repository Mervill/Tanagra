using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseImageMemoryBind
    {
        internal Interop.SparseImageMemoryBind* NativePointer;
        
        ImageSubresource _Subresource;
        public ImageSubresource Subresource
        {
            get { return _Subresource; }
            set { _Subresource = value; NativePointer->Subresource = (IntPtr)value.NativePointer; }
        }
        
        Offset3D _Offset;
        public Offset3D Offset
        {
            get { return _Offset; }
            set { _Offset = value; NativePointer->Offset = (IntPtr)value.NativePointer; }
        }
        
        Extent3D _Extent;
        public Extent3D Extent
        {
            get { return _Extent; }
            set { _Extent = value; NativePointer->Extent = (IntPtr)value.NativePointer; }
        }
        
        DeviceMemory _Memory;
        public DeviceMemory Memory
        {
            get { return _Memory; }
            set { _Memory = value; NativePointer->Memory = (IntPtr)value.NativePointer; }
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
