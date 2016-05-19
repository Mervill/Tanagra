using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CommandPoolCreateInfo
    {
        internal Unmanaged.CommandPoolCreateInfo* NativePointer;
        
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
            NativePointer = (Unmanaged.CommandPoolCreateInfo*)MemoryUtils.Allocate(typeof(Unmanaged.CommandPoolCreateInfo));
            NativePointer->SType = StructureType.CommandPoolCreateInfo;
        }
        
        public CommandPoolCreateInfo(UInt32 QueueFamilyIndex) : this()
        {
            this.QueueFamilyIndex = QueueFamilyIndex;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.CommandPoolCreateInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
