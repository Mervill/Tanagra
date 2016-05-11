using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorSetLayoutCreateInfo
    {
        internal Interop.DescriptorSetLayoutCreateInfo* NativePointer;
        
        public DescriptorSetLayoutCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public UInt32 BindingCount
        {
            get { return NativePointer->BindingCount; }
            set { NativePointer->BindingCount = value; }
        }
        
        public DescriptorSetLayoutBinding[] Bindings
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        public DescriptorSetLayoutCreateInfo()
        {
            NativePointer = (Interop.DescriptorSetLayoutCreateInfo*)Interop.Structure.Allocate(typeof(Interop.DescriptorSetLayoutCreateInfo));
            NativePointer->SType = StructureType.DescriptorSetLayoutCreateInfo;
        }
    }
}
