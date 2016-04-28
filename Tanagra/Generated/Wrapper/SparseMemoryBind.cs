using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseMemoryBind
    {
        internal Interop.SparseMemoryBind* NativePointer;
        
        public DeviceSize ResourceOffset
        {
            get { return NativePointer->ResourceOffset; }
            set { NativePointer->ResourceOffset = value; }
        }
        
        public DeviceSize Size
        {
            get { return NativePointer->Size; }
            set { NativePointer->Size = value; }
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
        
        public SparseMemoryBind()
        {
            NativePointer = (Interop.SparseMemoryBind*)Interop.Structure.Allocate(typeof(Interop.SparseMemoryBind));
        }
    }
}
