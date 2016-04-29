using System;

namespace Vulkan
{
    [Flags]
    public enum ImageCreateFlags
    {
        /// <summary>
        /// Image should support sparse backing
        /// </summary>
        SparseBinding = 1 << 0,
        /// <summary>
        /// Image should support sparse backing with partial residency
        /// </summary>
        SparseResidency = 1 << 1,
        /// <summary>
        /// Image should support constent data access to physical memory ranges mapped into multiple locations of sparse images
        /// </summary>
        SparseAliased = 1 << 2,
        /// <summary>
        /// Allows image views to have different format than the base image
        /// </summary>
        MutableFormat = 1 << 3,
        /// <summary>
        /// Allows creating image views with cube type from the created image
        /// </summary>
        CubeCompatible = 1 << 4,
    }
}
