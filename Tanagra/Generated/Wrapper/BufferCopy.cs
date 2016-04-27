using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class BufferCopy
    {
        internal Interop.BufferCopy* NativeHandle;
        
        DeviceSize _SrcOffset;
        public DeviceSize SrcOffset
        {
            get { return _SrcOffset; }
            set { _SrcOffset = value; NativeHandle->SrcOffset = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _DstOffset;
        public DeviceSize DstOffset
        {
            get { return _DstOffset; }
            set { _DstOffset = value; NativeHandle->DstOffset = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _Size;
        public DeviceSize Size
        {
            get { return _Size; }
            set { _Size = value; NativeHandle->Size = (IntPtr)value.NativeHandle; }
        }
        
        public BufferCopy()
        {
            NativeHandle = (Interop.BufferCopy*)Interop.Structure.Allocate(typeof(Interop.BufferCopy));
        }
    }
}
