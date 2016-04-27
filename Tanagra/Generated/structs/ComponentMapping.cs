using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ComponentMapping
    {
        internal Interop.ComponentMapping* NativeHandle;
        
        public ComponentSwizzle R
        {
            get { return NativeHandle->R; }
            set { NativeHandle->R = value; }
        }
        
        public ComponentSwizzle G
        {
            get { return NativeHandle->G; }
            set { NativeHandle->G = value; }
        }
        
        public ComponentSwizzle B
        {
            get { return NativeHandle->B; }
            set { NativeHandle->B = value; }
        }
        
        public ComponentSwizzle A
        {
            get { return NativeHandle->A; }
            set { NativeHandle->A = value; }
        }
        
        public ComponentMapping()
        {
            NativeHandle = (Interop.ComponentMapping*)Interop.Structure.Allocate(typeof(Interop.ComponentMapping));
        }
    }
}
