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

    unsafe public struct Extent2D
    {
        public UInt32 Width;
        public UInt32 Height;
    }

    public struct DeviceSize
    {
        UInt64 value;

        public static implicit operator DeviceSize(UInt64 iValue)
        {
            return new DeviceSize { value = iValue };
        }

        public static implicit operator UInt64(DeviceSize size)
        {
            return size.value;
        }
    }
}
