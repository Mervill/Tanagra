using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CommandPoolCreateInfo
    {
        internal Interop.CommandPoolCreateInfo* NativeHandle;
        
        public CommandPoolCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public UInt32 QueueFamilyIndex
        {
            get { return NativeHandle->QueueFamilyIndex; }
            set { NativeHandle->QueueFamilyIndex = value; }
        }
        
        public CommandPoolCreateInfo()
        {
            NativeHandle = (Interop.CommandPoolCreateInfo*)Interop.Structure.Allocate(typeof(Interop.CommandPoolCreateInfo));
            //NativeHandle->SType = StructureType.CommandPoolCreateInfo;
        }
    }
}
