using System;

namespace Vulkan
{
    [Flags]
    public enum DependencyFlags
    {
        /// <summary>
        /// Dependency is per pixel region 
        /// </summary>
        DEPENDENCY_BY_REGION_BIT = 1 << 0,
    }
}
