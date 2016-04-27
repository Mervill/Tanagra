using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class FenceCreateInfo
    {
        internal Interop.FenceCreateInfo* NativeHandle;
        
        public FenceCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public FenceCreateInfo()
        {
            NativeHandle = (Interop.FenceCreateInfo*)Interop.Structure.Allocate(typeof(Interop.FenceCreateInfo));
            //NativeHandle->SType = StructureType.FenceCreateInfo;
        }
    }
}
