using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Device"/>.
    /// </summary>
    public class Event
    {
        internal UInt64 NativePointer;
        
        internal Event()
        {
        }
        
        internal Event(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "Event 0x" + NativePointer.ToString("X8");
    }
}
