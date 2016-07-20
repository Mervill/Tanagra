using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// [<see cref="IExtensible"/>: None]
    /// </summary>
    unsafe public class EventCreateInfo : IDisposable
    {
        internal Unmanaged.EventCreateInfo* NativePointer { get; private set; }
        
        /// <summary>
        /// Event creation flags (Optional)
        /// </summary>
        public EventCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public EventCreateInfo()
        {
            NativePointer = (Unmanaged.EventCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.EventCreateInfo));
            NativePointer->SType = StructureType.EventCreateInfo;
        }
        
        internal EventCreateInfo(Unmanaged.EventCreateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.EventCreateInfo));
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~EventCreateInfo()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
