using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DescriptorSet
    {
        public readonly static DescriptorSet Null = new DescriptorSet();
        
        internal IntPtr NativeHandle;
        
    }
}
