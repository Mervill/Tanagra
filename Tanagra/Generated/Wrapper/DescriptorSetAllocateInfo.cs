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
        
        DescriptorSetLayout _SetLayouts;
        public DescriptorSetLayout SetLayouts
        {
            get { return _SetLayouts; }
            set { _SetLayouts = value; NativePointer->SetLayouts = value.NativePointer; }
        }
        
        public DescriptorSetAllocateInfo()
        {
            NativePointer = (Interop.DescriptorSetAllocateInfo*)Interop.Structure.Allocate(typeof(Interop.DescriptorSetAllocateInfo));
            NativePointer->SType = StructureType.DescriptorSetAllocateInfo;
        }
    }
}
