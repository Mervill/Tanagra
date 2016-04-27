using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseMemoryBind
    {
        internal Interop.SparseMemoryBind* NativeHandle;
        
        DeviceSize _ResourceOffset;
        public DeviceSize ResourceOffset
        {
            get { return _ResourceOffset; }
            set { _ResourceOffset = value; NativeHandle->ResourceOffset = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _Size;
        public DeviceSize Size
        {
            get { return _Size; }
            set { _Size = value; NativeHandle->Size = (IntPtr)value.NativeHandle; }
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
        
        public SparseMemoryBind()
        {
            NativeHandle = (Interop.SparseMemoryBind*)Interop.Structure.Allocate(typeof(Interop.SparseMemoryBind));
        }
    }
}
