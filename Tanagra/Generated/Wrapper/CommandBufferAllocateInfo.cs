using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CommandBufferAllocateInfo
    {
        internal Interop.CommandBufferAllocateInfo* NativePointer;
        
        CommandPool _CommandPool;
        public CommandPool CommandPool
        {
            get { return _CommandPool; }
            set { _CommandPool = value; NativePointer->CommandPool = (IntPtr)value.NativePointer; }
        }
        
        public CommandBufferLevel Level
        {
            get { return NativePointer->Level; }
            set { NativePointer->Level = value; }
        }
        
        public UInt32 CommandBufferCount
        {
            get { return NativePointer->CommandBufferCount; }
            set { NativePointer->CommandBufferCount = value; }
        }
        
        public CommandBufferAllocateInfo()
        {
            NativePointer = (Interop.CommandBufferAllocateInfo*)Interop.Structure.Allocate(typeof(Interop.CommandBufferAllocateInfo));
            NativePointer->SType = StructureType.CommandBufferAllocateInfo;
        }
    }
}
