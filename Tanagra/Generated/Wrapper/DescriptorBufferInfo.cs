using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorBufferInfo
    {
        internal Interop.DescriptorBufferInfo* NativePointer;
        
        Buffer _Buffer;
        public Buffer Buffer
        {
            get { return _Buffer; }
            set { _Buffer = value; NativePointer->Buffer = value.NativePointer; }
        }
        
        public DeviceSize Offset
        {
            get { return NativePointer->Offset; }
            set { NativePointer->Offset = value; }
        }
        
        public DeviceSize Range
        {
            get { return NativePointer->Range; }
            set { NativePointer->Range = value; }
        }
        
        public DescriptorBufferInfo()
        {
            NativePointer = (Interop.DescriptorBufferInfo*)Interop.Structure.Allocate(typeof(Interop.DescriptorBufferInfo));
        }
    }
}
