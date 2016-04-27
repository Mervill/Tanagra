using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class AllocationCallbacks
    {
        internal Interop.AllocationCallbacks* NativeHandle;
        
        public IntPtr UserData
        {
            get { return NativeHandle->UserData; }
            set { NativeHandle->UserData = value; }
        }
        
        PFN_vkAllocationFunction _PfnAllocation;
        public PFN_vkAllocationFunction PfnAllocation
        {
            get { return _PfnAllocation; }
            set { _PfnAllocation = value; NativeHandle->PfnAllocation = (IntPtr)value.NativeHandle; }
        }
        
        PFN_vkReallocationFunction _PfnReallocation;
        public PFN_vkReallocationFunction PfnReallocation
        {
            get { return _PfnReallocation; }
            set { _PfnReallocation = value; NativeHandle->PfnReallocation = (IntPtr)value.NativeHandle; }
        }
        
        PFN_vkFreeFunction _PfnFree;
        public PFN_vkFreeFunction PfnFree
        {
            get { return _PfnFree; }
            set { _PfnFree = value; NativeHandle->PfnFree = (IntPtr)value.NativeHandle; }
        }
        
        PFN_vkInternalAllocationNotification _PfnInternalAllocation;
        public PFN_vkInternalAllocationNotification PfnInternalAllocation
        {
            get { return _PfnInternalAllocation; }
            set { _PfnInternalAllocation = value; NativeHandle->PfnInternalAllocation = (IntPtr)value.NativeHandle; }
        }
        
        PFN_vkInternalFreeNotification _PfnInternalFree;
        public PFN_vkInternalFreeNotification PfnInternalFree
        {
            get { return _PfnInternalFree; }
            set { _PfnInternalFree = value; NativeHandle->PfnInternalFree = (IntPtr)value.NativeHandle; }
        }
        
        public AllocationCallbacks()
        {
            NativeHandle = (Interop.AllocationCallbacks*)Interop.Structure.Allocate(typeof(Interop.AllocationCallbacks));
        }
    }
}
