using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// [<see cref="IExtensible"/>: None]
    /// </summary>
    unsafe public class DedicatedAllocationMemoryAllocateInfoNV : IDisposable
    {
        internal Unmanaged.DedicatedAllocationMemoryAllocateInfoNV* NativePointer { get; private set; }
        
        Image _Image;
        /// <summary>
        /// Image that this allocation will be bound to (Optional)
        /// </summary>
        public Image Image
        {
            get { return _Image; }
            set { _Image = value; NativePointer->Image = value.NativePointer; }
        }
        
        Buffer _Buffer;
        /// <summary>
        /// Buffer that this allocation will be bound to (Optional)
        /// </summary>
        public Buffer Buffer
        {
            get { return _Buffer; }
            set { _Buffer = value; NativePointer->Buffer = value.NativePointer; }
        }
        
        public DedicatedAllocationMemoryAllocateInfoNV()
        {
            NativePointer = (Unmanaged.DedicatedAllocationMemoryAllocateInfoNV*)MemUtil.Alloc(typeof(Unmanaged.DedicatedAllocationMemoryAllocateInfoNV));
            NativePointer->SType = StructureType.DedicatedAllocationMemoryAllocateInfoNv;
        }
        
        internal DedicatedAllocationMemoryAllocateInfoNV(Unmanaged.DedicatedAllocationMemoryAllocateInfoNV* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.DedicatedAllocationMemoryAllocateInfoNV));
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~DedicatedAllocationMemoryAllocateInfoNV()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
