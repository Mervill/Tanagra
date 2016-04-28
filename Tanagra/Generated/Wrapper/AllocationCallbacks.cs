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
        
        PFN_vkAllocationFunction _PfnAllocation;
        public PFN_vkAllocationFunction PfnAllocation
        {
            get { return _PfnAllocation; }
            set { _PfnAllocation = value; NativePointer->PfnAllocation = (IntPtr)value.NativePointer; }
        }
        
        PFN_vkReallocationFunction _PfnReallocation;
        public PFN_vkReallocationFunction PfnReallocation
        {
            get { return _PfnReallocation; }
            set { _PfnReallocation = value; NativePointer->PfnReallocation = (IntPtr)value.NativePointer; }
        }
        
        PFN_vkFreeFunction _PfnFree;
        public PFN_vkFreeFunction PfnFree
        {
            get { return _PfnFree; }
            set { _PfnFree = value; NativePointer->PfnFree = (IntPtr)value.NativePointer; }
        }
        
        PFN_vkInternalAllocationNotification _PfnInternalAllocation;
        public PFN_vkInternalAllocationNotification PfnInternalAllocation
        {
            get { return _PfnInternalAllocation; }
            set { _PfnInternalAllocation = value; NativePointer->PfnInternalAllocation = (IntPtr)value.NativePointer; }
        }
        
        PFN_vkInternalFreeNotification _PfnInternalFree;
        public PFN_vkInternalFreeNotification PfnInternalFree
        {
            get { return _PfnInternalFree; }
            set { _PfnInternalFree = value; NativePointer->PfnInternalFree = (IntPtr)value.NativePointer; }
        }
        
        public AllocationCallbacks()
        {
            NativePointer = (Interop.AllocationCallbacks*)Interop.Structure.Allocate(typeof(Interop.AllocationCallbacks));
        }
    }
}
