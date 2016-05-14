using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CommandPoolCreateInfo
    {
        internal Interop.CommandPoolCreateInfo* NativePointer;
        
        public CommandPoolCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public UInt32 QueueFamilyIndex
        {
            get { return NativePointer->QueueFamilyIndex; }
            set { NativePointer->QueueFamilyIndex = value; }
        }
        
        public CommandPoolCreateInfo()
        {
            NativePointer = (Interop.CommandPoolCreateInfo*)Interop.Structure.Allocate(typeof(Interop.CommandPoolCreateInfo));
            NativePointer->SType = StructureType.CommandPoolCreateInfo;
        }
        
        public CommandPoolCreateInfo(UInt32 QueueFamilyIndex) : this()
        {
            this.QueueFamilyIndex = QueueFamilyIndex;
        }
    }
}
