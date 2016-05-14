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
        
        public UInt32[] QueueFamilyIndices
        {
            get
            {
                var valueCount = NativePointer->QueueFamilyIndexCount;
                var valueArray = new UInt32[valueCount];
                var ptr = (UInt32*)NativePointer->QueueFamilyIndices;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->QueueFamilyIndexCount = (uint)valueCount;
                NativePointer->QueueFamilyIndices = Marshal.AllocHGlobal(Marshal.SizeOf<UInt32>() * valueCount);
                var ptr = (UInt32*)NativePointer->QueueFamilyIndices;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public BufferCreateInfo()
        {
            NativePointer = (Interop.BufferCreateInfo*)Interop.Structure.Allocate(typeof(Interop.BufferCreateInfo));
            NativePointer->SType = StructureType.BufferCreateInfo;
        }
        
        public BufferCreateInfo(DeviceSize Size, BufferUsageFlags Usage, SharingMode SharingMode, UInt32[] QueueFamilyIndices) : this()
        {
            this.Size = Size;
            this.Usage = Usage;
            this.SharingMode = SharingMode;
            this.QueueFamilyIndices = QueueFamilyIndices;
        }
    }
}
