using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorSetLayoutBinding
    {
        internal Interop.DescriptorSetLayoutBinding* NativePointer;
        
        /// <summary>
        /// Binding number for this entry
        /// </summary>
        public UInt32 Binding
        {
            get { return NativePointer->Binding; }
            set { NativePointer->Binding = value; }
        }
        
        /// <summary>
        /// Type of the descriptors in this binding
        /// </summary>
        public DescriptorType DescriptorType
        {
            get { return NativePointer->DescriptorType; }
            set { NativePointer->DescriptorType = value; }
        }
        
        /// <summary>
        /// Shader stages this binding is visible to
        /// </summary>
        public ShaderStageFlags StageFlags
        {
            get { return NativePointer->StageFlags; }
            set { NativePointer->StageFlags = value; }
        }
        
        /// <summary>
        /// Immutable samplers (used if descriptor type is SAMPLER or COMBINED_IMAGE_SAMPLER, is either NULL or contains count number of elements)
        /// </summary>
        public Sampler[] ImmutableSamplers
        {
            get
            {
                var valueCount = NativePointer->DescriptorCount;
                var valueArray = new Sampler[valueCount];
                var ptr = (UInt64*)NativePointer->ImmutableSamplers;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new Sampler { NativePointer = ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->DescriptorCount = (UInt32)valueCount;
                NativePointer->ImmutableSamplers = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * valueCount);
                var ptr = (IntPtr*)NativePointer->ImmutableSamplers;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = (IntPtr)value[x].NativePointer;
            }
        }
        
        public DescriptorSetLayoutBinding()
        {
            NativePointer = (Interop.DescriptorSetLayoutBinding*)Interop.Structure.Allocate(typeof(Interop.DescriptorSetLayoutBinding));
        }
        
        public DescriptorSetLayoutBinding(UInt32 Binding, DescriptorType DescriptorType, ShaderStageFlags StageFlags) : this()
        {
            this.Binding = Binding;
            this.DescriptorType = DescriptorType;
            this.StageFlags = StageFlags;
        }
    }
}
