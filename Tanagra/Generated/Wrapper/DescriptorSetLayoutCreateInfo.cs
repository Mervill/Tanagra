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
                var valueCount = NativePointer->BindingCount;
                var valueArray = new DescriptorSetLayoutBinding[valueCount];
                var ptr = (Interop.DescriptorSetLayoutBinding*)NativePointer->Bindings;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new DescriptorSetLayoutBinding { NativePointer = &ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->BindingCount = (uint)valueCount;
                NativePointer->Bindings = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.DescriptorSetLayoutBinding>() * valueCount);
                var ptr = (Interop.DescriptorSetLayoutBinding*)NativePointer->Bindings;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = *value[x].NativePointer;
            }
        }
        
        public DescriptorSetLayoutCreateInfo()
        {
            NativePointer = (Interop.DescriptorSetLayoutCreateInfo*)Interop.Structure.Allocate(typeof(Interop.DescriptorSetLayoutCreateInfo));
            NativePointer->SType = StructureType.DescriptorSetLayoutCreateInfo;
        }
    }
}
