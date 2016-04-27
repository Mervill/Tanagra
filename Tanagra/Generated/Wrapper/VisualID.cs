using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class VisualID
    {
        internal Interop.VisualID* NativeHandle;
        
        public VisualID()
        {
            NativeHandle = (Interop.VisualID*)Interop.Structure.Allocate(typeof(Interop.VisualID));
        }
    }
}
