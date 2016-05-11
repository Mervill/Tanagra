using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class CommandBuffer
    {
        internal IntPtr NativePointer;

        public bool IsValid => NativePointer != IntPtr.Zero;

        public override string ToString() => "CommandBuffer 0x" + NativePointer.ToString("X8");
    }
}
