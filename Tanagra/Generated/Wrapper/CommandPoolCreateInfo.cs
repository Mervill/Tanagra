using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CommandPoolCreateInfo
    {
        internal Interop.CommandPoolCreateInfo* NativePointer;
        
        /// <summary>
        /// Command pool creation flags (Optional)
        /// </summary>
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
            NativePointer = (Interop.CommandPoolCreateInfo*)MemoryUtils.Allocate(typeof(Interop.CommandPoolCreateInfo));
            NativePointer->SType = StructureType.CommandPoolCreateInfo;
        }
        
        public CommandPoolCreateInfo(UInt32 QueueFamilyIndex) : this()
        {
            this.QueueFamilyIndex = QueueFamilyIndex;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.CommandPoolCreateInfo*)IntPtr.Zero;
        }
    }
}
