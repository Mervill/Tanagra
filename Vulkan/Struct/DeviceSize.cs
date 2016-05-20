using System;

namespace Vulkan
{
    /// <summary>
    /// Essentially a <see cref="UInt64"/> 
    /// </summary>
    public struct DeviceSize
    {
        readonly UInt64 value;

        public DeviceSize(UInt64 value)
        {
            this.value = value;
        }

        public static implicit operator DeviceSize(UInt64 value)
            => new DeviceSize(value);

        public static implicit operator UInt64(DeviceSize size)
            => size.value;

        public override string ToString()
            => value.ToString();

        public string ToString(string format)
            => value.ToString(format);
    }
}