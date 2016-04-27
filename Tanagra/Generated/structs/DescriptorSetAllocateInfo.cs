using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorSetAllocateInfo
    {
        internal Interop.DescriptorSetAllocateInfo* NativeHandle;
        
        DescriptorPool _DescriptorPool;
        public DescriptorPool DescriptorPool
        {
            get { return _DescriptorPool; }
            set { _DescriptorPool = value; NativeHandle->DescriptorPool = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 DescriptorSetCount
        {
            get { return NativeHandle->DescriptorSetCount; }
            set { NativeHandle->DescriptorSetCount = value; }
        }
        
        DescriptorSetLayout _SetLayouts;
        public DescriptorSetLayout SetLayouts
        {
            get { return _SetLayouts; }
            set { _SetLayouts = value; NativeHandle->SetLayouts = (IntPtr)value.NativeHandle; }
        }
        
        public DescriptorSetAllocateInfo()
        {
            NativeHandle = (Interop.DescriptorSetAllocateInfo*)Interop.Structure.Allocate(typeof(Interop.DescriptorSetAllocateInfo));
            //NativeHandle->SType = StructureType.DescriptorSetAllocateInfo;
        }
    }
}
