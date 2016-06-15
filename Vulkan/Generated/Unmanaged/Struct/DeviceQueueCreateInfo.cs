using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DeviceQueueCreateInfo
    {
        /// <summary>
        /// Should be VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public DeviceQueueCreateFlags Flags;
        public UInt32 QueueFamilyIndex;
        public UInt32 QueueCount;
        public IntPtr QueuePriorities;
    }
}
