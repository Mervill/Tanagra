using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DeviceQueueCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public DeviceQueueCreateFlags flags;
        public UInt32 queueFamilyIndex;
        public UInt32 queueCount;
        public Single* pQueuePriorities;
    }
}
