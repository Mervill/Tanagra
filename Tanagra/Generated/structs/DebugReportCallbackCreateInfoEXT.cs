using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DebugReportCallbackCreateInfoEXT
    {
        public StructureType sType;
        public IntPtr Next;
        public VkDebugReportFlagsEXT flags;
        public PFN_vkDebugReportCallbackEXT pfnCallback;
        public IntPtr UserData;
    }
}
