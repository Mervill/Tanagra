using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vulkan
{
    public struct Version
    {
        public uint Major => value >> 22;
        public uint Minor => (value >> 12) & 0x3FF;
        public uint Patch => value & 0xFFF;

        readonly uint value;

        public Version(uint major, uint minor, uint patch)
        {
            value = major << 22 | minor << 12 | patch;
        }

        public Version(uint versionCode)
        {
            value = versionCode;
        }
        
        public static implicit operator uint(Version version)
            => version.value;

        public static implicit operator Version(uint version)
            => new Version(version);

        public override string ToString()
            => $"{Major}.{Minor}.{Patch}";

        public string ToString(bool hex)
            => $"{Major}.{Minor}.{Patch} ({value.ToString("X8")})";
    }
}
