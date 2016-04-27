using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseImageMemoryBind
    {
        internal Interop.SparseImageMemoryBind* NativeHandle;
        
        ImageSubresource _Subresource;
        public ImageSubresource Subresource
        {
            get { return _Subresource; }
            set { _Subresource = value; NativeHandle->Subresource = (IntPtr)value.NativeHandle; }
        }
        
        Offset3D _Offset;
        public Offset3D Offset
        {
            get { return _Offset; }
            set { _Offset = value; NativeHandle->Offset = (IntPtr)value.NativeHandle; }
        }
        
        Extent3D _Extent;
        public Extent3D Extent
        {
            get { return _Extent; }
            set { _Extent = value; NativeHandle->Extent = (IntPtr)value.NativeHandle; }
        }
        
        DeviceMemory _Memory;
        public DeviceMemory Memory
        {
            get { return _Memory; }
            set { _Memory = value; NativeHandle->Memory = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _MemoryOffset;
        public DeviceSize MemoryOffset
        {
            get { return _MemoryOffset; }
            set { _MemoryOffset = value; NativeHandle->MemoryOffset = (IntPtr)value.NativeHandle; }
        }
        
        public SparseMemoryBindFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public SparseImageMemoryBind()
        {
            NativeHandle = (Interop.SparseImageMemoryBind*)Interop.Structure.Allocate(typeof(Interop.SparseImageMemoryBind));
        }
    }
}
