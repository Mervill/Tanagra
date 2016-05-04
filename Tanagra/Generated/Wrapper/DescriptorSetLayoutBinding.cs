using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorSetLayoutBinding
    {
        internal Interop.DescriptorSetLayoutBinding* NativePointer;
        
        public UInt32 Binding
        {
            get { return NativePointer->Binding; }
            set { NativePointer->Binding = value; }
        }
        
        public DescriptorType DescriptorType
        {
            get { return NativePointer->DescriptorType; }
            set { NativePointer->DescriptorType = value; }
        }
        
        public UInt32 DescriptorCount
        {
            get { return NativePointer->DescriptorCount; }
            set { NativePointer->DescriptorCount = value; }
        }
        
        public ShaderStageFlags StageFlags
        {
            get { return NativePointer->StageFlags; }
            set { NativePointer->StageFlags = value; }
        }
        
        Sampler _ImmutableSamplers;
        public Sampler ImmutableSamplers
        {
            get { return _ImmutableSamplers; }
            set { _ImmutableSamplers = value; NativePointer->ImmutableSamplers = value.NativePointer; }
        }
        
        public DescriptorSetLayoutBinding()
        {
            NativePointer = (Interop.DescriptorSetLayoutBinding*)Interop.Structure.Allocate(typeof(Interop.DescriptorSetLayoutBinding));
        }
    }
}
