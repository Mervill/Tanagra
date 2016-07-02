using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Device"/>.
    /// </summary>
    public class ShaderModule
    {
        internal UInt64 NativePointer;
        
        internal ShaderModule()
        {
        }
        
        internal ShaderModule(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "ShaderModule 0x" + NativePointer.ToString("X8");
    }
}
