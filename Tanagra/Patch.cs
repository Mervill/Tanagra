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

    /// <summary>
    /// Boolean explicitly backed by <see cref="UInt32"/>
    /// </summary>
    public struct Bool32
    {
        UInt32 value;

        public Bool32(bool boolValue)
        {
            value = boolValue ? 1U : 0U;
        }

        public static implicit operator Bool32(bool boolValue)
            => new Bool32(boolValue);

        public static implicit operator bool(Bool32 bool32)
            => bool32.value == 0 ? false : true;

        public override string ToString()
            => value == 0 ? "False" : "True";
    }

    public struct DeviceSize
    {
        UInt64 value;

        public static implicit operator DeviceSize(UInt64 iValue)
            => new DeviceSize { value = iValue };

        public static implicit operator UInt64(DeviceSize size)
            => size.value;

        public override string ToString()
            => value.ToString();
    }
}
