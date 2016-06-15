using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AllocationCallbacks
    {
        public IntPtr UserData;
        public IntPtr Allocation;
        public IntPtr Reallocation;
        public IntPtr Free;
        public IntPtr InternalAllocation;
        public IntPtr InternalFree;
    }
}
