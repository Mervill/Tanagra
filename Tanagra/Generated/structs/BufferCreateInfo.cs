using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class BufferCreateInfo
    {
        internal Interop.BufferCreateInfo* NativeHandle;
        
        public BufferCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        DeviceSize _Size;
        public DeviceSize Size
        {
            get { return _Size; }
            set { _Size = value; NativeHandle->Size = (IntPtr)value.NativeHandle; }
        }
        
        public BufferUsageFlags Usage
        {
            get { return NativeHandle->Usage; }
            set { NativeHandle->Usage = value; }
        }
        
        public SharingMode SharingMode
        {
            get { return NativeHandle->SharingMode; }
            set { NativeHandle->SharingMode = value; }
        }
        
        public UInt32 QueueFamilyIndexCount
        {
            get { return NativeHandle->QueueFamilyIndexCount; }
            set { NativeHandle->QueueFamilyIndexCount = value; }
        }
        
        public UInt32 QueueFamilyIndices
        {
            get { return NativeHandle->QueueFamilyIndices; }
            set { NativeHandle->QueueFamilyIndices = value; }
        }
        
        public BufferCreateInfo()
        {
            NativeHandle = (Interop.BufferCreateInfo*)Interop.Structure.Allocate(typeof(Interop.BufferCreateInfo));
            //NativeHandle->SType = StructureType.BufferCreateInfo;
        }
    }
}
