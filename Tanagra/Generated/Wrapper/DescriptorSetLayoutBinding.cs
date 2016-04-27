using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorSetLayoutBinding
    {
        internal Interop.DescriptorSetLayoutBinding* NativeHandle;
        
        public UInt32 Binding
        {
            get { return NativeHandle->Binding; }
            set { NativeHandle->Binding = value; }
        }
        
        public DescriptorType DescriptorType
        {
            get { return NativeHandle->DescriptorType; }
            set { NativeHandle->DescriptorType = value; }
        }
        
        public UInt32 DescriptorCount
        {
            get { return NativeHandle->DescriptorCount; }
            set { NativeHandle->DescriptorCount = value; }
        }
        
        public ShaderStageFlags StageFlags
        {
            get { return NativeHandle->StageFlags; }
            set { NativeHandle->StageFlags = value; }
        }
        
        Sampler _ImmutableSamplers;
        public Sampler ImmutableSamplers
        {
            get { return _ImmutableSamplers; }
            set { _ImmutableSamplers = value; NativeHandle->ImmutableSamplers = (IntPtr)value.NativeHandle; }
        }
        
        public DescriptorSetLayoutBinding()
        {
            NativeHandle = (Interop.DescriptorSetLayoutBinding*)Interop.Structure.Allocate(typeof(Interop.DescriptorSetLayoutBinding));
        }
    }
}
