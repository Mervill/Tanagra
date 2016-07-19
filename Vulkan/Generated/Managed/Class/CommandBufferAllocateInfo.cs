using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// IExtensible
    /// </summary>
    unsafe public class CommandBufferAllocateInfo : IDisposable
    {
        internal Unmanaged.CommandBufferAllocateInfo* NativePointer { get; private set; }
        
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
            NativePointer = (Unmanaged.CommandBufferAllocateInfo*)MemUtil.Alloc(typeof(Unmanaged.CommandBufferAllocateInfo));
            NativePointer->SType = StructureType.CommandBufferAllocateInfo;
        }
        
        internal CommandBufferAllocateInfo(Unmanaged.CommandBufferAllocateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.CommandBufferAllocateInfo));
        }
        
        public CommandBufferAllocateInfo(CommandPool CommandPool, CommandBufferLevel Level, UInt32 CommandBufferCount) : this()
        {
            this.CommandPool = CommandPool;
            this.Level = Level;
            this.CommandBufferCount = CommandBufferCount;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~CommandBufferAllocateInfo()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
