using System;

namespace Vulkan
{
    /// <summary>
    /// Boolean explicitly backed by <see cref="UInt32"/>
    /// </summary>
    public struct Bool32
    {
        readonly UInt32 value;

        public Bool32(bool boolValue)
        {
            value = boolValue ? 1U : 0U;
        }

        public static implicit operator Bool32(bool boolValue)
            => new Bool32(boolValue);

        public static implicit operator bool(Bool32 bool32)
            => bool32.value != 0;

        public override string ToString()
            => value == 0 ? "False" : "True";
    }
}