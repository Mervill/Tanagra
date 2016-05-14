using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorSetAllocateInfo
    {
        internal Interop.DescriptorSetAllocateInfo* NativePointer;
        
        DescriptorPool _DescriptorPool;
        public DescriptorPool DescriptorPool
        {
            get { return _DescriptorPool; }
            set { _DescriptorPool = value; NativePointer->DescriptorPool = value.NativePointer; }
        }
        
        public UInt32 DescriptorSetCount
        {
            get { return NativePointer->DescriptorSetCount; }
            set { NativePointer->DescriptorSetCount = value; }
        }
        
        public DescriptorSetLayout[] SetLayouts
        {
            get
            {
                var valueCount = NativePointer->DescriptorSetCount;
                var valueArray = new DescriptorSetLayout[valueCount];
                var ptr = (UInt64*)NativePointer->SetLayouts;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new DescriptorSetLayout { NativePointer = ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->DescriptorSetCount = (uint)valueCount;
                NativePointer->SetLayouts = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * valueCount);
                var ptr = (IntPtr*)NativePointer->SetLayouts;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = (IntPtr)value[x].NativePointer;
            }
        }
        
        public DescriptorSetAllocateInfo()
        {
            NativePointer = (Interop.DescriptorSetAllocateInfo*)Interop.Structure.Allocate(typeof(Interop.DescriptorSetAllocateInfo));
            NativePointer->SType = StructureType.DescriptorSetAllocateInfo;
        }
        
        public DescriptorSetAllocateInfo(DescriptorPool DescriptorPool, UInt32 DescriptorSetCount, DescriptorSetLayout[] SetLayouts) : this()
        {
            this.DescriptorPool = DescriptorPool;
            this.DescriptorSetCount = DescriptorSetCount;
            this.SetLayouts = SetLayouts;
        }
    }
}
