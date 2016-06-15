using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DeviceCreateInfo
    {
        /// <summary>
        /// Should be VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public DeviceCreateFlags Flags;
        public UInt32 QueueCreateInfoCount;
        public IntPtr QueueCreateInfos;
        public UInt32 EnabledLayerCount;
        /// <summary>
        /// Ordered list of layer names to be enabled
        /// </summary>
        public IntPtr EnabledLayerNames;
        public UInt32 EnabledExtensionCount;
        public IntPtr EnabledExtensionNames;
        public IntPtr EnabledFeatures;
    }
}
