using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class VisualID
    {
        internal Interop.VisualID* NativePointer;
        
        public VisualID()
        {
            NativePointer = (Interop.VisualID*)Interop.Structure.Allocate(typeof(Interop.VisualID));
        }
    }
}
