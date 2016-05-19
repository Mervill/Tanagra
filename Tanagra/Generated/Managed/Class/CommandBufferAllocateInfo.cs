using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CommandBufferAllocateInfo
    {
        internal Unmanaged.CommandBufferAllocateInfo* NativePointer;
        
        CommandPool _CommandPool;
        public CommandPool CommandPool
        {
            get { return _CommandPool; }
            set { _CommandPool = value; NativePointer->CommandPool = value.NativePointer; }
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
            NativePointer = (Unmanaged.CommandBufferAllocateInfo*)MemoryUtils.Allocate(typeof(Unmanaged.CommandBufferAllocateInfo));
            NativePointer->SType = StructureType.CommandBufferAllocateInfo;
        }
        
        public CommandBufferAllocateInfo(CommandPool CommandPool, CommandBufferLevel Level, UInt32 CommandBufferCount) : this()
        {
            this.CommandPool = CommandPool;
            this.Level = Level;
            this.CommandBufferCount = CommandBufferCount;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.CommandBufferAllocateInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}