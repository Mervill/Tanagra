using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DeviceCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public DeviceCreateFlags flags;
        public UInt32 queueCreateInfoCount;
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.ByValArray, SizeParamIndex = 3)]
        public DeviceQueueCreateInfo[] pQueueCreateInfos;
        public UInt32 enabledLayerCount;
        public String ppEnabledLayerNames;
        public UInt32 enabledExtensionCount;
        public String ppEnabledExtensionNames;
        public PhysicalDeviceFeatures pEnabledFeatures;
    }
}
