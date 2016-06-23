using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class CommandPoolCreateInfo : IDisposable
    {
        internal Unmanaged.CommandPoolCreateInfo* NativePointer { get; private set; }
        
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
            NativePointer = (Unmanaged.CommandPoolCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.CommandPoolCreateInfo));
            NativePointer->SType = StructureType.CommandPoolCreateInfo;
        }
        
        internal CommandPoolCreateInfo(Unmanaged.CommandPoolCreateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.CommandPoolCreateInfo));
        }
        
        public CommandPoolCreateInfo(UInt32 QueueFamilyIndex) : this()
        {
            this.QueueFamilyIndex = QueueFamilyIndex;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~CommandPoolCreateInfo()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
