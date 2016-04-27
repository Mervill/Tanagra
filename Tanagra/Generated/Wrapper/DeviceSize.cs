using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DeviceSize
    {
        internal Interop.DeviceSize* NativeHandle;
        
        public DeviceSize()
        {
            NativeHandle = (Interop.DeviceSize*)Interop.Structure.Allocate(typeof(Interop.DeviceSize));
        }
    }
}
