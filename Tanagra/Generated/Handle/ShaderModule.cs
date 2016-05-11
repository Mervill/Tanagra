using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class ShaderModule
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "ShaderModule 0x" + NativePointer.ToString("X8");
    }
}
