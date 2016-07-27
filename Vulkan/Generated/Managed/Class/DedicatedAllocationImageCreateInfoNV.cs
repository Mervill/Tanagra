using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// [<see cref="IExtensible"/>: None]
    /// </summary>
    unsafe public class DedicatedAllocationImageCreateInfoNV : IDisposable
    {
        internal Unmanaged.DedicatedAllocationImageCreateInfoNV* NativePointer { get; private set; }
        
        /// <summary>
        /// Whether this image uses a dedicated allocation
        /// </summary>
        public Bool32 DedicatedAllocation
        {
            get { return NativePointer->DedicatedAllocation; }
            set { NativePointer->DedicatedAllocation = value; }
        }
        
        public DedicatedAllocationImageCreateInfoNV()
        {
            NativePointer = (Unmanaged.DedicatedAllocationImageCreateInfoNV*)MemUtil.Alloc(typeof(Unmanaged.DedicatedAllocationImageCreateInfoNV));
            NativePointer->SType = StructureType.DedicatedAllocationImageCreateInfoNV;
        }
        
        internal DedicatedAllocationImageCreateInfoNV(Unmanaged.DedicatedAllocationImageCreateInfoNV* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.DedicatedAllocationImageCreateInfoNV));
        }
        
        /// <param name="DedicatedAllocation">Whether this image uses a dedicated allocation</param>
        public DedicatedAllocationImageCreateInfoNV(Bool32 DedicatedAllocation) : this()
        {
            this.DedicatedAllocation = DedicatedAllocation;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~DedicatedAllocationImageCreateInfoNV()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
