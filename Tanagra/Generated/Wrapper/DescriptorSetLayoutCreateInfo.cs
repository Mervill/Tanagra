using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorSetLayoutCreateInfo
    {
        internal Interop.DescriptorSetLayoutCreateInfo* NativeHandle;
        
        public DescriptorSetLayoutCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public UInt32 BindingCount
        {
            get { return NativeHandle->BindingCount; }
            set { NativeHandle->BindingCount = value; }
        }
        
        DescriptorSetLayoutBinding _Bindings;
        public DescriptorSetLayoutBinding Bindings
        {
            get { return _Bindings; }
            set { _Bindings = value; NativeHandle->Bindings = (IntPtr)value.NativeHandle; }
        }
        
        public DescriptorSetLayoutCreateInfo()
        {
            NativeHandle = (Interop.DescriptorSetLayoutCreateInfo*)Interop.Structure.Allocate(typeof(Interop.DescriptorSetLayoutCreateInfo));
            //NativeHandle->SType = StructureType.DescriptorSetLayoutCreateInfo;
        }
    }
}
