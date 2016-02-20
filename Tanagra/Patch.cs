using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vulkan
{
    // function pointers (delegates)
    public struct PFN_vkAllocationFunction { }
    public struct PFN_vkReallocationFunction { }
    public struct PFN_vkFreeFunction { }
    public struct PFN_vkInternalAllocationNotification { }
    public struct PFN_vkInternalFreeNotification { }
    public struct PFN_vkDebugReportCallbackEXT { }
    public struct PFN_vkVoidFunction { }

    public enum VkSurfaceTransformFlagsKHR { }
    public enum VkDisplayPlaneAlphaFlagsKHR { }
    public enum VkCompositeAlphaFlagsKHR { }
    public enum VkDebugReportFlagsEXT { }
}
