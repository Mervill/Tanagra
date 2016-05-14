using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MappedMemoryRange
    {
        internal Interop.MappedMemoryRange* NativePointer;
        
        DeviceMemory _Memory;
        public DeviceMemory Memory
        {
            get { return _Memory; }
            set { _Memory = value; NativePointer->Memory = value.NativePointer; }
        }
        
        public DeviceSize Offset
        {
            get { return NativePointer->Offset; }
            set { NativePointer->Offset = value; }
        }
        
        public DeviceSize Size
        {
            get { return NativePointer->Size; }
            set { NativePointer->Size = value; }
        }
        
        public MappedMemoryRange()
        {
            NativePointer = (Interop.MappedMemoryRange*)Interop.Structure.Allocate(typeof(Interop.MappedMemoryRange));
            NativePointer->SType = StructureType.MappedMemoryRange;
        }
        
        public MappedMemoryRange(DeviceMemory Memory, DeviceSize Offset, DeviceSize Size) : this()
        {
            this.Memory = Memory;
            this.Offset = Offset;
            this.Size = Size;
        }
    }
}
