using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SampleMask
    {
        internal Interop.SampleMask* NativePointer;
        
        public SampleMask()
        {
            NativePointer = (Interop.SampleMask*)Interop.Structure.Allocate(typeof(Interop.SampleMask));
        }
    }
}
