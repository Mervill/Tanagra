using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RenderPass
    {
        public readonly static RenderPass Null = new RenderPass();
        
        internal IntPtr NativeHandle;
        
    }
}
