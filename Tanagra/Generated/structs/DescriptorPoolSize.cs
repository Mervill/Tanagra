using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorPoolSize
    {
        internal Interop.DescriptorPoolSize* NativeHandle;
        
        public DescriptorType Type
        {
            get { return NativeHandle->Type; }
            set { NativeHandle->Type = value; }
        }
        
        public UInt32 DescriptorCount
        {
            get { return NativeHandle->DescriptorCount; }
            set { NativeHandle->DescriptorCount = value; }
        }
        
        public DescriptorPoolSize()
        {
            NativeHandle = (Interop.DescriptorPoolSize*)Interop.Structure.Allocate(typeof(Interop.DescriptorPoolSize));
        }
    }
}
