using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// [<see cref="IExtensible"/>: None]
    /// </summary>
    unsafe public class DedicatedAllocationBufferCreateInfoNV : IDisposable
    {
        internal Unmanaged.DedicatedAllocationBufferCreateInfoNV* NativePointer { get; private set; }
        
        /// <summary>
        /// Whether this buffer uses a dedicated allocation
        /// </summary>
        public Bool32 DedicatedAllocation
        {
            get { return NativePointer->DedicatedAllocation; }
            set { NativePointer->DedicatedAllocation = value; }
        }
        
        public DedicatedAllocationBufferCreateInfoNV()
        {
            NativePointer = (Unmanaged.DedicatedAllocationBufferCreateInfoNV*)MemUtil.Alloc(typeof(Unmanaged.DedicatedAllocationBufferCreateInfoNV));
            NativePointer->SType = StructureType.DedicatedAllocationBufferCreateInfoNV;
        }
        
        internal DedicatedAllocationBufferCreateInfoNV(Unmanaged.DedicatedAllocationBufferCreateInfoNV* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.DedicatedAllocationBufferCreateInfoNV));
        }
        
        /// <param name="DedicatedAllocation">Whether this buffer uses a dedicated allocation</param>
        public DedicatedAllocationBufferCreateInfoNV(Bool32 DedicatedAllocation) : this()
        {
            this.DedicatedAllocation = DedicatedAllocation;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~DedicatedAllocationBufferCreateInfoNV()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
