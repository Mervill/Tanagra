using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CommandBuffer
    {
        public readonly static CommandBuffer Null = new CommandBuffer();
        
        internal IntPtr NativeHandle;

        public override string ToString() => NativeHandle.ToString();
    }
}
