using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InstanceCreateInfo
    {
        /// <summary>
        /// Should be VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public InstanceCreateFlags Flags;
        public IntPtr ApplicationInfo;
        public UInt32 EnabledLayerCount;
        /// <summary>
        /// Ordered list of layer names to be enabled
        /// </summary>
        public IntPtr EnabledLayerNames;
        public UInt32 EnabledExtensionCount;
        /// <summary>
        /// Extension names to be enabled
        /// </summary>
        public IntPtr EnabledExtensionNames;
    }
}
