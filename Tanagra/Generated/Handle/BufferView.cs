using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class BufferView
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "BufferView 0x" + NativePointer.ToString("X8");
    }
}
