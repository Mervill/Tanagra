using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class ImageView
    {
        internal UInt64 NativePointer;

        public override string ToString() => nameof(ImageView) + " " + NativePointer.ToString("X8");
    }
}
