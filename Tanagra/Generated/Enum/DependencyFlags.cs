using System;

namespace Vulkan
{
    [Flags]
    public enum DependencyFlags
    {
        None = 0,
        /// <summary>
        /// Dependency is per pixel region 
        /// </summary>
        ByRegion = 1 << 0,
    }
}
