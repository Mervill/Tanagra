using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class BufferMemoryBarrier
    {
        internal Interop.BufferMemoryBarrier* NativeHandle;
        
        public AccessFlags SrcAccessMask
        {
            get { return NativeHandle->SrcAccessMask; }
            set { NativeHandle->SrcAccessMask = value; }
        }
        
        public AccessFlags DstAccessMask
        {
            get { return NativeHandle->DstAccessMask; }
            set { NativeHandle->DstAccessMask = value; }
        }
        
        public UInt32 SrcQueueFamilyIndex
        {
            get { return NativeHandle->SrcQueueFamilyIndex; }
            set { NativeHandle->SrcQueueFamilyIndex = value; }
        }
        
        public UInt32 DstQueueFamilyIndex
        {
            get { return NativeHandle->DstQueueFamilyIndex; }
            set { NativeHandle->DstQueueFamilyIndex = value; }
        }
        
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
        
        DeviceSize _Size;
        public DeviceSize Size
        {
            get { return _Size; }
            set { _Size = value; NativeHandle->Size = (IntPtr)value.NativeHandle; }
        }
        
        public BufferMemoryBarrier()
        {
            NativeHandle = (Interop.BufferMemoryBarrier*)Interop.Structure.Allocate(typeof(Interop.BufferMemoryBarrier));
            //NativeHandle->SType = StructureType.BufferMemoryBarrier;
        }
    }
}
