using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ComponentMapping
    {
        public ComponentSwizzle R;
        public ComponentSwizzle G;
        public ComponentSwizzle B;
        public ComponentSwizzle A;
        
        public ComponentMapping(ComponentSwizzle R, ComponentSwizzle G, ComponentSwizzle B, ComponentSwizzle A)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = A;
        }
    }
}
