using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class BufferViewCreateInfo
    {
        internal Interop.BufferViewCreateInfo* NativeHandle;
        
        public BufferViewCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        Buffer _Buffer;
        public Buffer Buffer
        {
            get { return _Buffer; }
            set { _Buffer = value; NativeHandle->Buffer = (IntPtr)value.NativeHandle; }
        }
        
        public Format Format
        {
            get { return NativeHandle->Format; }
            set { NativeHandle->Format = value; }
        }
        
        DeviceSize _Offset;
        public DeviceSize Offset
        {
            get { return _Offset; }
            set { _Offset = value; NativeHandle->Offset = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _Range;
        public DeviceSize Range
        {
            get { return _Range; }
            set { _Range = value; NativeHandle->Range = (IntPtr)value.NativeHandle; }
        }
        
        public BufferViewCreateInfo()
        {
            NativeHandle = (Interop.BufferViewCreateInfo*)Interop.Structure.Allocate(typeof(Interop.BufferViewCreateInfo));
            //NativeHandle->SType = StructureType.BufferViewCreateInfo;
        }
    }
}
