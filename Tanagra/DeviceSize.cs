using System;

namespace Vulkan
{
    public struct DeviceSize
    {
        UInt64 value;

        public static implicit operator DeviceSize(UInt64 iValue)
            => new DeviceSize { value = iValue };

        public static implicit operator UInt64(DeviceSize size)
            => size.value;

        public override string ToString()
            => value.ToString();

        public string ToString(string format)
            => value.ToString(format);
    }
}