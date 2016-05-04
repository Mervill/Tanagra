using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class BufferViewCreateInfo
    {
        internal Interop.BufferViewCreateInfo* NativePointer;
        
        public BufferViewCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        Buffer _Buffer;
        public Buffer Buffer
        {
            get { return _Buffer; }
            set { _Buffer = value; NativePointer->Buffer = value.NativePointer; }
        }
        
        public Format Format
        {
            get { return NativePointer->Format; }
            set { NativePointer->Format = value; }
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
        
        public BufferViewCreateInfo()
        {
            NativePointer = (Interop.BufferViewCreateInfo*)Interop.Structure.Allocate(typeof(Interop.BufferViewCreateInfo));
            NativePointer->SType = StructureType.BufferViewCreateInfo;
        }
    }
}
