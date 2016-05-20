using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class AllocationCallbacks : IDisposable
    {
        internal Unmanaged.AllocationCallbacks* NativePointer;
        
        public IntPtr UserData
        {
            get { return NativePointer->UserData; }
            set { NativePointer->UserData = value; }
        }
        
        public IntPtr Allocation
        {
            get { return NativePointer->Allocation; }
            set { NativePointer->Allocation = value; }
        }
        
        public IntPtr Reallocation
        {
            get { return NativePointer->Reallocation; }
            set { NativePointer->Reallocation = value; }
        }
        
        public IntPtr Free
        {
            get { return NativePointer->Free; }
            set { NativePointer->Free = value; }
        }
        
        public IntPtr InternalAllocation
        {
            get { return NativePointer->InternalAllocation; }
            set { NativePointer->InternalAllocation = value; }
        }
        
        public IntPtr InternalFree
        {
            get { return NativePointer->InternalFree; }
            set { NativePointer->InternalFree = value; }
        }
        
        public AllocationCallbacks()
        {
            NativePointer = (Unmanaged.AllocationCallbacks*)MemoryUtils.Allocate(typeof(Unmanaged.AllocationCallbacks));
        }
        
        public AllocationCallbacks(IntPtr Allocation, IntPtr Reallocation, IntPtr Free) : this()
        {
            this.Allocation = Allocation;
            this.Reallocation = Reallocation;
            this.Free = Free;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.AllocationCallbacks*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
        
        ~AllocationCallbacks()
        {
            if(NativePointer != (Unmanaged.AllocationCallbacks*)IntPtr.Zero)
            {
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = (Unmanaged.AllocationCallbacks*)IntPtr.Zero;
            }
        }
    }
}
