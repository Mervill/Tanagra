using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CommandBufferAllocateInfo
    {
        internal Interop.CommandBufferAllocateInfo* NativeHandle;
        
        CommandPool _CommandPool;
        public CommandPool CommandPool
        {
            get { return _CommandPool; }
            set { _CommandPool = value; NativeHandle->CommandPool = (IntPtr)value.NativeHandle; }
        }
        
        public CommandBufferLevel Level
        {
            get { return NativeHandle->Level; }
            set { NativeHandle->Level = value; }
        }
        
        public UInt32 CommandBufferCount
        {
            get { return NativeHandle->CommandBufferCount; }
            set { NativeHandle->CommandBufferCount = value; }
        }
        
        public CommandBufferAllocateInfo()
        {
            NativeHandle = (Interop.CommandBufferAllocateInfo*)Interop.Structure.Allocate(typeof(Interop.CommandBufferAllocateInfo));
            //NativeHandle->SType = StructureType.CommandBufferAllocateInfo;
        }
    }
}
