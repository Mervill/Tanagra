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
        
        public ShaderStageFlags StageFlags
        {
            get { return NativePointer->StageFlags; }
            set { NativePointer->StageFlags = value; }
        }
        
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
