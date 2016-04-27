using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MemoryRequirements
    {
        internal Interop.MemoryRequirements* NativeHandle;
        
        DeviceSize _Size;
        public DeviceSize Size
        {
            get { return _Size; }
            set { _Size = value; NativeHandle->Size = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _Alignment;
        public DeviceSize Alignment
        {
            get { return _Alignment; }
            set { _Alignment = value; NativeHandle->Alignment = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 MemoryTypeBits
        {
            get { return NativeHandle->MemoryTypeBits; }
            set { NativeHandle->MemoryTypeBits = value; }
        }
        
        public MemoryRequirements()
        {
            NativeHandle = (Interop.MemoryRequirements*)Interop.Structure.Allocate(typeof(Interop.MemoryRequirements));
        }
    }
}
