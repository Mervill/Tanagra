using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ComponentMapping
    {
        internal Interop.ComponentMapping* NativePointer;
        
        public ComponentSwizzle R
        {
            get { return NativePointer->R; }
            set { NativePointer->R = value; }
        }
        
        public ComponentSwizzle G
        {
            get { return NativePointer->G; }
            set { NativePointer->G = value; }
        }
        
        public ComponentSwizzle B
        {
            get { return NativePointer->B; }
            set { NativePointer->B = value; }
        }
        
        public ComponentSwizzle A
        {
            get { return NativePointer->A; }
            set { NativePointer->A = value; }
        }
        
        public ComponentMapping()
        {
            NativePointer = (Interop.ComponentMapping*)Interop.Structure.Allocate(typeof(Interop.ComponentMapping));
        }
    }
}
