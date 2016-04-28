using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class FenceCreateInfo
    {
        internal Interop.FenceCreateInfo* NativePointer;
        
        public FenceCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public FenceCreateInfo()
        {
            NativePointer = (Interop.FenceCreateInfo*)Interop.Structure.Allocate(typeof(Interop.FenceCreateInfo));
            //NativePointer->SType = StructureType.FenceCreateInfo;
        }
    }
}