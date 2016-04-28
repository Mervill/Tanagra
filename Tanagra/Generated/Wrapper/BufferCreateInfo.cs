using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class BufferCreateInfo
    {
        internal Interop.BufferCreateInfo* NativePointer;
        
        public BufferCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public DeviceSize Size
        {
            get { return NativePointer->Size; }
            set { NativePointer->Size = value; }
        }
        
        public BufferUsageFlags Usage
        {
            get { return NativePointer->Usage; }
            set { NativePointer->Usage = value; }
        }
        
        public SharingMode SharingMode
        {
            get { return NativePointer->SharingMode; }
            set { NativePointer->SharingMode = value; }
        }
        
        public UInt32 QueueFamilyIndexCount
        {
            get { return NativePointer->QueueFamilyIndexCount; }
            set { NativePointer->QueueFamilyIndexCount = value; }
        }
        
        public UInt32 QueueFamilyIndices
        {
            get { return NativePointer->QueueFamilyIndices; }
            set { NativePointer->QueueFamilyIndices = value; }
        }
        
        public BufferCreateInfo()
        {
            NativePointer = (Interop.BufferCreateInfo*)Interop.Structure.Allocate(typeof(Interop.BufferCreateInfo));
            //NativePointer->SType = StructureType.BufferCreateInfo;
        }
    }
}
