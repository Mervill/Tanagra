using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Device"/>.
    /// </summary>
    public class BufferView
    {
        internal UInt64 NativePointer;
        
        internal BufferView()
        {
        }
        
        internal BufferView(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "BufferView 0x" + NativePointer.ToString("X8");
    }
}
