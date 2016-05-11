using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class Event
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "Event 0x" + NativePointer.ToString("X8");
    }
}
