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
            NativePointer = (Unmanaged.AllocationCallbacks*)MemUtil.Alloc(typeof(Unmanaged.AllocationCallbacks));
        }
        
        internal AllocationCallbacks(Unmanaged.AllocationCallbacks* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.AllocationCallbacks));
        }
        
        public AllocationCallbacks(IntPtr Allocation, IntPtr Reallocation, IntPtr Free) : this()
        {
            this.Allocation = Allocation;
            this.Reallocation = Reallocation;
            this.Free = Free;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~AllocationCallbacks()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
