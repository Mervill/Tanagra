using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class FenceCreateInfo : IDisposable
    {
        internal Unmanaged.FenceCreateInfo* NativePointer;
        
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
        
        public void Dispose()
        {
            MemUtil.Free((IntPtr)NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~FenceCreateInfo()
        {
            if(NativePointer != null)
            {
                MemUtil.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
