using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class BufferMemoryBarrier
    {
        internal Interop.BufferMemoryBarrier* NativePointer;
        
        public AccessFlags SrcAccessMask
        {
            get { return NativePointer->SrcAccessMask; }
            set { NativePointer->SrcAccessMask = value; }
        }
        
        public AccessFlags DstAccessMask
        {
            get { return NativePointer->DstAccessMask; }
            set { NativePointer->DstAccessMask = value; }
        }
        
        public UInt32 SrcQueueFamilyIndex
        {
            get { return NativePointer->SrcQueueFamilyIndex; }
            set { NativePointer->SrcQueueFamilyIndex = value; }
        }
        
        public UInt32 DstQueueFamilyIndex
        {
            get { return NativePointer->DstQueueFamilyIndex; }
            set { NativePointer->DstQueueFamilyIndex = value; }
        }
        
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
        
        public DeviceSize Size
        {
            get { return NativePointer->Size; }
            set { NativePointer->Size = value; }
        }
        
        public BufferMemoryBarrier()
        {
            NativePointer = (Interop.BufferMemoryBarrier*)Interop.Structure.Allocate(typeof(Interop.BufferMemoryBarrier));
            NativePointer->SType = StructureType.BufferMemoryBarrier;
        }
        
        public BufferMemoryBarrier(UInt32 SrcQueueFamilyIndex, UInt32 DstQueueFamilyIndex, Buffer Buffer, DeviceSize Offset, DeviceSize Size) : this()
        {
            this.SrcQueueFamilyIndex = SrcQueueFamilyIndex;
            this.DstQueueFamilyIndex = DstQueueFamilyIndex;
            this.Buffer = Buffer;
            this.Offset = Offset;
            this.Size = Size;
        }
    }
}
