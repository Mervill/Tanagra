using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ComponentMapping
    {
        public ComponentSwizzle r;
        public ComponentSwizzle g;
        public ComponentSwizzle b;
        public ComponentSwizzle a;
    }
}
