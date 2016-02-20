using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AllocationCallbacks
    {
        public IntPtr pUserData;
        public PFN_vkAllocationFunction pfnAllocation;
        public PFN_vkReallocationFunction pfnReallocation;
        public PFN_vkFreeFunction pfnFree;
        public PFN_vkInternalAllocationNotification pfnInternalAllocation;
        public PFN_vkInternalFreeNotification pfnInternalFree;
    }
}
