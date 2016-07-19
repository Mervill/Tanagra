using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// IExtensible
    /// </summary>
    unsafe public class FenceCreateInfo : IDisposable
    {
        internal Unmanaged.FenceCreateInfo* NativePointer { get; private set; }
        
        /// <summary>
        /// Fence creation flags (Optional)
        /// </summary>
        public FenceCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public FenceCreateInfo()
        {
            NativePointer = (Unmanaged.FenceCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.FenceCreateInfo));
            NativePointer->SType = StructureType.FenceCreateInfo;
        }
        
        internal FenceCreateInfo(Unmanaged.FenceCreateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.FenceCreateInfo));
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~FenceCreateInfo()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
