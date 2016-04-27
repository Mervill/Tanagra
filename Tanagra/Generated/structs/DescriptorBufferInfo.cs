using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorBufferInfo
    {
        internal Interop.DescriptorBufferInfo* NativeHandle;
        
        Buffer _Buffer;
        public Buffer Buffer
        {
            get { return _Buffer; }
            set { _Buffer = value; NativeHandle->Buffer = (IntPtr)value.NativeHandle; }
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
        
        public DescriptorBufferInfo()
        {
            NativeHandle = (Interop.DescriptorBufferInfo*)Interop.Structure.Allocate(typeof(Interop.DescriptorBufferInfo));
        }
    }
}
