using System;

namespace Vulkan
{
    [Flags]
    public enum DependencyFlags
    {
        /// <summary>
        /// Dependency is per pixel region 
        /// </summary>
        ByRegion = 1 << 0,
    }
}
