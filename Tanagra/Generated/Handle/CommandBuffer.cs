using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class CommandBuffer
    {
        internal IntPtr NativePointer;

        public bool IsValid => NativePointer != IntPtr.Zero;

        public override string ToString() => NativePointer.ToString("X8");
    }
}
