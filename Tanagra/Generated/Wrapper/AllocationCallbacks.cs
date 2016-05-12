using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class AllocationCallbacks
    {
        internal Interop.AllocationCallbacks* NativePointer;
        
        public IntPtr UserData
        {
            get { return NativePointer->UserData; }
            set { NativePointer->UserData = value; }
        }
        
        public IntPtr PfnAllocation
        {
            get { return NativePointer->PfnAllocation; }
            set { NativePointer->PfnAllocation = value; }
        }
        
        public IntPtr PfnReallocation
        {
            get { return NativePointer->PfnReallocation; }
            set { NativePointer->PfnReallocation = value; }
        }
        
        public IntPtr PfnFree
        {
            get { return NativePointer->PfnFree; }
            set { NativePointer->PfnFree = value; }
        }
        
        public IntPtr PfnInternalAllocation
        {
            get { return NativePointer->PfnInternalAllocation; }
            set { NativePointer->PfnInternalAllocation = value; }
        }
        
        public IntPtr PfnInternalFree
        {
            get { return NativePointer->PfnInternalFree; }
            set { NativePointer->PfnInternalFree = value; }
        }
        
        public AllocationCallbacks()
        {
            NativePointer = (Interop.AllocationCallbacks*)Interop.Structure.Allocate(typeof(Interop.AllocationCallbacks));
        }
    }
}
