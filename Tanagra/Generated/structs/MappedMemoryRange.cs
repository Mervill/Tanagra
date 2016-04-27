using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MappedMemoryRange
    {
        internal Interop.MappedMemoryRange* NativeHandle;
        
        DeviceMemory _Memory;
        public DeviceMemory Memory
        {
            get { return _Memory; }
            set { _Memory = value; NativeHandle->Memory = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _Offset;
        public DeviceSize Offset
        {
            get { return _Offset; }
            set { _Offset = value; NativeHandle->Offset = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _Size;
        public DeviceSize Size
        {
            get { return _Size; }
            set { _Size = value; NativeHandle->Size = (IntPtr)value.NativeHandle; }
        }
        
        public MappedMemoryRange()
        {
            NativeHandle = (Interop.MappedMemoryRange*)Interop.Structure.Allocate(typeof(Interop.MappedMemoryRange));
            //NativeHandle->SType = StructureType.MappedMemoryRange;
        }
    }
}
