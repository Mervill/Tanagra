using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorPoolSize
    {
        internal Interop.DescriptorPoolSize* NativePointer;
        
        public DescriptorType Type
        {
            get { return NativePointer->Type; }
            set { NativePointer->Type = value; }
        }
        
        public UInt32 DescriptorCount
        {
            get { return NativePointer->DescriptorCount; }
            set { NativePointer->DescriptorCount = value; }
        }
        
        public DescriptorPoolSize()
        {
            NativePointer = (Interop.DescriptorPoolSize*)Interop.Structure.Allocate(typeof(Interop.DescriptorPoolSize));
        }
    }
}
