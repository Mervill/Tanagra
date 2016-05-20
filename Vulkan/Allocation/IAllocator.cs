using System;

namespace Vulkan.Allocation
{
    /// <summary>
    /// Can be used to override Vulkan's default memory allocation behaviour
    /// </summary>
    public interface IAllocator
    {
        /// <summary>
        /// Called when Vulkan requires some memory to be allocated
        /// </summary>
        /// <param name="userData"></param>
        /// <param name="size"></param>
        /// <param name="alignment"></param>
        /// <param name="allocationScope"></param>
        /// <returns></returns>
        IntPtr Allocation(IntPtr userData, IntPtr size, IntPtr alignment, SystemAllocationScope allocationScope);

        /// <summary>
        /// Called when Vulkan requires some memory to be freed
        /// </summary>
        /// <param name="userData"></param>
        /// <param name="memory"></param>
        void Free(IntPtr userData, IntPtr memory);

        /// <summary>
        /// Called when Vulkan requires some memory to be reallocated
        /// </summary>
        /// <param name="userData"></param>
        /// <param name="original"></param>
        /// <param name="size"></param>
        /// <param name="alignment"></param>
        /// <param name="allocationScope"></param>
        /// <returns></returns>
        IntPtr Reallocation(IntPtr userData, IntPtr original, IntPtr size, IntPtr alignment, SystemAllocationScope allocationScope);
    }
}
