using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SampleMask
    {
        internal Interop.SampleMask* NativeHandle;
        
        public SampleMask()
        {
            NativeHandle = (Interop.SampleMask*)Interop.Structure.Allocate(typeof(Interop.SampleMask));
        }
    }
}
