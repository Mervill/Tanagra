using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Device"/>.
    /// </summary>
    public class ImageView
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "ImageView 0x" + NativePointer.ToString("X8");
    }
}
