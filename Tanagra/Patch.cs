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

    public struct Bool32
    {
        UInt32 value;

        public Bool32(bool bValue)
        {
            value = bValue ? 1u : 0;
        }

        public static implicit operator Bool32(bool bValue)
            => new Bool32(bValue);

        public static implicit operator bool(Bool32 bValue)
            => bValue.value == 0 ? false : true;

        public override string ToString()
            => value == 0 ? "False" : "True";
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
