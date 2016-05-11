using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class Image
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "Image 0x" + NativePointer.ToString("X8");
    }
}
